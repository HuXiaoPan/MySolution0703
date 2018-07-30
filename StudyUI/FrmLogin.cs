using StudyBLL;
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
    public partial class FrmLogin : Form
    {
        #region 旧代码
        //private static FrmLogin _frmLogin { get; set; }
        //public static FrmLogin CreateLogin()
        //{
        //    if (_frmLogin == null)
        //    {
        //        _frmLogin = new FrmLogin();
        //    }
        //    return _frmLogin;
        //}

        //private FrmLogin()
        //{
        //    InitializeComponent();
        //} 
        #endregion
        public FrmLogin()
        {
            InitializeComponent();
        }
        #region 变量定义
        ManagerInfoBll miBll = new ManagerInfoBll();    //业务逻辑层对象
        public static bool isPass = false; //标记是否登录成功
        public static int type;   //标记主窗口显示类型
        #endregion
        #region 取消点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   //关闭程序
        }
        #endregion

        #region 登录点击事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = tbUserName.Text;
            string pwd = tbPwd.Text;
            if (tbPwd.Text == "" || tbUserName.Text == "")  //判断文本框是否为空
            {
                MessageBox.Show("用户名和密码不能为空！", "提示");
                return;
            }
            switch (miBll.Login(name, pwd, out type))   //调用业务逻辑层登录判断方法
            {
                case StudyModel.LoginStatus.OK: //登录成功
                    isPass = true;              //登录标记改变
                    this.Close();               //关闭登录界面
                    //FrmMain frmMain = new FrmMain();
                    //frmMain.Tag = type;
                    //frmMain.Show();
                    //this.Hide();
                    break;
                case StudyModel.LoginStatus.UserNameError:  //用户名错误
                    MessageBox.Show("用户名错误！", "提示");
                    break;
                case StudyModel.LoginStatus.PwdError:       //密码错误
                    MessageBox.Show("密码错误！", "提示");
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
