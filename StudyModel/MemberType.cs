using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyModel
{
    /// <summary>
    /// 会员类型类
    /// </summary>
    public partial class MemberType
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int MId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MTitle { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal MDiscount { get; set; }
    }
}
