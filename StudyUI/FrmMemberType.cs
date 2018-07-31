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
    public partial class FrmMemberType : Form
    {
        #region 定义变量
        MemberTypeBll mtBll = new MemberTypeBll();  //业务逻辑层实例
        DialogResult dr = DialogResult.Cancel;  //模态窗口的结果 
        #endregion
        private FrmMemberType()
        {
            InitializeComponent();
        }

        #region 单例模式
        /// <summary>
        /// 存储本窗口的实例
        /// </summary>
        private static FrmMemberType FrmMT { get; set; }
        /// <summary>
        /// 创造本类实例的方法
        /// </summary>
        /// <returns>唯一的一个实例</returns>
        public static FrmMemberType CreateFrm()
        {
            if (FrmMT == null)  //如果字段中没有对象，就实例一个
            {
                FrmMT = new FrmMemberType();
            }
            return FrmMT;
        }
        private void FrmMemberType_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMT = null;   //关闭时释放窗口资源
            this.DialogResult = dr; //给模态窗口结果
        } 
        #endregion

        #region 界面初始化
        private void FrmMemberType_Load(object sender, EventArgs e)
        {
            LoadList();
        } 
        #endregion

        #region 封装方法
        /// <summary>
        /// 读取数据
        /// </summary>
        private void LoadList()
        {
            dgvMemberType.AutoGenerateColumns = false;
            dgvMemberType.DataSource = mtBll.Getlist();
        }
        /// <summary>
        /// 控制面板复位
        /// </summary>
        private void resetForm()    //控件还原默认值
        {
            tbId.Text = "添加时无编号";
            tbTitle.Clear();
            tbDiscount.Clear();
            btnSave.Text = "添加";
        }
        #endregion

        #region 添加或修改事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbId.Text.Equals("添加时无编号")) //添加
            {
                MemberType mt = new MemberType()    //根据空间得到新数据对象
                {
                    MTitle = tbTitle.Text,
                    MDiscount = Convert.ToDecimal(tbDiscount.Text)
                };
                if (mtBll.addData(mt))  //添加成功刷新
                {
                    LoadList();
                    dr = DialogResult.OK;   //模态窗口结果
                }
                else
                {
                    MessageBox.Show("添加失败！","提示");
                }
            }
            else    //修改
            {
                MemberType mt = new MemberType()    //和添加差不多
                {
                    MId = Convert.ToInt32(tbId.Text),
                    MTitle = tbTitle.Text,
                    MDiscount = Convert.ToDecimal(tbDiscount.Text)
                };
                if(mtBll.Edit(mt))
                {
                    LoadList();
                    dr = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            resetForm();    //复位控件
        } 
        #endregion

        #region 取消事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetForm();    //复位控件
        }
        #endregion

        #region 双击数据表事件
        private void dgvMemberType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectRow = dgvMemberType.Rows[e.RowIndex]; //根据所选行给控件赋值
            tbId.Text = selectRow.Cells["MId"].Value.ToString();
            tbTitle.Text = selectRow.Cells["MTitle"].Value.ToString();
            tbDiscount.Text = selectRow.Cells["MDiscount"].Value.ToString();
            btnSave.Text = "修改";
        }
        #endregion

        #region 点击删除事件
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbId.Text.Equals("添加时无编号")) //没选择不删除，并提示
            {
                MessageBox.Show("请双击要删除的数据！","提示");
                return;
            }
            else
            {
                MemberType mt = new MemberType()    //根据控件信息构造数据实例
                {
                    MId = Convert.ToInt32(tbId.Text),
                    MTitle = tbTitle.Text,
                    MDiscount = Convert.ToDecimal(tbDiscount.Text)
                };
                if (mtBll.Remove(mt))   //如果移除成功，刷新
                {
                    LoadList();
                    resetForm();
                    dr = DialogResult.OK;   //模态窗口结果
                }
                else
                {
                    MessageBox.Show("删除失败！","提示");
                }
            }

        }
        #endregion


    }
}
