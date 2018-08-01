using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Generator.Utils;

namespace Generator.DbHelper {
    public class ConfigInfo {
        private static char[] SPCHAR = new char[]{ '_' };

        public static DbConfigInfo GetDbConfigInfo() {
            DbConfigInfo myDb = null;
            FileStream fs = null;
            StreamReader sr = null;
            try {
                string path = Environment.CurrentDirectory + "\\Config\\db.json";
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                string dbJson = sr.ReadToEnd();
                List<DbConfigInfo> dbs = JsonHelper.DeserializeJsonToList<DbConfigInfo>(dbJson);
                foreach (DbConfigInfo db in dbs)
                    if (db.Enable)
                        myDb = db;
            } catch (IOException ex) {
                throw new Exception("read db.json file, throw exception", ex);
            } finally {
                sr.Dispose();
                fs.Dispose();
            }

            return myDb;
        }

        public static CopyrightInfo GetCopyrightInfo() {
            CopyrightInfo copyright = null;
            FileStream fs = null;
            StreamReader sr = null;
            try {
                string path = Environment.CurrentDirectory + "\\Config\\copyright.json";
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                string configJson = sr.ReadToEnd();
                copyright = JsonHelper.DeserializeJsonToObject<CopyrightInfo>(configJson);
            } catch (IOException ex) {
                throw new Exception("read copyright.json file,throw exception", ex);
            } finally {
                sr.Dispose();
                fs.Dispose();
            }
            return copyright;
        }

        public static string GetDbType() {
            DbConfigInfo db = GetDbConfigInfo();
            if (db == null) return "";
            return db.DbType;
        }

        public static string GetConnectionString() {
            DbConfigInfo db = GetDbConfigInfo();
            if (db == null) return "";
            StringBuilder sb = new StringBuilder();
            if ("mssql" == db.DbType.ToLower()) {
                sb.AppendFormat("Data Source={0},{1};", db.Server, db.Port);
                sb.AppendFormat("Initial Catalog={0};", db.DbName);
                sb.AppendFormat("User ID={0};", db.User);
                sb.AppendFormat("Password={0};", db.Passwd);
                sb.Append("Persist Security Info=True;");
            } else if ("mysql" == db.DbType.ToLower()) {
                sb.AppendFormat("Data Source={0};", db.Server);
                sb.AppendFormat("port={0};", db.Port);
                sb.AppendFormat("Initial Catalog={0};", db.DbName);
                sb.AppendFormat("User ID={0};", db.User);
                sb.AppendFormat("Password={0};", db.Passwd);
                sb.Append("Charset=utf8;");
            } else if ("oracle" == db.DbType.ToLower()) {

            }
            return sb.ToString();
        }

        public static string GetDbName() {
            DbConfigInfo db = GetDbConfigInfo();
            if (db == null) return "";
            return db.DbName;
        }

        public static string ToUpper(String fieldName,bool flag=true) {
            string str = fieldName;
            try {
                string prefix = GetDbConfigInfo().Prefix;
                if (!String.IsNullOrEmpty(prefix) && flag) {
                    fieldName = fieldName.Substring(prefix.Length, fieldName.Length - prefix.Length);                    
                }

                bool line = false;
                for (int i = 0; i < SPCHAR.Length; i++)
                    if (fieldName.IndexOf(SPCHAR[i]) >= 0)
                        line = true;

                if (line) {
                    str = "";
                    String[] subs = fieldName.Split(SPCHAR);
                    foreach (string sub in subs) {
                        str += sub.Substring(0, 1).ToUpper() + sub.Substring(1, sub.Length - 1);
                    }
                } else {
                    str = fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1, fieldName.Length - 1);
                }

            } catch (NullReferenceException ex) {
                throw new Exception("null pointer", ex);
            }

            return str;
        }

        public static string ToLower(string fieldName, bool flag = true) {
            string str = fieldName;
            try {
                string prefix = GetDbConfigInfo().Prefix;
                if (!String.IsNullOrEmpty(prefix) && flag) {
                    fieldName = fieldName.Substring(prefix.Length, fieldName.Length - prefix.Length);
                }

                bool line = false;
                for (int i = 0; i < SPCHAR.Length; i++)
                    if (fieldName.IndexOf(SPCHAR[i]) >= 0)
                        line = true;

                if (line) {
                    str = "";
                    String[] subs = fieldName.Split(SPCHAR);
                    foreach (string sub in subs) {
                        str += sub.Substring(0, 1).ToLower() + sub.Substring(1, sub.Length - 1);
                    }
                } else {
                    str = fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1, fieldName.Length - 1);
                }

            } catch (NullReferenceException ex) {
                throw new Exception("null pointer", ex);
            }

            return str;
        }

    }

    public class DbConfigInfo {
        public string DbType { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string DbName { get; set; }
        public string User { get; set; }
        public string Passwd { get; set; }
        public string Prefix { get; set; }
        public bool Enable { get; set; }
    }

    public class CopyrightInfo {
        public String Company { get; set; }
        public String Copyright { get; set; }
        public String Version { get; set; }
        public String Author { get; set; }
        public String CreteTime { get; set; }
    }
}
