using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cars_System.App_Code;

namespace Cars_System.Pages.GoldenCars
{
    public partial class GoldenListEmployees : System.Web.UI.Page
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
                            Response.Redirect("Muhanadhome");
                            break;
                        case 2:
                            switch (userController.roleid)
                            {
                                case 1:
                                    GetEmployees();
                                    break;
                                case 2:
                                    Response.Redirect("Goldenhome");
                                    break;
                            }
                            
                           
                            break;
                        case 3:
                            Response.Redirect("Luxuryhome");
                            break;
                        case 4:
                            Response.Redirect("Ruknhome");
                            break;

                    }
                }
                else
                {
                    Response.Redirect("/Login");
                }

            }
        }
        protected void GetEmployees()
        {
            UserController userController = new UserController();
            rptAccounts.DataSource = userController.getGoldenUsers();
            rptAccounts.DataBind();
        }
        public string GetRoleName(object sender)
        {
            string rolename = "";
            int Roleid = (int)sender;
            RolesClass rolesClass = new RolesClass();
            rolesClass.GetRoleName(Roleid);
            rolename = rolesClass.RoleName;
            return rolename;

        }

        protected void UnlockAccountbtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int UserID = int.Parse(btn.CommandArgument);
            UserController userController = new UserController();
            userController.UnlockAccount(UserID);
            Response.Redirect("/ListGoldenEmployees");

        }

        protected void Changepassbtn_Click(object sender, EventArgs e)
        {

        }

        protected void Editbtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int UserID = int.Parse(btn.CommandArgument);
            Response.Redirect("EditGoldenEmployees/" + UserID);
        }

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int UserID = int.Parse(btn.CommandArgument);
            UserController userController = new UserController();
            userController.deleteuser(UserID);
            Response.Redirect("/ListGoldenEmployees");

        }

        protected void rptAccounts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var editBtn = e.Item.FindControl("Editbtn");
                var Deletebtn = e.Item.FindControl("Deletebtn");
                //DO the check here 
                //7asab al result bit7out editBtn.Visible = true or false
                if (Session["UserID"] != null)
                {
                    UserController userController = new UserController();
                    string userid = (String)Session["UserID"];
                    userController.GetUserInfoUsingUserId(userid);
                    //int roleid = userController.roleid;
                    switch (userController.roleid)
                    {
                        case 1:
                            break;
                        case 2:
                            editBtn.Visible = false;
                            Deletebtn.Visible = false;
                            break;
                    }
                }
                else
                {
                    Response.Redirect("/Login");
                }
            }
        }
    }
}