using LordCardShop.Controller;
using LordCardShop.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTb.Text;
            string email = emailTb.Text;
            string password = passwordTb.Text;
            string gender = genderDdl.Text;
            string confirmationPass = confirmTb.Text;
            string dobStr = DobTb.Text;

            string errorMessage;
            bool addUserRes = RegisterController.AddUser(username, email, password, gender, confirmationPass, dobStr, out errorMessage);
            if (addUserRes)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                messageLbl.Text = errorMessage;
            }
        }
    }
}