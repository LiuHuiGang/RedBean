using RedBean.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedBean.DAL.Interface
{
    public interface IBaseDAL: IDisposable
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddAsync<T>(T model) where T : BaseEntity;
        /// <summary>
        /// 添加后返回添加信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        int Add<T>(ref T model) where T : BaseEntity;
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync<T>(List<T> model) where T : BaseEntity;
        /// <summary>
        /// 假删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> RemoveAsync<T>(T model) where T : BaseEntity;
        /// <summary>
        /// 假批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> RemoveRangeAsync<T>(List<T> model) where T : BaseEntity;
        /// <summary>
        /// 条件批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> RemoveRangeAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> UpdateAsync<T>(T model) where T : BaseEntity;
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> UpdateRangeAsync<T>(List<T> model) where T : BaseEntity;
        /// <summary>
        /// 条件批量修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> UpdateRangeAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> List<T>() where T : BaseEntity;
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> ListWhere<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IQueryable<T> ListByPage<T>(IQueryable<T> queryable, int pageSize = 10, int pageIndex = 0) where T : BaseEntity;
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IQueryable<T> ListByPage<T>(Expression<Func<T, bool>> predicate, int pageSize = 10, int pageIndex = 0) where T : BaseEntity;
       /// <summary>
       /// 分页查询
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="pageSize"></param>
       /// <param name="pageIndex"></param>
       /// <returns></returns>
        IQueryable<T> ListByPage<T>(int pageSize = 10, int pageIndex = 0) where T : BaseEntity;
        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        IQueryable<T> Get<T>(Guid id) where T : BaseEntity;
    }
}
