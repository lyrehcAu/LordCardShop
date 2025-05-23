using LordCardShop.Controller;
using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User loggedInUser = Session["User"] as User;
                bool isGuest = Session["IsGuest"] != null && (bool)Session["IsGuest"];

                if (loggedInUser != null) // Cek session
                {
                    welcomeLbl.Text = $"Welcome to Lord Card Shop {loggedInUser.UserName}!";
                }
                //else if (isGuest)
                //    welcomeLbl.Text = "Welcome to Lord Card Shop Guest!";
                //else
                {
                    // Kalo session kosong, coba dari Remember Cookie
                    HttpCookie rememberCookie = Request.Cookies["user_cookie"];
                    if (rememberCookie != null && !string.IsNullOrEmpty(rememberCookie["Username"]))
                    {
                        // Panggil Controller buat validasiin user dari cookie
                        string errorMessage;
                        bool cookieResponse = LoginController.ProcessRememberMeLogin(rememberCookie, out errorMessage);
                        if (cookieResponse)
                        {
                            User userFromSession = Session["User"] as User;
                            welcomeLbl.Text = $"Hello, welcome to Lord Card Shop {userFromSession.UserName}!";
                        }
                        else
                        {
                            // Cookie gk valid, hapus dan redirect ke Login
                            HttpCookie expiredCookie = new HttpCookie("user_cookie");
                            expiredCookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(expiredCookie);
                            Response.Redirect("Login.aspx");
                            return;
                        }
                    }
                    else
                    {
                        // kalo gk ada Session dan gk ada Remember Me cookie, redirect ke Login
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }
    }
}