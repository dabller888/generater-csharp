using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// users
    /// </summary>
    public partial class users {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }
        public byte[] last_login { get; set; }
        public int failed_login { get; set; }
        }
}
