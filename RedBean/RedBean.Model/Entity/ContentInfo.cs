using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
/// <summary>
/// 内容信息
/// </summary>
namespace RedBean.Model.Entity
{
   public class ContentInfo:BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required, MaxLength(30)]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 查看次数
        /// </summary>
        public int CheckNumber { get; set; }
        /// <summary>
        /// 路径地址
        /// </summary>
        [Required, MaxLength(200)]
        public string PathAddress { get; set; }
        /// <summary>
        /// 种类编号
        /// </summary>
        public int CategorySerial { get; set; }
    }
}
