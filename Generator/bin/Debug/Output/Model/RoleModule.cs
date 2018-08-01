//-----------------------------------------------------------------------
// <copyright file=" {RoleModule}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {RoleModule}.cs
// * history : 2018-07-31 06:08:14
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// RoleModule Entity Model
    /// </summary>
    public partial class RoleModule {
		public int RoleId { get; set; }
		public int ModuleId { get; set; }
		public int ActionId { get; set; }
	}
}
