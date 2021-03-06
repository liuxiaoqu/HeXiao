﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(GoldTempMetadata))]//使用GoldTempMetadata对GoldTemp进行数据验证
    public partial class GoldTemp 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class GoldTempMetadata
    {
			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 1)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 3)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改时间", Order = 5)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "修改人", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "Vertion", Order = 7)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Vertion { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 8)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Remark { get; set; }

			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 9)]
			public object Id { get; set; }


    }
}
 

