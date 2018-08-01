//-----------------------------------------------------------------------
// <copyright file=" {UserRole}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {UserRole}.cs
// * history : 2018-07-31 06:08:15
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// UserRole Entity Model
    /// </summary>
    public partial class UserRole {
		public int UserId { get; set; }
		public int RoleId { get; set; }
	}
}
