using LordCardShop.Controller;
using LordCardShop.Handler;
using LordCardShop.Model;
using LordCardShop.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    Response.Redirect("Home.aspx");
                    return;
                }
                // kalo gk ada Session, cek Remember Me cookie
                HttpCookie rememberCookie = Request.Cookies["user_cookie"];
                string errorMessage;
                bool loginSuccess = LoginController.ProcessRememberMeLogin(rememberCookie, out errorMessage);
                if (loginSuccess)
                {
                    // User sudah disimpan di session dalam controller
                    Response.Redirect("Home.aspx");
                    return;
                }
                else
                {
                    // jika gagal login otomatis, hapus cookie yang tidak valid
                    if (rememberCookie != null)
                    {
                        HttpCookie expiredCookie = new HttpCookie("user_cookie");
                        expiredCookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(expiredCookie);
                    }

                    messageLbl.Text = errorMessage;
                }
            }
        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTb.Text;
            string password = passwordTb.Text;
            bool rememberMe = rememberCb.Checked;

            string errorMessage;
            bool loginResult = LoginController.AttemptLogin(username, password, out errorMessage);

            if (loginResult)
            {
                User loggedInUser = (User)Session["User"];

                if (rememberMe)
                {
                    HttpCookie userCookie = new HttpCookie("user_cookie");
                    userCookie["Username"] = username;
                    userCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(userCookie);
                }
                else
                {
                    // kalo "Remember Me" gk dicentang, pastiin cookie dihapus kalo ada
                    if (Request.Cookies["user_cookie"] != null)
                    {
                        HttpCookie expiredCookie = new HttpCookie("user_cookie");
                        expiredCookie.Expires = DateTime.Now.AddDays(-1); // Langsung basi
                        Response.Cookies.Add(expiredCookie);
                    }
                }

                Response.Redirect("Home.aspx");
            }
            else
            {
                messageLbl.Text = errorMessage;
            }
        }

        //protected void asGuestLBtn_Click(object sender, EventArgs e)
        //{
        //    // Set session untuk menandai bahwa ini adalah Guest
        //    Session["IsGuest"] = true;
        //    // Clear Session["User"] jika ada (mungkin user sebelumnya gagal login atau apa)
        //    Session["User"] = null;
        //    // Hapus cookie "Remember Me" jika ada
        //    if (Request.Cookies["user_cookie"] != null)
        //    {
        //        HttpCookie expiredCookie = new HttpCookie("user_cookie");
        //        expiredCookie.Expires = DateTime.Now.AddDays(-1);
        //        Response.Cookies.Add(expiredCookie);
        //    }
        //    // Redirect ke halaman Home
        //    Response.Redirect("Home.aspx");
        //}
    }
}