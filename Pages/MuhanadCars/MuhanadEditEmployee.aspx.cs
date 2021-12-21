using Cars_System.App_Code;
using System;

namespace Cars_System.Pages.MuhanadCars
{
    public partial class EditMuhanadEmployee : System.Web.UI.Page
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
                    //int roleid = userController.roleid;
                    switch (userController.CompanyID)
                    {
                        case 1:
                            UserController userController1 = new UserController();
                            userController1.GetUserInfoUsingUserId(userid);
                            switch (userController1.roleid)
                            {
                                case 1:
                                    GetRoles();
                                    GetEmployee();
                                    break;
                                case 2:
                                    Response.Redirect("Muhanadhome");
                                    break;
                            }
                            break;
                        case 2:
                            Response.Redirect("/Goldenhome");
                            break;
                        case 3:
                            Response.Redirect("/Luxuryhome");
                            break;
                        case 4:
                            //GetCurrencies();
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
        protected void GetRoles()
        {
            RolesClass rolesClass = new RolesClass();
            rolesdropdown.DataSource = rolesClass.getallroles();
            rolesdropdown.DataTextField = "Rolename";
            rolesdropdown.DataValueField = "RoleID";
            rolesdropdown.DataBind();
        }
        protected void GetEmployee()
        {
            string UserID = (string)this.RouteData.Values["ID"];
            UserController userController1 = new UserController();
            userController1.getuserdetails(int.Parse(UserID));
            Fnametxt.Text = userController1.Fname;
            Lnametxt.Text = userController1.Lname;
            Phonenumtxt.Text = userController1.PhoneNumber;
            useremail.Text = userController1.Email;
            DateTime da = DateTime.Parse(userController1.Dob);
            Dob.Text = da.ToString("yyyy-MM-dd");
            string role = userController1.roleid.ToString();
            rolesdropdown.Items.FindByValue(role).Selected = true;

        }

        protected void EditEmployee_Click(object sender, EventArgs e)
        {
            UserController userController = new UserController();
            string fname = Fnametxt.Text;
            string lname = Lnametxt.Text;
            string email = useremail.Text;
            string phone = Phonenumtxt.Text;
            string dateofbirth = Dob.Text;
            string UserID = (string)this.RouteData.Values["ID"];
            int role = int.Parse(rolesdropdown.SelectedItem.Value);
            userController.UpdateUser(fname, lname, phone, email, role, dateofbirth, int.Parse(UserID));
            Response.Redirect("/ListMuhanadEmployees");
        }
    }
}