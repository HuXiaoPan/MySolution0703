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
            string sql = "select * from ManagerInfo";   //语句
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);  //得到数据表
            List<ManagerInfo> List = new List<ManagerInfo>();   //对象清单
            foreach (DataRow row in dt.Rows)    //遍历数据表得到对象清单
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
            string sql = "insert into ManagerInfo(mname,mpwd,mtype) values (@mname,@mpwd,@mtype)";  //语句
            SQLiteParameter[] ps =  //参数
            {
                new SQLiteParameter("@mname",mi.MName),
                new SQLiteParameter("@mpwd",MD5Helper.EncryptString(mi.MPwd)),
                new SQLiteParameter("@mtype",mi.MType)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);       //返回操作行数
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
            List<SQLiteParameter> listPs = new List<SQLiteParameter>(); //可变参数集合
            listPs.Add(new SQLiteParameter("@name", mi.MName));         //用户名参数
            string sql = "update ManagerInfo set mname=@name";          //部分语句
            if (!mi.MPwd.Equals("不会是这个密码吧？"))                   //判断是否修改过密码
            {
                sql += ",mpwd = @pwd";                                  //拼接密码部分
                listPs.Add(new SQLiteParameter("@pwd", MD5Helper.EncryptString(mi.MPwd)));  //密码参数添加
            }
            sql += ",mtype=@type where mid=@id";    //添加尾部
            listPs.Add(new SQLiteParameter("@type", mi.MType));
            listPs.Add(new SQLiteParameter("@id", mi.MId));
            return SQLiteHelper.ExecuteNonQuery(sql, listPs.ToArray()); //执行
        }
        #endregion
        #region 数据库的删除操作
        /// <summary>
        /// 根据Id删除数据库数据
        /// </summary>
        /// <param name="id">要删除数据的id</param>
        /// <returns>影响的行数</returns>
        public int Delete(int id)
        {
            string sql = "delete from ManagerInfo where mid=@id";   //语句
            SQLiteParameter p = new SQLiteParameter("@id", id);     //参数
            return SQLiteHelper.ExecuteNonQuery(sql, p);            //操作
        }
        #endregion

        #region 登录信息
        /// <summary>
        /// 根据用户名找到数据
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <returns>第一个数据对象</returns>
        public ManagerInfo GetListByName(string UserName)
        {
            ManagerInfo mi = new ManagerInfo(); //新建数据对象
            string sql = "select * from managerInfo where mname=@name"; //语句
            SQLiteParameter p = new SQLiteParameter("@name", UserName); //参数
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, p);   //得到数据表
            if (dt.Rows.Count > 0)  //判断有没有数据，如果有，拿第一行
            {
                mi.MId = Convert.ToInt32(dt.Rows[0][0]);
                mi.MName = UserName;
                mi.MPwd = dt.Rows[0][2].ToString();
                mi.MType = Convert.ToInt32(dt.Rows[0][3]);
                return mi;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
