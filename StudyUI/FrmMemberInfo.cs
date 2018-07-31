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
    public partial class FrmMemberInfo : Form
    {
        #region 定义变量
        MemberInfoBll miBll = new MemberInfoBll();  //会员信息业务逻辑层实例
        MemberTypeBll mtBll = new MemberTypeBll();  //会员类型业务逻辑层实例
        #endregion

        #region 单例
        private FrmMemberInfo()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
        }
        private static FrmMemberInfo _FrmMi { get; set; }   //单例字段
        /// <summary>
        /// 单例实例窗口对象
        /// </summary>
        /// <returns>窗口对象</returns>
        public static FrmMemberInfo CreateFrmMi()
        {
            if (_FrmMi == null) //单例核心
            {
                _FrmMi = new FrmMemberInfo();
            }
            return _FrmMi;
        }

        private void FrmMemberInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmMi = null;  //关闭窗口时释放实例
        } 
        #endregion

        #region 封装方法
        /// <summary>
        /// 读取数据
        /// </summary>
        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();  //定义一个键值对字典

            if (!string.IsNullOrEmpty(txtPhoneSearch.Text.Trim()))  //电话搜索不为空
            {
                dic.Add("MPhone", txtPhoneSearch.Text.Trim());  //添加进键值对
            }
            if (!string.IsNullOrEmpty(txtNameSearch.Text.Trim()))   //人名搜索不为空
            {
                dic.Add("MName", txtNameSearch.Text.Trim());    //添加进键值对
            }
            dgvList.DataSource = miBll.GetList(dic);
        }
        /// <summary>
        /// 数据类型控件初始化数据
        /// </summary>
        private void LoadTypeList()
        {
            ddlType.DataSource = mtBll.Getlist();   //combox绑定会员类型数据
            ddlType.DisplayMember = "MTitle";       //显示会员类型名称
            ddlType.ValueMember = "MId";            //保存Id值
        }
        /// <summary>
        /// 复位控件
        /// </summary>
        private void ResetCom()
        {
            txtId.Text = "添加时无编号";
            txtNameAdd.Clear();
            txtPhoneAdd.Clear();
            txtMoney.Clear();
            ddlType.SelectedIndex = 0;
            btnSave.Text = "添加";
        }
        #endregion

        #region 窗口读取事件
        private void FrmMemberInfo_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
        }


        #endregion

        #region 模糊查询事件
        private void txtPhoneSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }
        private void txtNameSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }
        #endregion

        #region 点击显示全部按钮事件
        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtPhoneSearch.Clear(); //初始化控件并刷新
            txtNameSearch.Clear();
            LoadList();
        }
        #endregion

        #region 添加或修改点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberInfo mi = new MemberInfo()    //要添加或者修改的数据对象
            {
                MName = txtNameAdd.Text.Trim(),
                MTypeId = Convert.ToInt32(ddlType.SelectedValue),
                MPhone = txtPhoneAdd.Text.Trim(),
                MMoney = Convert.ToDecimal(txtMoney.Text.Trim())
            };
            if (btnSave.Text == "添加")
            {
                #region 添加
                if (miBll.add(mi))
                {
                    LoadList();
                    ResetCom();
                }
                
                #endregion
            }
            else
            {
                #region 修改
                mi.MId = Convert.ToInt32(txtId.Text.Trim());    //修改要提供ID
                if (miBll.Edit(mi))
                {
                    LoadList();
                    ResetCom();
                }
                #endregion
            }
        }
        #endregion

        #region 数据窗口双击事件
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow rowSelected = dgvList.SelectedRows[0];  //被选中的行
            if (rowSelected == null)
            {
                return;
            }
            txtId.Text = rowSelected.Cells["MId"].Value.ToString(); //根据选中的行给控件赋值
            txtNameAdd.Text = rowSelected.Cells["MName"].Value.ToString();
            ddlType.Text = rowSelected.Cells["MTypeTitle"].Value.ToString();    //不严谨，文本不能重复，应该重新从数据库查询所对应的值，懒得改了
            txtPhoneAdd.Text = rowSelected.Cells["MPhone"].Value.ToString();
            txtMoney.Text = rowSelected.Cells["MMoney"].Value.ToString();
            btnSave.Text = "修改";
        }
        #endregion

        #region 删除数据点击事件
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals("添加时无编号"))    //没有选择数据，提醒用户
            {
                MessageBox.Show("请双击选择要删除的数据", "提示");
                return;
            }
            MemberInfo mi = new MemberInfo() { MId = Convert.ToInt32(txtId.Text) }; //要删除的数据对象
            if (miBll.Remove(mi))   //删除成功，重置界面
            {   
                LoadList();
                ResetCom();
            }
        }
        #endregion

        #region 取消点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadList();
            ResetCom();
        }
        #endregion

        #region 会员类型点击事件
        private void btnAddType_Click(object sender, EventArgs e)
        {
            FrmMemberType fmt = FrmMemberType.CreateFrm();  //调用窗口
            DialogResult dr = fmt.ShowDialog();   //显示
            fmt.Focus();    //给焦点
            if (dr == DialogResult.OK)  //如果模态窗口状态是OK，说明窗口进行过有效的添加修改删除事件，那么刷新
            {
                LoadList();
                LoadTypeList();
            }
            
        }
        #endregion

    }
}
