using StudyDAL;
using StudyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBLL
{
    public partial class MemberTypeBll
    {
        private MemberTypeDal mtDal;
        public MemberTypeBll()
        {
            mtDal = new MemberTypeDal();
        }
        #region 从数据访问层获得数据集合
        /// <summary>
        /// 从数据访问层获得数据集合
        /// </summary>
        /// <returns>数据对象集合</returns>
        public List<MemberType> Getlist()
        {
            return mtDal.GetList();
        }
        #endregion
        #region 给数据访问层添加数据
        /// <summary>
        /// 给数据访问层传入要插入的数据
        /// </summary>
        /// <param name="mt">要插入的数据对象</param>
        /// <returns>影响行数是否大于0</returns>
        public bool addData(MemberType mt)
        {
            return mtDal.Insert(mt) > 0;
        }
        #endregion
        #region 给数据访问层传递要修改的数据
        /// <summary>
        /// 给数据访问层传递要修改的数据对象
        /// </summary>
        /// <param name="mt">要修改的数据对象</param>
        /// <returns>影响行数是否大于0</returns>
        public bool Edit(MemberType mt)
        {
            return mtDal.Update(mt) > 0;
        }
        #endregion
        #region 给数据访问层传递要移除的数据
        /// <summary>
        /// 伪删除数据
        /// </summary>
        /// <param name="mt">要删除的对象</param>
        /// <returns>是否删除</returns>
        public bool Remove(MemberType mt)
        {
            return mtDal.Delete(mt) > 0;
        } 
        #endregion

    }
}
