using StudyDAL;
using StudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBLL
{
    /// <summary>
    /// 从数据访问层得到管理者信息数据
    /// </summary>
    public partial class ManagerInfoBll
    {

        ManagerInfoDal miDal = new ManagerInfoDal();
        #region 调用数据访问层的读取方法
        /// <summary>
        /// 从数据访问层得到管理者数据集合
        /// </summary>
        /// <returns>管理者数据集合</returns>
        public List<ManagerInfo> GetList()
        {
            return miDal.GetList();
        }
        #endregion
        #region 调用数据访问层的添加方法
        /// <summary>
        /// 将管理者数据对象通过数据访问层的方法添加到数据库
        /// </summary>
        /// <param name="mi">要添加的管理者对象</param>
        /// <returns>是否添加成功</returns>
        public bool add(ManagerInfo mi)
        {
            return miDal.Insert(mi) > 0;
        }
        #endregion
        #region 调用数据访问层的修改方法
        /// <summary>
        /// 调用数据访问层的修改方法
        /// </summary>
        /// <param name="mi">管理者数据对象</param>
        /// <returns>是否修改成功</returns>
        public bool edit(ManagerInfo mi)
        {
            return miDal.Update(mi) > 0;
        } 
        #endregion
    } 

}
