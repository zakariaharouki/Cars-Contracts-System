using Cars_System.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cars_System.Pages.LuxuryCars
{
    public partial class LuxuryAddCars : System.Web.UI.Page
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
                            Response.Redirect("/GoldenHome");
                            break;
                        case 3:
                            break;
                        case 4:
                            //GetCurrencies();
                            Response.Redirect("/RuknHome");
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

            int contractnew = GetHighestContract();
            string Carname = Carnametxt.Text;
            string Buyername = Purchasernametxt.Text;
            string contractnumber = (contractnew + 1).ToString();
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
            Response.Redirect("/Muhanadhome");
        }
        protected int GetHighestContract()
        {
            UserController userController = new UserController();
            string userid = (String)Session["UserID"];
            userController.GetUserInfoUsingUserId(userid);
            int CompanyID = userController.CompanyID;
            Cars cars = new Cars();
            cars.getcontractnumber(CompanyID);
            int contractnum = cars.LatestContract;
            return contractnum;
        }
    }
}