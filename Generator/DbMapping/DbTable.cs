using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator.DbMapping {
    public class DbTable {
        public string TableName { set; get; }
        public string SchemaName { set; get; }
        public int Rows { set; get; }
        public bool HasPrimaryKey { set; get; }
    }
}
