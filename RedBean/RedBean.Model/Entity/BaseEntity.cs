using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RedBean.Model.Entity
{
   public class BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid Id { get; set; } = new Guid();
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        public bool IsRemoved { get; set; } = false;
    }
}
