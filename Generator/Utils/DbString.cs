using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator.DbHelper;
using Generator.DbMapping;

namespace Generator.Utils {
    public class DbString {
        private static IDbHelper dbHelper = null;

        static DbString() {
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

        //public static IDbHelper CreateInstance() {
        //    return dbHelper;
        //}

        public string Replace(string src, string srcStr, string desStr) {
            return src.Replace(srcStr, desStr);
        }

        //表名以下划线区分
        public string GenerateClassName(string src) {
            StringBuilder sb = new StringBuilder();
            string[] strs = src.Split(new char[] { '_' });
            string _str = "";
            for (int i = 0; i < strs.Length; i++) {
                _str = strs[i];
                sb.AppendFormat("{0}{1}", _str.Substring(0, 1).ToUpper(), _str.Substring(1, _str.Length - 1));
            }

            return sb.ToString();
        }

        #region 生成主键参数
        //获取自动增长主键，或多对多生成复合主键之一
        public string GetPKs(string tableName) {
            string str = "";
            foreach (DbColumn dc in dbHelper.GetTableColumns(tableName)) {
                if (dc.IsPrimaryKey) {
                    if (dc.IsIdentity) {//仅取自动增长
                        str = dc.ColumnName;
                    } else {
                        return dc.ColumnName;
                    }
                }
            }
            return str;
        }

        //获取主键作为方法参数列表
        public string GetPKParams(string tableName) {
            string str = "";
            foreach (DbColumn dc in dbHelper.GetTableColumns(tableName)) {
                if (dc.IsPrimaryKey) {
                    if (dc.IsIdentity) {//仅取自动增长
                        str += string.Format("{0} {1}, ", dc.CSharpType, dc.ColumnName);
                    } else {
                        return string.Format("{0} {1}", dc.CSharpType, dc.ColumnName);
                    }
                }
            }
            if (str.Trim().IndexOf(",") >= 0)
                str = str.Trim().Substring(0, str.Trim().Length - 1);
            return str;
        }

        //生成主键查询表达式
        public string GetPKExpression(string tableName) {
            string str = "";
            foreach (DbColumn dc in dbHelper.GetTableColumns(tableName)) {
                if (dc.IsPrimaryKey) {
                    if (dc.IsIdentity) {
                        str += string.Format("m => m.{0} == {0} && ", dc.ColumnName);
                    } else {
                        return string.Format("m => m.{0} == {0}", dc.ColumnName);
                    }
                }
            }
            if (str.Trim().IndexOf("&&") >= 0)
                str = str.Trim().Substring(0, str.Trim().Length - 2);
            return str;
        }

        //获取分页查询表达式
        public string GetPKQExpression(string tableName) {
            string str = "";
            foreach (DbColumn dc in dbHelper.GetTableColumns(tableName)) {
                if (dc.IsPrimaryKey) {
                    if (dc.IsIdentity) {
                        str += string.Format("m => m.{0} == query.{0} && ", dc.ColumnName);
                    } else {
                        return string.Format("m => m.{0} == query.{0}", dc.ColumnName);
                    }
                }
            }
            if (str.Trim().IndexOf("&&") >= 0)
                str = str.Trim().Substring(0, str.Trim().Length - 2);
            return str;
        }

        //获取排序表达式
        public string GetSortExpression(string tableName) {
            string str = "";
            foreach (DbColumn dc in dbHelper.GetTableColumns(tableName)) {
                if (dc.IsPrimaryKey) {
                    if (dc.IsIdentity) {
                        str += string.Format("m => m.{0}", dc.ColumnName);
                    } else {
                        return string.Format("m => m.{0}", dc.ColumnName);
                    }
                }
            }
            return str;
        }

        //生成映射主键
        public string GetMappingPKs(string tableName) {
            string str = "";
            int i = 0;
            foreach (DbColumn dc in dbHelper.GetTableColumns(tableName)) {
                if (dc.IsPrimaryKey) {
                    i++;
                    str += string.Format("t.{0}, ", dc.ColumnName);
                }
            }
            if (str.Trim().IndexOf(",") >= 0)
                str = str.Trim().Substring(0, str.Trim().Length - 1);
            if (i > 1) {
                str = "t => new { " + str + " }";
            } else {
                str = string.Format("t => {0}", str);
            }
            return str;
        }

        //获取所有查询列
        public string GetQueryColumns(string tableName) {
            string str = "";
            foreach (DbColumn dc in dbHelper.GetTableColumns(tableName)) {
                str += string.Format("{0}=e.{0},", dc.ColumnName);
            }
            if (str.Trim().IndexOf(",") >= 0)
                str = str.Trim().Substring(0, str.Trim().Length - 1);
            return str;
        }

        public string ToLower(string str) {
            return str.ToLower();
        }

        #endregion
    }
}
