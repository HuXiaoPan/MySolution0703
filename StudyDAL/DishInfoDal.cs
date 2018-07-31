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
    public partial class DishInfoDal
    {
        #region 数据库读取
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dic">添加的查找条件</param>
        /// <returns>数据集合</returns>
        public List<DishInfo> GetList(Dictionary<string, string> dic)
        {
            string sql = "select di.*,dt.DTitle as DTypeTitle from DishInfo as di inner join DishTypeInfo as dt on di.DTypeId=dt.DId where di.DIsDelete=0 and dt.DIsDelete=0"; //脚本
            List<SQLiteParameter> ListP = new List<SQLiteParameter>();  //参数集合
            if (dic.Count > 0)
            {
                foreach (KeyValuePair<string, string> KVPair in dic)    //分别向脚本和参数集合中添加新增条件
                {
                    sql += " and di." + KVPair.Key + " like @" + KVPair.Key;
                    ListP.Add(new SQLiteParameter("@" + KVPair.Key, "%" + KVPair.Value + "%"));
                }
            }
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, ListP.ToArray()); //得到数据表
            List<DishInfo> Listdi = new List<DishInfo>();   //新建数据集合
            foreach (DataRow row in dt.Rows)    //转成数据集合
            {
                Listdi.Add(new DishInfo()       //集合加对象
                {
                    DId = Convert.ToInt32(row["DId"]),
                    DTitle = row["DTitle"].ToString(),
                    DTypeId = Convert.ToInt32(row["DTypeId"]),
                    DTypeTitle = row["DTypeTitle"].ToString(),
                    DChar = row["DChar"].ToString(),
                    DPrice = Convert.ToDecimal(row["DPrice"])
                });
            }
            return Listdi;  //返回

        }
        #endregion

        #region 数据库添加
        /// <summary>
        /// 数据库添加
        /// </summary>
        /// <param name="di">要添加的对象</param>
        /// <returns>影响行数</returns>
        public int Insert(DishInfo di)
        {
            string sql = "insert into DishInfo(DTitle,DTypeId,DPrice,DChar,DIsDelete) values(@Title,@TypeId,@Price,@DChar,0)";  //脚本
            SQLiteParameter[] ps =  //参数
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@TypeId",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@dchar",di.DChar),
                new SQLiteParameter("@id",di.DId)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);   //执行
        }
        #endregion

        #region 数据库修改
        /// <summary>
        /// 数据库修改
        /// </summary>
        /// <param name="di">要修改的对象</param>
        /// <returns>影响行数</returns>
        public int Update(DishInfo di)
        {
            string sql = "Update DishInfo set dtitle=@title,dtypeid=@dtypeid,dprice=@price,dchar=@dchar where did=@id"; //脚本
            SQLiteParameter[] ps =  //参数
            {
                new SQLiteParameter("@title",di.DTitle),
                new SQLiteParameter("@dtypeid",di.DTypeId),
                new SQLiteParameter("@price",di.DPrice),
                new SQLiteParameter("@dchar",di.DChar),
                new SQLiteParameter("@id",di.DId)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);   //执行
        }
        #endregion

        #region 数据库伪删除
        /// <summary>
        /// 数据库伪删除
        /// </summary>
        /// <param name="di">要删除的对象</param>
        /// <returns>影响行数</returns>
        public int Drop(DishInfo di)
        {
            string sql = "Update DishInfo set DIsDelete=1 where did=@id";   //脚本
            SQLiteParameter p = new SQLiteParameter("@id", di.DId); //参数
            return SQLiteHelper.ExecuteNonQuery(sql, p);    //执行
        }
        #endregion
    }
}
