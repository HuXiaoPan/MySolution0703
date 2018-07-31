using Microsoft.International.Converters.PinYinConverter;
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
    public partial class FrmDishInfo : Form
    {
        #region 定义变量
        DishInfoBll diBll = new DishInfoBll();  //业务逻辑层实例
        #endregion
        private FrmDishInfo()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = false;
        }

        #region 单例模式
        private static FrmDishInfo _FrmDishInfo { get; set; }   //保存实例
        /// <summary>
        /// 单例模式中静态实例本类对象
        /// </summary>
        /// <returns>实例的对象</returns>
        public static FrmDishInfo CreateFrm()
        {
            if (_FrmDishInfo == null)   //判断是否已经实例对象
            {
                _FrmDishInfo = new FrmDishInfo();
            }
            return _FrmDishInfo;    //返回
        }

        private void FrmDishInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _FrmDishInfo = null;    //关闭窗口后释放实例资源
        }
        #endregion

        #region 窗口读取事件
        private void FrmDishInfo_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }
        #endregion

        #region 封装方法
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dic">增加的条件</param>
        private void LoadList()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();  //空字典
            if (!txtTitleSearch.Text.Equals(""))    //如果名称不为空添加搜索条件
            {
                dic.Add("DTitle", txtTitleSearch.Text);
            }
            if (ddlTypeSearch.SelectedValue.ToString() != "0")  //如果查询组合框选择不为0
            {
                dic.Add("DTypeId", ddlTypeSearch.SelectedValue.ToString());
            }
            dgvList.DataSource = diBll.GetList(dic);    //绑定数据
        }

        /// <summary>
        /// 下拉菜单读取数据
        /// </summary>
        private void LoadTypeList()
        {
            DishTypeBll dtBll = new DishTypeBll();  //菜品类型的业务逻辑层实例

            #region 查询Combox读取
            List<DishType> ListDt = dtBll.GetList();    //得到菜品类型集合
            ListDt.Insert(0, new DishType() { DTypeTitle = "全部" }); //增加全部选单
            ddlTypeSearch.DataSource = ListDt;  //绑定数据
            ddlTypeSearch.DisplayMember = "DTypeTitle"; //展示数据
            ddlTypeSearch.ValueMember = "DId";  //实际数据 
            #endregion

            #region 添加combox读取
            ddlTypeAdd.DataSource = dtBll.GetList();
            ddlTypeAdd.DisplayMember = "DTypeTitle";
            ddlTypeAdd.ValueMember = "DId";
            ddlTypeAdd.SelectedIndex = 0;
            #endregion
        }

        /// <summary>
        /// 重置控件数据
        /// </summary>
        private void ResetCom()
        {
            txtId.Text = "添加时无编号";  //控件复位
            txtTitleSave.Clear();
            ddlTypeAdd.SelectedIndex = 0;
            txtPrice.Clear();
            txtChar.Clear();
            btnSave.Text = "添加";
        }
        #endregion

        #region 菜品类型点击事件
        private void btnAddType_Click(object sender, EventArgs e)
        {
            FrmDishType Frmdt = FrmDishType.CreateFrm();    //实例
            Frmdt.ShowDialog(); //模态显示
            Frmdt.Focus();  //焦点
            if (Frmdt.DialogResult == DialogResult.OK)
            {
                LoadList();
                LoadTypeList();
            }
        }
        #endregion

        #region 菜名搜索改变事件
        private void txtTitleSearch_TextChanged(object sender, EventArgs e)
        {
            LoadList();
        }
        #endregion

        #region 下拉菜单改变事件
        private void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }
        #endregion

        #region 显示全部点击事件
        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Clear();
            ddlTypeSearch.SelectedIndex = 0;
        }
        #endregion

        #region 数据网格双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dgvList.Rows[e.RowIndex];
            DataGridViewRow row = dgvList.SelectedRows[0];  //控件获取数据
            txtId.Text = row.Cells[0].Value.ToString();
            txtTitleSave.Text = row.Cells[1].Value.ToString();
            ddlTypeAdd.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            txtChar.Text = row.Cells[4].Value.ToString();
            btnSave.Text = "修改";
        }
        #endregion

        #region 添加修改点击事件
        private void btnSave_Click(object sender, EventArgs e)
        {
            DishInfo di = new DishInfo()    //构造对象
            {
                DTitle = txtTitleSave.Text,
                DChar = txtChar.Text,
                DPrice = Convert.ToDecimal(txtPrice.Text),
                DTypeId = Convert.ToInt32(ddlTypeAdd.SelectedValue)
            };
            if (btnSave.Text == "添加")   //添加逻辑
            {
                if (diBll.Add(di))
                {
                    LoadList();
                    LoadTypeList();
                    ResetCom();
                }
                else
                {
                    MessageBox.Show("添加失败，请重试！", "提示");
                }
            }
            else    //修改逻辑
            {
                di.DId = Convert.ToInt32(txtId.Text);
                if (diBll.Edit(di))
                {
                    LoadList();
                    LoadTypeList();
                    ResetCom();
                }
                else
                {
                    MessageBox.Show("添加失败，请重试！", "提示");
                }
            }
        }
        #endregion

        #region 取消点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadList();
            LoadTypeList();
            ResetCom();
        }
        #endregion

        #region 菜名变更得到事件
        private void txtTitleSave_TextChanged(object sender, EventArgs e)
        {
            txtChar.Text = PinYinHelper.GetPinYin(txtTitleSave.Text);
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals("添加时无编号"))
            {
                MessageBox.Show("请双击要删除的数据", "提示");
                return;
            }
            DishInfo di = new DishInfo()    //构造对象
            {
                DId = Convert.ToInt32(txtId.Text),
                DTitle = txtTitleSave.Text,
                DChar = txtChar.Text,
                DPrice = Convert.ToDecimal(txtPrice.Text),
                DTypeId = Convert.ToInt32(ddlTypeAdd.SelectedValue)
            };
            if (diBll.Remove(di))
            {
                LoadList();
                LoadTypeList();
                ResetCom();
            }
        }
    }
}
