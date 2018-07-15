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
        ManagerInfoBll miBll = new ManagerInfoBll();
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
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.GetList();
        }

        #region 保存按钮点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()
            {
                MName = tbName.Text,
                MPwd = tbPwd.Text,
                MType = rb1.Checked ? 1 : 0
            };
            if (miBll.add(mi))
            {
                LoadList();
                tbName.Clear();
                tbPwd.Clear();
                rb2.Checked = true;
            }
            else
            {
                MessageBox.Show("添加失败，请稍后重试！");
            }
        }
        #endregion
        #region 格式化MType的值
        /// <summary>
        /// 格式化MType的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "经理" : "员工";
            }
        }
        #endregion

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
