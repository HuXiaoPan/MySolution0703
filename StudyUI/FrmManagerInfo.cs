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

        #region 初始化窗口事件
        private void FrmManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        } 
        #endregion
        #region 保存按钮点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()
            {
                MName = tbName.Text,
                MPwd = tbPwd.Text,
                MType = rb1.Checked ? 1 : 0
            };

            if(btnSave.Text.Equals("添加"))
            {
                #region 添加操作
                if (miBll.add(mi))
                {
                    LoadList();
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后重试！");
                }
                #endregion
            }
            else
            {
                #region 修改操作
                mi.MId = Convert.ToInt32(tbId.Text);
                if (miBll.edit(mi))
                {
                    LoadList();
                }

                #endregion
            }
            

            tbName.Clear();
            tbPwd.Clear();
            tbId.Text = "添加时无编号";
            rb2.Checked = true;
            btnSave.Text = "添加";
        }
        #endregion
        #region 格式化dgv值的事件
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
        #region 双击dgv行的事件
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            tbId.Text = row.Cells[0].Value.ToString();
            tbName.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("1"))
            {
                rb1.Checked = true;
            }
            else
            {
                rb2.Checked = true;
            }
            tbPwd.Text = "不会是这个密码吧？";
            btnSave.Text = "修改";
        }
        #endregion
        #region 取消按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbId.Text = tbId.Text = "添加时无编号";
            tbName.Clear();
            tbPwd.Clear();
            rb1.Checked = true;
            btnSave.Text = "添加";
        }
        #endregion
        #region 点击删除按钮事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要删除的数据！");
                return;
            }
            if (miBll.Remove(int.Parse(dgvList.SelectedRows[0].Cells[0].Value.ToString())))
            {
                LoadList();
            }
        }
        #endregion
        #region 封装方法
        /// <summary>
        /// 从业务逻辑层中得到管理者数据集合，并将视图绑定到显示控件上
        /// </summary>
        private void LoadList()
        {
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = miBll.GetList();
            dgvList.ClearSelection();
        }

        #endregion
    }
}
