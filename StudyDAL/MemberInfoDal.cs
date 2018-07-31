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
    public partial class MemberInfoDal
    {
        #region 得到会员信息集合
        /// <summary>
        /// 从数据库中查询会员信息
        /// </summary>
        /// <param name="dic">传入的键值对</param>
        /// <returns>会员信息集合</returns>
        public List<MemberInfo> GetList(Dictionary<string, string> dic)
        {
            string sql = "select mi.*,mt.MTitle from MemberInfo as mi join MemberTypeInfo as mt on mi.MTypeId=mt.MId where mi.MIsDelete = 0 and mt.MIsDelete=0";   //语句
            if (dic.Count > 0)    //键值对内有值
            {
                foreach (KeyValuePair<string, string> pair in dic)
                {
                    sql += @" and mi." + pair.Key + " like '%" + pair.Value + "%'"; //拼接字符串
                }
            }
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql);  //得到数据表
            List<MemberInfo> list = new List<MemberInfo>(); //集合
            foreach (DataRow row in dt.Rows)    //遍历返回的表并添加
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["MId"]),
                    MMoney = Convert.ToDecimal(row["MMoney"]),
                    MName = row["MName"].ToString(),
                    MPhone = row["MPhone"].ToString(),
                    MTypeTitle = row["MTitle"].ToString()
                });
            }
            return list;
        }
        #endregion
        #region 添加会员信息
        /// <summary>
        /// 为会员信息数据库添加数据
        /// </summary>
        /// <param name="mi">要添加的数据对象</param>
        /// <returns>影响行数</returns>
        public int Insert(MemberInfo mi)
        {
            string sql = "insert into MemberInfo(MTypeId,MName,MPhone,MMoney,MIsDelete) Values(@MTypeId,@MName,@MPhone,@MMoney,0)"; //语句
            SQLiteParameter[] ps =  //参数
            {
                new SQLiteParameter("@MTypeId",mi.MTypeId),
                new SQLiteParameter("@MName",mi.MName),
                new SQLiteParameter("@MPhone",mi.MPhone),
                new SQLiteParameter("@MMoney",mi.MMoney)
            };
            return SQLiteHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion
        #region 修改会员信息
        /// <summary>
        /// 数据库修改会员信息
        /// </summary>
        /// <param name="mi">要修改的会员信息对象</param>
        /// <returns>影响行数</returns>
        public int Update(MemberInfo mi)
        {
            string sql = "Update MemberInfo set MTypeId = @TypeId,MName = @Name,MPhone = @Phone,MMoney = @Money Where MId = @Id";   //语句
            SQLiteParameter[] ps =
            {
                new SQLiteParameter("@TypeId",mi.MTypeId),
                new SQLiteParameter("@Name",mi.MName),
                new SQLiteParameter("@Phone",mi.MPhone),
                new SQLiteParameter("@Money",mi.MMoney),
                new SQLiteParameter("@Id",mi.MId)
            };  //参数
            return SQLiteHelper.ExecuteNonQuery(sql, ps);   //执行
        }
        #endregion
        #region 删除会员信息
        /// <summary>
        /// 数据库删除会员信息
        /// </summary>
        /// <param name="mi">要删除的会员对象</param>
        /// <returns>影像行数</returns>
        public int Drop(MemberInfo mi)
        {
            string sql = "Update MemberInfo set MIsDelete = 1 Where MId = @Id"; //语句
            SQLiteParameter p = new SQLiteParameter("@Id", mi.MId); //参数
            return SQLiteHelper.ExecuteNonQuery(sql, p);    //执行
        }
        #endregion
    }
}
