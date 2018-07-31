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
    public partial class FrmDishType : Form
    {
        private FrmDishType()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;    //不自动创建列
        }

        #region 单例模式
        private static FrmDishType _FrmDishType { get; set; }   //单例属性
        /// <summary>
        /// 实例窗体对象
        /// </summary>
        /// <returns>实例的对象</returns>
        public static FrmDishType CreateFrm()   //静态单例方法
        {
            if (_FrmDishType == null)
            {
                _FrmDishType = new FrmDishType();
            }
            return _FrmDishType;
        }
        private void FrmDishType_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmDishType = null;
            this.DialogResult = dr;
        }

        #endregion

        #region 定义变量
        DishTypeBll dtBll = new DishTypeBll();  //业务逻辑层实例
        DialogResult dr = DialogResult.Cancel;  //模态窗口结果变量
        #endregion

        #region 封装方法
        /// <summary>
        /// 读取数据
        /// </summary>
        private void LoadList()
        {
            dgvList.DataSource = dtBll.GetList();
        }
        /// <summary>
        /// 重置控件
        /// </summary>
        private void ResetCom()
        {
            txtId.Text = "添加时无编号";
            txtTitle.Clear();
            btnSave.Text = "添加";
        }
        #endregion

        #region 窗体读取事件
        private void FrmDishType_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        #endregion

        #region 添加修改点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            DishType dt = new DishType()
            {
                DTypeTitle = txtTitle.Text,
            };

            if (btnSave.Text.Equals("添加"))  //添加逻辑
            {
                if (dtBll.Add(dt))
                {
                    LoadList();
                    ResetCom();
                    dr = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("添加失败，请重试！", "提示");
                }
            }
            else        //修改逻辑
            {
                dt.DId = Convert.ToInt32(txtId.Text);   //要修改的数据ID
                if(dtBll.Edit(dt))  //修改刷新
                {
                    LoadList();
                    ResetCom();
                    dr = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("添加失败，请重试！", "提示");
                }
            }
        }
        #endregion

        #region 双击数据表视图事件
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgvList.SelectedRows[0];  //行
            txtId.Text = row.Cells["DId"].Value.ToString(); //组件赋值
            txtTitle.Text = row.Cells["DTitle"].Value.ToString();
            btnSave.Text = "修改";
        }
        #endregion

        #region 取消点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadList(); //重置界面
            ResetCom();
        }
        #endregion

        #region 点击删除事件
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals("添加时无编号"))    //判断是否选择数据
            {
                MessageBox.Show("请双击要删除的数据！", "提示");
                return;
            }
            DishType dt = new DishType()    //对象
            {
                DId = Convert.ToInt32(txtId.Text)
            };
            if (dtBll.Remove(dt))    //移除成功重置界面
            {
                LoadList();
                ResetCom();
                dr = DialogResult.OK;
            }
        } 
        #endregion
    }
}
