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
    public partial class MemberTypeDal
    {
        #region 读取数据
        /// <summary>
        /// 读取数据库标记未删除的数据
        /// </summary>
        /// <returns>数据对象集和</returns>
        public List<MemberType> GetList()
        {
            List<MemberType> memberTypeList = new List<MemberType>();
            string sql = "select * from MemberTypeInfo where MIsDelete = 0";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                MemberType mt = new MemberType()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MTitle = row["MTitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["MDiscount"])
                };
                memberTypeList.Add(mt);
            }
            return memberTypeList;
        }
        #endregion
        #region 插入操作
        /// <summary>
        /// 数据库插入
        /// </summary>
        /// <param name="mt">要插入的数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(MemberType mt)
        {
            string sql = "insert into MemberTypeInfo (MTitle,MDiscount,MIsDelete) values(@Title,@Discount,0)";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@Title",mt.MTitle),
                new SQLiteParameter("@Discount",mt.MDiscount),
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion
        #region 修改数据
        /// <summary>
        /// 数据库修改
        /// </summary>
        /// <param name="mt">修改的数据对象</param>
        /// <returns>影响行数</returns>
        public int Update(MemberType mt)
        {
            string sql = "update MemberTypeInfo set MTitle=@Title,MDiscount=@Discount where MId=@Id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@Title",mt.MTitle),
                new SQLiteParameter("@Discount",mt.MDiscount),
                new SQLiteParameter("@Id",mt.MId)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion
        #region 数据伪删除
        /// <summary>
        /// 伪删除数据
        /// </summary>
        /// <param name="mt">要删除的数据对象</param>
        /// <returns>影响的行数</returns>
        public int Delete(MemberType mt)
        {
            string sql = "Update MemberTypeInfo set MIsDelete=1 where MId=@Id";
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@Id",mt.MId)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);
        } 
        #endregion

    }
}
