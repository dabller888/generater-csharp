using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Generator.DbHelper;

namespace Generator.DbMapping {
    public class DbColumn {
        public int ColumnID { set; get; }
        public bool IsPrimaryKey { set; get; }
        public string ColumnName { set; get; }
        public string UpperColumnName { set; get; }
        public string LowerColumnName { set; get; }
        public string ColumnType { set; get; }
        public string CSharpType {
            get {
                IDbTypeMap map = null;
                if ("mysql" == ConfigInfo.GetDbType().ToLower()) {
                    map = new MysqlDbTypeMap();
                } else if ("oracle" == ConfigInfo.GetDbType().ToLower()) {
                    map = new OracleDbTypeMap();
                } else {
                    map = new MssqlDbTypeMap();
                }
                return map.MapCsharpType(ColumnType);
            }
        }
        public Type CommonType {
            get {
                IDbTypeMap map = null;
                if ("mysql" == ConfigInfo.GetDbType().ToLower()) {
                    map = new MysqlDbTypeMap();
                } else if ("oracle" == ConfigInfo.GetDbType().ToLower()) {
                    map = new OracleDbTypeMap();
                } else {
                    map = new MssqlDbTypeMap();
                }
                return map.MapCommonType(ColumnType);
            }
        }
        public long ByteLength { set; get; }
        public long CharLength { set; get; }
        public int Scale { set; get; }
        public bool IsIdentity { set; get; }
        public bool IsNullable { set; get; }
        public string Remark { set; get; }
    }
}
