using LordCardShop.Controller;
using LordCardShop.Model;
using LordCardShop.Module;
using LordCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LordCardShop.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User loggedInUser = Session["User"] as User;
            if (loggedInUser == null)
            {
                Response.Redirect("Login.aspx"); // Redirect ke Login jika belum login
                return;
            }

            if (!IsPostBack)
            {
                // Tampilkan data profil saat ini
                usernameTb.Text = loggedInUser.UserName;
                emailTb.Text = loggedInUser.UserEmail;

                // Set gender RadioButtonList
                if (loggedInUser.UserGender == "Male")
                {
                    genderDdl.SelectedValue = "Male";
                }
                else if (loggedInUser.UserGender == "Female")
                {
                    genderDdl.SelectedValue = "Female";
                }

                // Format tanggal lahir (pastikan sesuai format TextMode="Date")
                dobTb.Text = loggedInUser.UserDOB.ToString("yyyy-MM-dd"); // Format YYYY-MM-DD
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            User loggedInUser = Session["User"] as User;
            if (loggedInUser == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Ambil input dari form
            string newUsername = usernameTb.Text;
            string newEmail = emailTb.Text;
            string newGender = genderDdl.SelectedValue; // Akan kosong jika tidak dipilih
            string newDobStr = dobTb.Text;
            string oldPassword = oldPasswordTb.Text;
            string newPassword = newPasswordTb.Text;
            string confirmationPass = confirmPasswordTb.Text;

            // Panggil ProfileController untuk memperbarui profil
            string errorMessage;
            bool updateSuccess = ProfileController.UpdateProfile(loggedInUser.UserId, newUsername, newEmail, loggedInUser.UserPassword, newGender, oldPassword, newPassword, confirmationPass, newDobStr, out errorMessage);

            if (updateSuccess)
            {
                // Perbarui objek User di Session dengan data terbaru
                User updatedUser = UserRepository.GetUserById(loggedInUser.UserId);
                Session["User"] = updatedUser;

                messageLbl.Text = "Profile updated successfully!";
                messageLbl.ForeColor = System.Drawing.Color.Green;

                // Kosongkan field password setelah berhasil update
                oldPasswordTb.Text = "";
                newPasswordTb.Text = "";
                confirmPasswordTb.Text = "";
            }
            else
                messageLbl.Text = errorMessage;
        }
    }
}