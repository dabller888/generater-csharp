//-----------------------------------------------------------------------
// <copyright file=" {SysLog}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {SysLog}.cs
// * history : 2018-07-31 06:08:15
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// SysLog Entity Model
    /// </summary>
    public partial class SysLog {
		public int LogId { get; set; }
		public int OperType { get; set; }
		public string LogDesc { get; set; }
		public int UserId { get; set; }
		public string IPAddress { get; set; }
		public string MacAddress { get; set; }
		public DateTime OperTime { get; set; }
		public int IsDeleted { get; set; }
	}
}
