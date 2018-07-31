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
    public partial class DishTypeDal
    {
        #region 读取数据库
        /// <summary>
        /// 读取数据库
        /// </summary>
        /// <returns>对象集合</returns>
        public List<DishType> GetList()
        {
            List<DishType> ListDt = new List<DishType>();   //建立对象集合
            string sql = "select * From DishTypeInfo Where DIsDelete = 0";  //语句
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);  //得到数据表
            foreach (DataRow row in dt.Rows)    //数据表转成对象集合
            {
                ListDt.Add(new DishType()
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTypeTitle = row["DTitle"].ToString()
                });
            }
            return ListDt;
        }
        #endregion

        #region 数据库添加
        /// <summary>
        /// 数据库添加操作
        /// </summary>
        /// <param name="dt">要添加的数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(DishType dt)
        {
            string sql = "Insert into DishTypeInfo(DTitle,DIsDelete) values(@Title,0)"; //语句
            SQLiteParameter p = new SQLiteParameter("@Title", dt.DTypeTitle);   //参数
            return SQLiteHelper.ExecuteNonQuery(sql, p);    //执行
        }
        #endregion

        #region 数据库修改
        /// <summary>
        /// 数据库修改
        /// </summary>
        /// <param name="dt">要修改的数据对象</param>
        /// <returns>影响的行数</returns>
        public int Update(DishType dt)
        {
            string sql = "Update DishTypeInfo set DTitle=@Title Where DId=@Id"; //脚本
            SQLiteParameter[] ps =  //参数
            {
                new SQLiteParameter("@Title",dt.DTypeTitle),
                new SQLiteParameter("@Id",dt.DId)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);   //执行
        }
        #endregion

        #region 数据库伪删除
        /// <summary>
        /// 数据库伪删除
        /// </summary>
        /// <param name="dt">要删除的数据</param>
        /// <returns>影响行数</returns>
        public int Drop(DishType dt)
        {
            string sql = "Update DishTypeInfo set DIsDelete=1 Where DId=@Id";   //脚本
            SQLiteParameter p = new SQLiteParameter("@Id", dt.DId); //参数
            return SQLiteHelper.ExecuteNonQuery(sql, p);    //执行
        } 
        #endregion
    }
}
