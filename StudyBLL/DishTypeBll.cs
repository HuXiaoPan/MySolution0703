using StudyDAL;
using StudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBLL
{
    public partial class DishTypeBll
    {
        #region 定义变量
        DishTypeDal dtDal = new DishTypeDal();  //数据访问层实例 
        #endregion

        #region 读取数据
        /// <summary>
        /// 得到对象集合
        /// </summary>
        /// <returns>对象集合</returns>
        public List<DishType> GetList()
        {
            return dtDal.GetList();
        }
        #endregion

        #region 添加数据
        /// <summary>
        /// 添加新数据
        /// </summary>
        /// <param name="dt">要添加的数据对象</param>
        /// <returns>是否成功</returns>
        public bool Add(DishType dt)
        {
            return dtDal.Insert(dt) > 0;
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="dt">要修改的数据</param>
        /// <returns>是否修改成功</returns>
        public bool Edit(DishType dt)
        {
            return dtDal.Update(dt) > 0;
        }
        #endregion

        #region 移除数据
        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="dt">要移除的数据</param>
        /// <returns>是否成功</returns>
        public bool Remove(DishType dt)
        {
            return dtDal.Drop(dt) > 0;
        } 
        #endregion
    }
}
