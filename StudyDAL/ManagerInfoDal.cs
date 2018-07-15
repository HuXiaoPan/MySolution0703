using StudyCommon;
using StudyModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
        #region 数据库的读取操作
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
        #endregion
        #region 数据库的插入操作
        /// <summary>
        /// 向数据库中插入管理者数据
        /// </summary>
        /// <param name="mi">管理者数据对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(ManagerInfo mi)
        {
            string sql = "insert into ManagerInfo(mname,mpwd,mtype) values (@mname,@mpwd,@mtype)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@mname",mi.MName),
                new SQLiteParameter("@mpwd",MD5Helper.EncryptString(mi.MPwd)),
                new SQLiteParameter("@mtype",mi.MType)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion
        #region 数据库的修改操作
        /// <summary>
        /// 更新数据库的管理者数据
        /// </summary>
        /// <param name="mi">要修改的管理者对象</param>
        /// <returns>影响的行数</returns>
        public int Update(ManagerInfo mi)
        {
            string sql = "update ManagerInfo set mname=@name,mpwd=@pwd,mtype=@type where mid=@id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@name",mi.MName),
                new SQLiteParameter("@pwd",mi.MPwd),
                new SQLiteParameter("@type",mi.MType),
                new SQLiteParameter("@id",mi.MId)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);
        } 
        #endregion
    }
}
