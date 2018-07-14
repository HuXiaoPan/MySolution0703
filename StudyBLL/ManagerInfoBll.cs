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
        /// <summary>
        /// 从数据访问层得到管理者数据集合
        /// </summary>
        /// <returns>管理者数据集合</returns>
        public List<ManagerInfo> GetList()
        {
            ManagerInfoDal miDal = new ManagerInfoDal();
            return miDal.GetList();
        }
    }
}
