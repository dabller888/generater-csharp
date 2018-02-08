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
            }
        }
        #endregion

        private void btnGenerateCode_Click(object sender, EventArgs e) {
            Hashtable ht = null;
            string path = System.Environment.CurrentDirectory;
            string tempPath = string.Format(@"{0}\Templates", path);
            string outPath = string.Format(@"{0}\Output", path);
            List<FileSystemInfo> files = FileGen.GetFiles(tempPath, "vm");
            foreach (FileSystemInfo file in files) {
                //创建目录
                string outFileName = file.Name.Substring(0, file.Name.IndexOf("."));
                string outDir = string.Format(@"{0}\{1}", outPath, outFileName);
                if (!Directory.Exists(outDir)) {
                    Directory.CreateDirectory(outDir);
                }

                List<DbTable> tables = dbHelper.GetDbTables();
                foreach (DbTable t in tables) {
                    ht = new Hashtable();
                    ht["table"] = t;
                    ht["columns"] = dbHelper.GetTableColumns(t.TableName);
                    string outFile = string.Format(@"{0}\{1}.cs", outDir, t.TableName);
                    FileGen.GetFile(file.FullName, ht, outFile);
                }
            }

        }
    }
}
