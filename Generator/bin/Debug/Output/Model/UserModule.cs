//-----------------------------------------------------------------------
// <copyright file=" {UserModule}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {UserModule}.cs
// * history : 2018-07-31 06:08:15
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// UserModule Entity Model
    /// </summary>
    public partial class UserModule {
		public int UserId { get; set; }
		public int ModuleId { get; set; }
		public int ActionId { get; set; }
	}
}
