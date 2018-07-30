using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyModel
{
    public partial class MemberInfo
    {
        public int MId { get; set; }
        public string MTypeTitle { get; set; }
        public string  MName { get; set; }
        public string MPhone { get; set; }
        public decimal MMoney { get; set; }
        public int MTypeId { get; set; }
    }
}
