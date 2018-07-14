using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDAL
{
    /// <summary>
    /// 帮助获得数据库连接字符串
    /// </summary>
    class ConnectionStringHelper
    {
        /// <summary>
        /// 获得Sqlite连接字符串
        /// </summary>
        /// <returns>Sqlite连接字符串</returns>
        public static string GetSqliteConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }
    }
}
