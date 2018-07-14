using StudyBLL;
using StudyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyUI
{
    public partial class FrmManagerInfo : Form
    {
        public FrmManagerInfo()
        {
            InitializeComponent();
        }

        private void FrmManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        /// <summary>
        /// 从业务逻辑层中得到管理者数据集合，并将视图绑定到显示控件上
        /// </summary>
        private void LoadList()
        {
            ManagerInfoBll miBll = new ManagerInfoBll();
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.GetList();
        }
    }
}
