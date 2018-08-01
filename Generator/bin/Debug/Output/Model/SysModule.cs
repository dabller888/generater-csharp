//-----------------------------------------------------------------------
// <copyright file=" {SysModule}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {SysModule}.cs
// * history : 2018-07-31 06:08:15
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// SysModule Entity Model
    /// </summary>
    public partial class SysModule {
		public int ModuleId { get; set; }
		public string ModuleName { get; set; }
		public string ModuleUrl { get; set; }
		public int ModulePId { get; set; }
		public int ModuleLever { get; set; }
		public int OrderNo { get; set; }
		public int IsDeleted { get; set; }
	}
}
