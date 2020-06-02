using System;
using System.Collections.Generic;
using System.Text;

namespace RedBean.DTO.Pager
{
    public class Result
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 结果模型
        /// </summary>
        public dynamic ResultModel { get; set; }
    }
}
