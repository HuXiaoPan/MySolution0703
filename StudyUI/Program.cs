using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();  //登录窗口
            if (FrmLogin.isPass == true)    //判断是否登录成功
            {
                Application.Run(new FrmMain()); //运行主窗口
            }
            //Application.Run(new FrmMemberInfo());
        }
    }
}
