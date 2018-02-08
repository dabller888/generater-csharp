using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator.DbMapping {
    public interface IDbTypeMap {
        string MapCsharpType(string dbtype);
        Type MapCommonType(string dbtype);
    }
}
