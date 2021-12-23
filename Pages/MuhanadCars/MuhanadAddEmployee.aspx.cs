using Cars_System.App_Code;
using System;

namespace Cars_System.Pages.MuhanadCars
{
    public partial class MuhanadAddEmployee : System.Web.UI.Page
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
                            int roleid = userController.roleid;
                            switch (roleid)
                            {

                                case 1:
                                    GetRoles();
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

        protected void AddUserbtn_Click(object sender, EventArgs e)
        {
            string firstname = Fnametxt.Text;
            string lastname = Lnametxt.Text;
            int role = int.Parse(rolesdropdown.SelectedItem.Value);
            string email = useremail.Text;
            string password = userpass.Text;
            string confirmpassword = cpassword.Value;
            string phone = Phonenumtxt.Text;
            string dateofbirth = Dob.Text;
            int CompanyID = 1;
            int Attempts = 0;
            bool Islocked = false;
            if (firstname != null && lastname != null && role != 0 && email != null && password != null && cpassword != null && phone != null)
            {
                if (password == confirmpassword)
                { //do code here
                    RegisterClass registerClass = new RegisterClass();
                    if (registerClass.AddUser(firstname, lastname, role, email, password, phone, dateofbirth, CompanyID, Attempts, Islocked) == "Success")
                    {
                        Response.Redirect("/ListMuhanadEmployees");

                    }

                }
                else
                {

                }

            }

        }
        public void GetRoles()
        {
            RolesClass rolesClass = new RolesClass();
            rolesdropdown.DataSource = rolesClass.getallroles();
            rolesdropdown.DataTextField = "Rolename";
            rolesdropdown.DataValueField = "RoleID";
            rolesdropdown.DataBind();
        }
    }
}