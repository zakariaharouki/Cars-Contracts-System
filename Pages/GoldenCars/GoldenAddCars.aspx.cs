using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cars_System.App_Code;

namespace Cars_System.Pages.GoldenCars
{
    public partial class GoldenAddCars : System.Web.UI.Page
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
                            Response.Redirect("/Muhanadhome");
                            break;
                        case 2:
                           
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

        protected void AddCarbtn_Click(object sender, EventArgs e)
        {
            string Carname = Carnametxt.Text;
            string Buyername = Purchasernametxt.Text;
            string contractnumber = contractnumtxt.Text;
            string TempNumber = Tempcarnumtxt.Text;
            string Vin = vintxt.Text;
            string date = buydate.Text;
            string employeename = Employeenametxt.Text;
            UserController userController = new UserController();
            string Userid = (String)Session["UserID"];
            userController.GetUserInfoUsingUserId(Userid);
            int CompanyID = userController.CompanyID;
            Cars cars = new Cars();
            cars.InsertCar(Carname, Vin, TempNumber, Buyername, employeename, contractnumber, CompanyID, date);
            Response.Redirect("Goldenhome");
        }
    }
}