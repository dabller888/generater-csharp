//-----------------------------------------------------------------------
// <copyright file=" {SysGroup}.cs" company="壹零控网络技术 Enterprises">
// * Copyright (C) 版权归壹零控网络技术所有
// * version : 1.0.0
// * author  : iceld
// * FileName: {SysGroup}.cs
// * history : 2018-07-31 06:08:15
// </copyright>
//-----------------------------------------------------------------------
using System;
namespace QY.Stage.Frameworks.Model {    
    /// <summary>
    /// SysGroup Entity Model
    /// </summary>
    public partial class SysGroup {
		public int GroupId { get; set; }
		public string GroupName { get; set; }
		public int GroupPId { get; set; }
		public DateTime CreateTime { get; set; }
		public string GroupDesc { get; set; }
		public int IsDeleted { get; set; }
	}
}
