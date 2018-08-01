//-----------------------------------------------------------------------
// <copyright file=" {SysRole}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {SysRole}.cs
// * history : 2018-07-31 06:08:15
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// SysRole Entity Model
    /// </summary>
    public partial class SysRole {
		public int RoleId { get; set; }
		public int RolePId { get; set; }
		public string RoleName { get; set; }
		public DateTime CreateTime { get; set; }
		public string RoleDesc { get; set; }
		public int IsDeleted { get; set; }
	}
}
