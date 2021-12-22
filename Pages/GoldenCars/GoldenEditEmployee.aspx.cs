using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cars_System.App_Code;

namespace Cars_System.Pages.GoldenCars
{
    public partial class GoldenEditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    UserController userController = new UserController();
                    string userid = (String)Session["UserID"];
                    userController.GetUserInfoUsingUserId(userid);
                    switch (userController.CompanyID)
                    {
                        case 1:
                            Response.Redirect("/Muhanadhome");
                            break;
                        case 2:
                            switch (userController.roleid)
                            {
                                case 1:
                                    GetRoles();
                                    getEmployee();
                                    break;
                                case 2:
                                    Response.Redirect("/Goldenhome");
                                    break;
                                    case -1:
                                    Response.Redirect("/Goldenhome");
                                    break;
                            }
                                

                            break;
                        case 3:
                            Response.Redirect("/Luxuryhome");
                            break;
                        case 4:
                            Response.Redirect("/Ruknhome");
                            break;

                    }

                }
                else
                {
                    Response.Redirect("/Login");
                }

            }

        }
        protected void getEmployee()
        {
            string userid = (string)(this.RouteData.Values["ID"]);
            UserController userController = new UserController();
            userController.getuserdetails(int.Parse(userid));
            Fnametxt.Text = userController.Fname;
            Lnametxt.Text = userController.Lname;
            useremail.Text = userController.Email;
            DateTime dateTime = DateTime.Parse(userController.Dob);
            Dob.Text = dateTime.ToString("yyyy-MM-dd");
            Phonenumtxt.Text = userController.PhoneNumber;
            string role = userController.roleid.ToString();
            rolesdropdown.Items.FindByValue(role).Selected = true;


        }

        protected void EditUserbtn_Click(object sender, EventArgs e)
        {
            UserController userController=new UserController();
            string ID=(this.RouteData.Values["ID"]).ToString();
            string FirstName = Fnametxt.Text;
            string LastName = Lnametxt.Text;
            string Email = useremail.Text;
            string Phone = Phonenumtxt.Text;
            string dateofbirth = Dob.Text;
            int role = int.Parse(rolesdropdown.SelectedItem.Value);
            userController.UpdateUser(FirstName, LastName, Phone,Email, role, dateofbirth, int.Parse(ID));
            Response.Redirect("/ListGoldenEmployees");
        }
        protected void GetRoles()
        {
            RolesClass rolesClass = new RolesClass();
            rolesdropdown.DataSource = rolesClass.getallroles();
            rolesdropdown.DataTextField = "Rolename";
            rolesdropdown.DataValueField = "RoleID";
            rolesdropdown.DataBind();
        }
       

    }
}