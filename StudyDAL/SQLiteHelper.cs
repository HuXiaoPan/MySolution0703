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
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string connStr = ConnectionStringHelper.GetSqliteConnectionString();

        #region 执行并返回影响行数
        /// <summary>
        /// 执行Sqlite脚本并返回影响行数
        /// </summary>
        /// <param name="sqlText">要执行的脚本</param>
        /// <param name="parameters">对应的参数</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteNonQuery(string sqlText, params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
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
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
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

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
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
            SQLiteConnection conn = new SQLiteConnection(connStr);
            SQLiteCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sqlText;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }//End:ExecuteReader 
        #endregion
    }
}