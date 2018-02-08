using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator.DbMapping {
    public class OracleDbTypeMap : IDbTypeMap {
        public string MapCsharpType(string dbtype) {
            throw new NotImplementedException();
        }

        public Type MapCommonType(string dbtype) {
            throw new NotImplementedException();
        }
    }
}
