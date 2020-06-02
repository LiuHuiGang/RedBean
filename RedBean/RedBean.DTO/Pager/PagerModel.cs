using System;
using System.Collections.Generic;
using System.Text;

namespace RedBean.DTO.Pager
{
    public class PagerModel
    {
        public PagerModel() { }
        public PagerModel(int PageSize, int PageNum)
        {
            this.PageSize = PageSize;
            this.PageNum = PageNum;
        }
        /// <summary>
        /// 每页记录条数
        /// </summary>
        private int pageSize;
        public int PageSize
        {
            get => pageSize <= 0 ? 20 : pageSize;
            set { pageSize = value; }
        }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 不算当前页的数据条数
        /// </summary>
        public int CurrentPage()
        {
            return (PageNum - 1) * PageSize;
        }
        /// <summary>
        /// 搜索模型
        /// </summary>
        public dynamic SearchModel { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage()
        {
            return (Total + PageSize - 1) / PageSize;
        }
        /// <summary>
        /// 结果模型
        /// </summary>
        public dynamic ResultModel { get; set; }
        public dynamic Template(dynamic Template = null)
        {
            if (Template == null)
            {
                Template = new Result();
            }
            List<string> FieldNames = new List<string>();
            Type type = Template.GetType();
            foreach (var item in type.GetProperties())
            {
                FieldNames.Add(item.Name);
            }
            if (FieldNames.Contains("PageSize"))
            {
                Template.PageSize = PageSize;
            }
            if (FieldNames.Contains("PageNum"))
            {
                Template.PageNum = PageNum;
            }
            if (FieldNames.Contains("CurrentPage"))
            {
                Template.CurrentPage = CurrentPage();
            }
            if (FieldNames.Contains("SearchModel"))
            {
                Template.SearchModel = SearchModel;
            }
            if (FieldNames.Contains("Total"))
            {
                Template.Total = Total;
            }
            if (FieldNames.Contains("TotalPage"))
            {
                Template.TotalPage = TotalPage();
            }
            if (FieldNames.Contains("ResultModel"))
            {
                Template.ResultModel = ResultModel;
            }
            return Template;
        }
    }
}
