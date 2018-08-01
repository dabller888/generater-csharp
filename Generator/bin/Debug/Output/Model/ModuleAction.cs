//-----------------------------------------------------------------------
// <copyright file=" {ModuleAction}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {ModuleAction}.cs
// * history : 2018-07-31 06:08:14
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// ModuleAction Entity Model
    /// </summary>
    public partial class ModuleAction {
		public int ModuleActionId { get; set; }
		public int ModuleId { get; set; }
		public int ActionId { get; set; }
	}
}
