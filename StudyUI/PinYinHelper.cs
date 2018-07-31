using Microsoft.International.Converters.PinYinConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyUI
{
    public partial class PinYinHelper
    {
        #region 得到字符串的拼音缩写
        /// <summary>
        /// 输入字符串得到拼音首字母
        /// </summary>
        /// <param name="tarStr">目标字符串</param>
        /// <returns>得到的拼音首字母</returns>
        public static string GetPinYin(string tarStr)
        {
            string getStr = "";
            foreach (char c in tarStr)
            {
                try
                {
                    ChineseChar cc = new ChineseChar(c);
                    getStr += cc.Pinyins[0][0];
                }
                catch
                {

                }
            }
            return getStr;
        } 
        #endregion
    }
}
