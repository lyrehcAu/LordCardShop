using LordCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Master
{
    public partial class NavigationBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedInUser = Session["User"] as User;

            if (loggedInUser != null)
            {
                // User sudah login
                welcomeUserLbl.Text = $"{loggedInUser.UserName}";

                // Tampilkan navbar sesuai role
                if (loggedInUser.UserRole == "Admin")
                {
                    adminNavbar.Visible = true;
                    customerNavbar.Visible = false;
                }
                else if (loggedInUser.UserRole == "Customer")
                {
                    customerNavbar.Visible = true;
                    adminNavbar.Visible = false;
                }
                else
                {
                    // Default jika role tidak dikenali (misal, sembunyikan semua atau tampilkan guest)
                    customerNavbar.Visible = false;
                    adminNavbar.Visible = false;
                    welcomeUserLbl.Text = "Guest";
                }
            }
            else
            {
                // User belum login, tampilkan Guest dan sembunyikan semua navbar yang spesifik role
                welcomeUserLbl.Text = "Guest";
                customerNavbar.Visible = false;
                adminNavbar.Visible = false;

                // Anda bisa tambahkan link Login/Register di sini jika tidak ada di setiap Panel navbar
                // Atau biarkan mereka di halaman login sebagai entry point
            }
        }

        
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string searchTerm = searchTb.Text;
            User loggedInUser = Session["User"] as User;
            string redirectUrl = "";

            if (loggedInUser != null)
            {
                if (loggedInUser.UserRole == "Admin")
                {
                    // Admin: Redirect ke Manage Card dengan parameter search
                    redirectUrl = $"~/Views/ManageCard.aspx?search={HttpUtility.UrlEncode(searchTerm)}";
                }
                else if (loggedInUser.UserRole == "Customer")
                {
                    // Customer: Redirect ke Order Card dengan parameter search
                    redirectUrl = $"~/Views/OrderCard.aspx?search={HttpUtility.UrlEncode(searchTerm)}";
                }
                else
                {
                    // Fallback jika role tidak dikenali
                    redirectUrl = "~/Views/Home.aspx";
                }
            }
            else
            {
                // Jika belum login, redirect ke Home atau Login
                redirectUrl = "~/Views/Home.aspx"; // Atau Login.aspx
            }

            Response.Redirect(redirectUrl);
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            // Bersihkan Session
            Session.Clear();
            Session.Abandon();

            // Hapus Remember Me cookie
            if (Request.Cookies["user_cookie"] != null)
            {
                HttpCookie expiredCookie = new HttpCookie("user_cookie");
                expiredCookie.Expires = DateTime.Now.AddDays(-1); // Langsung kadaluarsa
                Response.Cookies.Add(expiredCookie);
            }

            // Redirect ke halaman Login
            Response.Redirect("Login.aspx"); // Sesuaikan path jika berbeda
        }
    }
}