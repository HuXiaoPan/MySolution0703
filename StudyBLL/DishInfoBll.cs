using StudyDAL;
using StudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBLL
{
    public partial class DishInfoBll
    {
        #region 定义变量
        DishInfoDal diDal = new DishInfoDal();  //数据访问层实例 
        #endregion

        #region 读取数据
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dic">添加的参数键值对</param>
        /// <returns>数据集合</returns>
        public List<DishInfo> GetList(Dictionary<string,string> dic)
        {
            return diDal.GetList(dic);
        }
        #endregion

        #region 添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="di">要添加的对象</param>
        /// <returns>是否成功</returns>
        public bool Add(DishInfo di)
        {
            return diDal.Insert(di) > 0;
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="di">要修改的对象</param>
        /// <returns>是否成功</returns>
        public bool Edit(DishInfo di)
        {
            return diDal.Update(di) > 0;
        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="di">要删除的对象</param>
        /// <returns>是否成功</returns>
        public bool Remove(DishInfo di)
        {
            return diDal.Drop(di) > 0;
        }
        #endregion
    }
}
