using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Runtime.InteropServices;

namespace BetweenGameClient
{
    public partial class LoginForm : UserControl
    {
        public bool isLoggedIn { get; private set; }
        private MainForm mainForm;
        public HttpClient client;
        public LoginForm(MainForm form)
        {
            InitializeComponent();
            client = new HttpClient();
            mainForm = form;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            NativeMethods.SendMessage(txtUserName.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Email");
            NativeMethods.SendMessage(txtPassword.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Password");
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string requestUri = string.Format(Globals.URLWITHPORTNO + "/authenticateUser/");
            LoginRequest request = new LoginRequest { email = txtUserName.Text, password = txtPassword.Text };
            string loginrequest = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            HttpContent content = new StringContent(loginrequest, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            LoginResponse loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(responseString);
            if (!loginResponse.UserExist)
            {
                MessageBox.Show("Invalid Username or Password", "Credentials",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!loginResponse.IsUserActive)
            {
                MessageBox.Show(loginResponse.UserName + "User is in-active. Please contact Adminstrator", "User Inactive", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                isLoggedIn = true;
                this.Visible = false;
                mainForm.ShowGameView(loginResponse);
            }
        }
    }

    class NativeMethods
    {
        public const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
    }
}
