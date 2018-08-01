using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;

using Generator.DbMapping;

namespace Generator.DbHelper {
    public class MysqlDbHelper : IDbHelper {
        #region 访问mysql数据库
        public static DataTable GetDataTable(string connectionString, string commandText, params MySqlParameter[] parms) {
            try {
                using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = commandText;
                    command.Parameters.AddRange(parms);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            } catch (MySqlException ex) {
                throw new Exception("mysql process exception", ex);
            }
        }
        #endregion

        public List<DbTable> GetDbTables(string tables = null) {
            string sql = string.Format(@"select t2.TABLE_SCHEMA as schemname,
              t2.TABLE_NAME as tablename,
              IFNULL(t2.TABLE_ROWS,0) as rows,
              t2.TABLE_COMMENT as comment,
              (
                select (case when count(*)>0 then 1 else 0 end)
                from information_schema.TABLE_CONSTRAINTS t1
                join information_schema.KEY_COLUMN_USAGE t2 using (
                    constraint_name,
                    table_schema,
                    table_name
                )
                where t1.constraint_type = 'PRIMARY KEY' and t1.table_schema = 'huanqiu' and t1.TABLE_NAME=t2.TABLE_NAME
              )as primarykey
            from information_schema.TABLES t2
            where t2.TABLE_SCHEMA='{0}';", ConfigInfo.GetDbName());

            DataTable dt = GetDataTable(ConfigInfo.GetConnectionString(), sql);
            List<DbTable> tbs = new List<DbTable>();
            DbTable t = null;
            for (int i = 0; i < dt.Rows.Count; i++) {
                t = new DbTable();
                t.TableName = dt.Rows[i]["tablename"].ToString();
                t.UpperTableName = ConfigInfo.ToUpper(dt.Rows[i]["tablename"].ToString());
                t.SchemaName = dt.Rows[i]["schemname"].ToString();
                t.Rows = Convert.ToInt32(dt.Rows[i]["rows"]);
                t.HasPrimaryKey = Convert.ToBoolean(dt.Rows[i]["primarykey"]);
                tbs.Add(t);
            }
            return tbs;
        }

        public List<DbColumn> GetTableColumns(string tableName, string schema = "dbo") {
            #region SQL
            string sql = string.Format(@"select t1.ORDINAL_POSITION as ColumnID,
  t1.COLUMN_NAME as ColumnName,
  t1.DATA_TYPE as ColumnType,
  #t1.COLUMN_TYPE,
  (
    select (case when count(*)>0 then 1 else 0 end)
    from INFORMATION_SCHEMA.TABLE_CONSTRAINTS c1,
      information_schema.KEY_COLUMN_USAGE c2
    where
      c1.TABLE_NAME=c2.TABLE_NAME and c1.CONSTRAINT_TYPE='PRIMARY KEY' and
      c1.TABLE_SCHEMA='huanqiu' and c1.TABLE_NAME='huanqiu_account' and c2.COLUMN_NAME=t1.COLUMN_NAME
  )as IsPrimaryKey,
  (case when t1.IS_NULLABLE='YES' then 1 else 0 end) as IsNullable,
  (case when t1.EXTRA='auto_increment' then 1 else 0 end)as IsIdentity,
  t1.NUMERIC_PRECISION as `Precision`,
  t1.NUMERIC_SCALE as Scale,
  (
      case
          when t1.DATA_TYPE='nvarchar' and t1.CHARACTER_MAXIMUM_LENGTH>0 then t1.CHARACTER_MAXIMUM_LENGTH/2
          when t1.DATA_TYPE='nchar' and t1.CHARACTER_MAXIMUM_LENGTH>0 then t1.CHARACTER_MAXIMUM_LENGTH/2
          when t1.DATA_TYPE='ntext' and t1.CHARACTER_MAXIMUM_LENGTH>0 then t1.CHARACTER_MAXIMUM_LENGTH/2
          else t1.CHARACTER_MAXIMUM_LENGTH
      end
    )as CharLength,
  ifnull(t1.CHARACTER_OCTET_LENGTH,0) as ByteLength,
  t1.COLUMN_COMMENT as Remark
from information_schema.COLUMNS t1
  LEFT JOIN information_schema.TABLES t2 on t2.TABLE_NAME=t1.TABLE_NAME and t2.TABLE_SCHEMA=t1.TABLE_SCHEMA
  LEFT JOIN information_schema.SCHEMATA t3 on t3.SCHEMA_NAME=t1.TABLE_SCHEMA
where t3.SCHEMA_NAME='{0}' and t2.TABLE_NAME='{1}'", ConfigInfo.GetDbName(), tableName);
            #endregion

            DataTable dt = GetDataTable(ConfigInfo.GetConnectionString(), sql);
            List<DbColumn> cols = new List<DbColumn>();
            DbColumn col = null;
            for (int i = 0; i < dt.Rows.Count; i++) {
                col = new DbColumn();
                col.ColumnID = Convert.ToInt32(dt.Rows[i]["ColumnID"]);
                col.IsPrimaryKey = Convert.ToBoolean(dt.Rows[i]["IsPrimaryKey"]);
                col.ColumnName = dt.Rows[i]["ColumnName"].ToString();
                col.UpperColumnName = ConfigInfo.ToUpper(dt.Rows[i]["ColumnName"].ToString(), false);
                col.LowerColumnName = ConfigInfo.ToLower(dt.Rows[i]["ColumnName"].ToString(), false);
                col.ColumnType = dt.Rows[i]["ColumnType"].ToString();
                col.IsIdentity = Convert.ToBoolean(dt.Rows[i]["IsIdentity"]);
                col.IsNullable = Convert.ToBoolean(dt.Rows[i]["IsNullable"]);
                col.ByteLength = Convert.ToInt64(dt.Rows[i]["ByteLength"]);
                col.CharLength = string.IsNullOrEmpty(dt.Rows[i]["CharLength"].ToString()) ? 0 : Convert.ToInt64(dt.Rows[i]["CharLength"]);
                col.Scale = string.IsNullOrEmpty(dt.Rows[i]["Scale"].ToString()) ? 0 : Convert.ToInt32(dt.Rows[i]["Scale"]);
                col.Remark = dt.Rows[i]["Remark"].ToString();
                cols.Add(col);
            }
            return cols;
        }

        public string GetTablePrimaryKeys(List<DbMapping.DbColumn> dbColumns) {
            throw new NotImplementedException();
        }
    }
}
