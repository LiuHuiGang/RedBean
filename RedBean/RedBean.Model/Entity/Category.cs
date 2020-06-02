using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

/// <summary>
/// 类别
/// </summary>
namespace RedBean.Model.Entity
{
   public class Category:BaseEntity
    {
        /// <summary>
        /// 分类名
        /// </summary>
        [Required,MaxLength(30)]
        public string Name { get; set; }
        /// <summary>
        ///分类名编号
        /// </summary>
        [Required]
        public int Serial { get; set; }
    }
}
