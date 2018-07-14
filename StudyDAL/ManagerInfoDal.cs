using StudyModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDAL
{
    /// <summary>
    /// 从数据库中读取管理者数据表
    /// </summary>
    public partial class ManagerInfoDal
    {
        /// <summary>
        /// 从数据库中通过sql语句得到管理者数据对象集合
        /// </summary>
        /// <returns>管理者数据对象集合</returns>
        public List<ManagerInfo> GetList()
        {
            string sql = "select * from ManagerInfo";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);
            List<ManagerInfo> List = new List<ManagerInfo>();
            foreach (DataRow row in dt.Rows)
            {
                List.Add(new ManagerInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPwd = row["mpwd"].ToString(),
                    MType = Convert.ToInt32(row["mtype"])
                });
            }//end;foreach
            return List;
        }
    }
}
