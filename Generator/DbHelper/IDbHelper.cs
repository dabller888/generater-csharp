using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator.DbMapping;

namespace Generator.DbHelper {
    public interface IDbHelper {
        List<DbTable> GetDbTables(string tables = null);
        List<DbColumn> GetTableColumns(string tableName, string schema = "dbo");
        string GetTablePrimaryKeys(List<DbColumn> dbColumns);
        //string ConnectionString { get; }
        //string DbName { get; }
    }
}
