//-----------------------------------------------------------------------
// <copyright file=" {SysDepartment}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {SysDepartment}.cs
// * history : 2018-07-31 06:08:15
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// SysDepartment Entity Model
    /// </summary>
    public partial class SysDepartment {
		public int DeptId { get; set; }
		public string DepartName { get; set; }
		public int DeptPId { get; set; }
		public string DepartDesc { get; set; }
	}
}
