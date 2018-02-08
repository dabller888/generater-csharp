using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Generator.Utils;

namespace Generator.DbHelper {
    public class ConfigInfo {
        public static DbConfigInfo GetDbConfigInfo() {
            string path = Environment.CurrentDirectory + "\\Config\\db.json";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string dbJson = sr.ReadToEnd();
            sr.Dispose();
            fs.Dispose();
            List<DbConfigInfo> dbs = JsonHelper.DeserializeJsonToList<DbConfigInfo>(dbJson);
            foreach (DbConfigInfo db in dbs)
                if (db.Enable)
                    return db;

            return null;
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
    }

    public class DbConfigInfo {
        public string DbType { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string DbName { get; set; }
        public string User { get; set; }
        public string Passwd { get; set; }
        public bool Enable { get; set; }
    }
}
