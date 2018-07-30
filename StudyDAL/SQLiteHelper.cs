using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDAL
{
    public static class SQLiteHelper
    {

        #region 变量定义
        private static string connStr = ConnectionStringHelper.GetSqliteConnectionString(); //得到连接字符串
        #endregion

        #region 执行并返回影响行数
        /// <summary>
        /// 执行Sqlite脚本并返回影响行数
        /// </summary>
        /// <param name="sqlText">要执行的脚本</param>
        /// <param name="parameters">对应的参数</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(string sqlText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))   //新建连接
            {
                using (SQLiteCommand cmd = conn.CreateCommand())    //新建指令
                {
                    conn.Open();    //打开连接
                    cmd.CommandText = sqlText;  //设定脚本
                    cmd.Parameters.AddRange(parameters);    //添加参数
                    return cmd.ExecuteNonQuery();   //执行
                }
            }
        }//End:ExecuteNonQuery 
        #endregion

        #region 执行并返回第一行第一列的值
        /// <summary>
        /// 执行Sqlite脚本并返回第一行第一列
        /// </summary>
        /// <param name="sqlText">要执行的脚本</param>
        /// <param name="parameters">对应的参数</param>
        /// <returns>第一行第一列的值</returns>
        public static Object ExcuteScalar(string sqlText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))   //建立连接
            {
                using (SQLiteCommand cmd = conn.CreateCommand())    //建立命令
                {
                    conn.Open();    //打开连接
                    cmd.CommandText = sqlText;  //定义语句
                    cmd.Parameters.AddRange(parameters);    //添加参数
                    return cmd.ExecuteScalar(); //执行
                }
            }
        }//End:ExcuteScalar 
        #endregion

        #region 执行并返回填充好的脚本
        /// <summary>
        /// 执行Sqlite脚本并返回数据表
        /// </summary>
        /// <param name="sqlText">要执行的脚本</param>
        /// <param name="parameters">对应的参数</param>
        /// <returns>填充好的数据表</returns>
        public static DataTable ExecuteDataTable(string sqlText, params SQLiteParameter[] parameters)
        {
            //using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlText, ConnectionStringHelper.GetSqliteConnectionString()))
            //{
            //    DataTable dt = new DataTable();
            //    adapter.Fill(dt);
            //    return dt;
            //}

            using (SQLiteConnection conn = new SQLiteConnection(connStr))   //建立连接
            {
                using (SQLiteCommand cmd = conn.CreateCommand())    //建立命令
                {
                    conn.Open();    //打开连接
                    cmd.CommandText = sqlText;  //定义语句
                    cmd.Parameters.AddRange(parameters);    //添加参数
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))  //建立适配器
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);   //适配器填充数据表
                        return dt;
                    }
                }
            }
        }//End:ExecuteDataTable 
        #endregion

        #region 执行并返回数据库指针
        /// <summary>
        /// 执行Sqlite脚本并返回指针
        /// </summary>
        /// <param name="sqlText">要执行的脚本</param>
        /// <param name="parameters">对应的参数</param>
        /// <returns>数据库的指针</returns>
        public static SQLiteDataReader ExecuteReader(string sqlText, params SQLiteParameter[] parameters)
        {
            SQLiteConnection conn = new SQLiteConnection(connStr);  //建立连接
            SQLiteCommand cmd = conn.CreateCommand();               //建立命令
            conn.Open();                                            //打开连接
            cmd.CommandText = sqlText;                              //定义语句
            cmd.Parameters.AddRange(parameters);                    //添加参数
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);  //执行，如果关闭执行，同时就关闭连接
        }//End:ExecuteReader 
        #endregion
    }
}