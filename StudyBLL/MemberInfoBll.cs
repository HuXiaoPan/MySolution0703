using StudyDAL;
using StudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBLL
{
    public partial class MemberInfoBll
    {
        #region 定义变量
        MemberInfoDal miDal = new MemberInfoDal();
        #endregion
        #region 得到会员集合
        /// <summary>
        /// 从数据访问层得到会员集合
        /// </summary>
        /// <param name="dic">传入的键值对</param>
        /// <returns>会员信息集合</returns>
        public List<MemberInfo> GetList(Dictionary<string,string> dic)
        {
            return miDal.GetList(dic);
        }
        #endregion
        #region 添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="mi">要添加数据的对象</param>
        /// <returns>是否添加成功</returns>
        public bool add(MemberInfo mi)
        {
            return miDal.Insert(mi)>0;
        }
        #endregion
        #region 修改数据
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mi">要修改的数据对象</param>
        /// <returns>是否修改成功</returns>
        public bool Edit(MemberInfo mi)
        {
            return miDal.Update(mi) > 0;
        }
        #endregion
        #region 删除数据
        /// <summary>
        /// 伪删除数据
        /// </summary>
        /// <param name="mi">要删除的数据对象</param>
        /// <returns>是否删除成功</returns>
        public bool Remove(MemberInfo mi)
        {
            return miDal.Drop(mi)>0;
        }
        #endregion
    }
}
