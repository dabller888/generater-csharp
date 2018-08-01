//-----------------------------------------------------------------------
// <copyright file=" {RoleUser}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {RoleUser}.cs
// * history : 2018-07-31 06:08:14
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// RoleUser Entity Model
    /// </summary>
    public partial class RoleUser {
		public int RoleId { get; set; }
		public int UserId { get; set; }
	}
}
