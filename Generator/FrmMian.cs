using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System.IO;
using Generator.DbHelper;
using Generator.DbMapping;
using Generator.Utils;
using System.Collections;
using NPOI.SS.UserModel;

namespace Generator {
    /// <summary>
    /// 
    /// 1.io https://www.cnblogs.com/liyangLife/p/4797583.html
    /// 2. http://www.cnblogs.com/CreateMyself/p/5823861.html
    /// 3. https://unmi.cc/csharp-velocity-templat/
    /// </summary>
    public partial class frmGenerateMain : Form {
        #region 变量声明
        private static IDbHelper dbHelper = null;
        #endregion

        public frmGenerateMain() {
            InitializeComponent();

            InitData();
        }

        #region 初始化配置
        private void InitData() {
            if ("mssql" == ConfigInfo.GetDbType().ToLower()) {
                dbHelper = new MssqlDbHelper();
            } else if ("mysql" == ConfigInfo.GetDbType().ToLower()) {
                dbHelper = new MysqlDbHelper();
            } else if ("oracle" == ConfigInfo.GetDbType().ToLower()) {
                dbHelper = new OracleDbHelper();
            } else {
                throw new Exception("db.json do not enable db setting");            
            }
        }

        private CopyrightInfo SetCopyrightInfo() {
            CopyrightInfo info = ConfigInfo.GetCopyrightInfo();
            info.CreteTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return info;
        }
        #endregion
        
        private void btnGenerateCode_Click(object sender, EventArgs e) {
            Hashtable ht = null;
            string ext = "cs";
            string path = System.Environment.CurrentDirectory;
            string tempPath = string.Format(@"{0}\Templates", path);
            string outPath = string.Format(@"{0}\Output", path);
            List<FileSystemInfo> files = FileGen.GetFiles(tempPath, "vm");
            this.rtbContent.Text += string.Format(">>>输出：{0}\r\n", outPath);
            foreach (FileSystemInfo file in files) {
                //创建目录
                string outFileName = file.Name.Substring(0, file.Name.IndexOf("."));
                string outDir = string.Format(@"{0}\{1}", outPath, outFileName);
                if (!Directory.Exists(outDir)) {
                    Directory.CreateDirectory(outDir);
                }
                this.rtbContent.Text += string.Format("\t>>>创建目录：{0}\r\n", outFileName);
                List<DbTable> tables = dbHelper.GetDbTables();
                foreach (DbTable t in tables) {
                    ht = new Hashtable();
                    ht["copyright"] = SetCopyrightInfo();
                    ht["table"] = t;
                    ht["columns"] = dbHelper.GetTableColumns(t.TableName);
                    if (outFileName.IndexOf("UI") >= 0) {
                        ext = "html";
                    } else {
                        ext = "cs";
                    }
                    string outFile = string.Format(@"{0}\{1}.{2}", outDir, t.UpperTableName, ext);
                    FileGen.GetFile(file.FullName, ht, outFile);
                    this.rtbContent.Text += string.Format("\t\t创建文件：{0}\r\n", string.Format(@"{0}.{1}", t.UpperTableName, ext));
                }
                this.rtbContent.Text += "\r\n";
            }

        }

        #region 生成数据字典
        string[] ignoreTables = new string[] { };


        #endregion


        private void btnGenDict_Click(object sender, EventArgs e)
        {
            string o = "";
            for (int j = 0; j < ignoreTables.Length; j++)
            {
                //ignoreTables[j] = ignoreTables[j].Replace("_", "");
                o += ignoreTables[j] + ",";
            }

            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("数据字典");
            //公共样式：加边框
            NPOI.SS.UserModel.ICellStyle style = book.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Justify;
            IFont fontTitle = book.CreateFont();//新建一个字体样式对象
            //fontTitle.Boldweight = short.MaxValue;//设置字体加粗样式
            fontTitle.FontHeightInPoints = 12;//设置字体大小
            style.SetFont(fontTitle);
            //style.WrapText = true;

            NPOI.SS.UserModel.ICellStyle styleHeader = book.CreateCellStyle();
            styleHeader.CloneStyleFrom(style);//克隆公共的样式
            styleHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            styleHeader.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Justify;
            IFont fontHeader = book.CreateFont();//新建一个字体样式对象
            //fontHeader.Boldweight = short.MaxValue;//设置字体加粗样式
            fontHeader.FontHeightInPoints = 14;//设置字体大小
            styleHeader.SetFont(fontHeader);//使用SetFont方法将字体样式添加到单元格样式中
            styleHeader.FillPattern = FillPattern.SolidForeground;
            styleHeader.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Green.Index;
            //style.WrapText = true;

            List<DbTable> tables = dbHelper.GetDbTables();
            List<DbColumn> columns = new List<DbColumn>();
            int rowNo = 0;
            //int colNo = 0;
            foreach (DbTable t in tables)
            {
                //if (o.IndexOf(t.TableName) < 0) continue;

                NPOI.SS.UserModel.IRow row = sheet.CreateRow(rowNo);
                row.Height = 30 * 20;
                var cell = row.CreateCell(1);
                cell.CellStyle = styleHeader;
                cell.SetCellValue("表名");

                cell = row.CreateCell(2);
                cell.CellStyle = styleHeader;
                cell.SetCellValue(t.TableName);

                rowNo++;
                row = sheet.CreateRow(rowNo);
                cell = row.CreateCell(1);
                cell.CellStyle = styleHeader;
                cell.SetCellValue("列名");
                cell = row.CreateCell(2);
                cell.CellStyle = styleHeader;
                cell.SetCellValue("类型");
                cell = row.CreateCell(3);
                cell.CellStyle = styleHeader;
                cell.SetCellValue("主键");
                cell = row.CreateCell(4);
                cell.CellStyle = styleHeader;
                cell.SetCellValue("是否为空");
                cell = row.CreateCell(5);
                cell.CellStyle = styleHeader;
                cell.SetCellValue("备注");
                
                columns = dbHelper.GetTableColumns(t.TableName);
                foreach (DbColumn c in columns)
                {
                    rowNo++;
                    row = sheet.CreateRow(rowNo);
                    row.Height = 30 * 20;
                    cell = row.CreateCell(1);
                    cell.CellStyle = style;
                    cell.SetCellValue(c.ColumnName);
                    cell = row.CreateCell(2);
                    cell.CellStyle = style;
                    cell.SetCellValue(string.Format("{0}({1})", c.ColumnType, c.CharLength));
                    cell = row.CreateCell(3);
                    cell.CellStyle = style;
                    cell.SetCellValue(c.IsPrimaryKey ? "√" : "");
                    cell = row.CreateCell(4);
                    cell.CellStyle = style;
                    cell.SetCellValue(c.IsNullable ? "√" : "");
                    cell = row.CreateCell(5);
                    cell.CellStyle = style;
                    cell.SetCellValue(c.Remark);
                } 
                rowNo++;
                row = sheet.CreateRow(rowNo);
                row.Height = 30 * 20;
                rowNo++;
                row = sheet.CreateRow(rowNo);
            }

            //自动调节行宽度
            for (int i = 0; i < 5; i++)
                sheet.AutoSizeColumn(i);

            //sheet.SetColumnWidth(5, 300);

            string path = System.Environment.CurrentDirectory;
            string outPath = string.Format(@"{0}\Output", path);
            string outFile = string.Format(@"{0}\{1}", outPath,"Crm数据字典.xls");
            // 写入到客户端  
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                book.Write(ms);
                using (FileStream fs = new FileStream(outFile, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
                book = null;
            }
        }
    }
}
