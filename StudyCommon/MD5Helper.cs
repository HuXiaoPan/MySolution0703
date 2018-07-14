using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudyCommon
{
    /// <summary>
    /// 对字符串进行MD5加密
    /// </summary>
    public partial class MD5Helper
    {
        /// <summary>
        /// 将字符串进行MD5加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string EncryptString(string str)
        {
            //创建md5对象
            MD5 md5 = MD5.Create();
            //将字符串转化成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            //对字节数组进行加密生成新的字节数组
            byte[] byteNew = md5.ComputeHash(byteOld);
            //将新的字节数组转换成字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                //每个字节恒站两位
                sb.Append(b.ToString("x2"));
            }
            //返回加密的字符串
            return sb.ToString();
        }
    }
}
