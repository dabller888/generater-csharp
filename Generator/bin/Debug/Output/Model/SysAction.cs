//-----------------------------------------------------------------------
// <copyright file=" {SysAction}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {SysAction}.cs
// * history : 2018-07-31 06:08:14
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// SysAction Entity Model
    /// </summary>
    public partial class SysAction {
		public int ActionId { get; set; }
		public int ModuleId { get; set; }
		public string ActionName { get; set; }
		public string ActionCode { get; set; }
		public string ButtonCode { get; set; }
		public string ParaName { get; set; }
		public int ActionType { get; set; }
		public int IsDeleted { get; set; }
	}
}
