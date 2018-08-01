//-----------------------------------------------------------------------
// <copyright file=" {GroupUser}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {GroupUser}.cs
// * history : 2018-07-31 06:08:14
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// GroupUser Entity Model
    /// </summary>
    public partial class GroupUser {
		public int GroupId { get; set; }
		public int UserId { get; set; }
	}
}
