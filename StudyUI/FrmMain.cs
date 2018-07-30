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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            this.Tag = FrmLogin.type;   //根据登录类型获得登陆者权限标记
            InitializeComponent();
        }

        #region 退出程序
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); //应用程序关闭
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //应用程序关闭
        }
        #endregion

        #region 权限控制
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.Tag) == 0) //登录类型是员工
            {
                menuManagerInfo.Visible = false;//不显示管理者选项
            }
        }
        #endregion

        #region 管理者餐单
        private void menuManagerInfo_Click(object sender, EventArgs e)
        {
            FrmManagerInfo frmMi = FrmManagerInfo.CreateForm(); //单例模式实例化对象
            frmMi.Show();
            frmMi.Focus();
        }
        #endregion

        #region 会员餐单
        private void menuMemberInfo_Click(object sender, EventArgs e)
        {
            FrmMemberInfo FrmMemberInfo = FrmMemberInfo.CreateFrmMi();
            FrmMemberInfo.Show();
            FrmMemberInfo.Focus();
        } 
        #endregion
    }
}
