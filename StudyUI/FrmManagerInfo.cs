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
        #region 定义变量
        ManagerInfoBll miBll = new ManagerInfoBll();    //业务逻辑层实例
        #endregion

        private FrmManagerInfo()    //默认构造方法私有化，不能new对象
        {
            InitializeComponent();
        }
        #region 单例
        private static FrmManagerInfo _fromMi { get; set; } //用来存储单例出来的对象
        /// <summary>
        /// 单例模式下的对象创造方法
        /// </summary>
        /// <returns>实例的对象</returns>
        public static FrmManagerInfo CreateForm()
        {
            if (_fromMi == null)    //如果属性没有实例，才创造实例
            {
                _fromMi = new FrmManagerInfo();
            }
            return _fromMi;
        }
        private void FrmManagerInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _fromMi = null; //窗口关闭时清空实例
        }
        #endregion
        #region 初始化窗口事件
        private void FrmManagerInfo_Load(object sender, EventArgs e)
        {
            LoadList();
        } 
        #endregion
        #region 保存按钮点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            ManagerInfo mi = new ManagerInfo()  //根据控件数据实例数据对象
            {
                MName = tbName.Text,
                MPwd = tbPwd.Text,
                MType = rb1.Checked ? 1 : 0
            };

            if(btnSave.Text.Equals("添加"))   //添加状态
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
            else    //修改状态
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
            if (e.ColumnIndex == 2) //列索引为2的时候，显示相应的文字
            {
                e.Value = Convert.ToInt32(e.Value) == 1 ? "经理" : "员工";
            }
        }
        #endregion
        #region 双击dgv行的事件
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) //行索引小于0没反应
            {
                return;
            }
            DataGridViewRow row = dgvList.Rows[e.RowIndex]; //双击选择的行
            tbId.Text = row.Cells[0].Value.ToString();  //根据行数据给控件赋值
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
        private void btnCancel_Click(object sender, EventArgs e)    //所有控件恢复默认值
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
            if (dgvList.SelectedRows.Count <= 0)    //没选择就不删除，并提醒
            {
                MessageBox.Show("请选择要删除的数据！");
                return;
            }
            if (miBll.Remove(int.Parse(dgvList.SelectedRows[0].Cells[0].Value.ToString()))) //删除成功重新读取
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
            dgvList.AutoGenerateColumns = false;    //不自动新建行
            dgvList.DataSource = miBll.GetList();   //绑定业务逻辑层返回的数据集合
            dgvList.ClearSelection();   //清空选择
        }
        #endregion


    }
}
