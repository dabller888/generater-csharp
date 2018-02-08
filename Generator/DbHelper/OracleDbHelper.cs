using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator.DbHelper {
    public class OracleDbHelper : IDbHelper {
        public List<DbMapping.DbTable> GetDbTables(string tables = null) {
            throw new NotImplementedException();
        }

        public List<DbMapping.DbColumn> GetTableColumns(string tableName, string schema = "dbo") {
            throw new NotImplementedException();
        }

        public string GetTablePrimaryKeys(List<DbMapping.DbColumn> dbColumns) {
            throw new NotImplementedException();
        }
    }
}
