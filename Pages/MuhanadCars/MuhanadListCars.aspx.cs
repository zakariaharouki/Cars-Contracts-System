using Cars_System.App_Code;
using System;
using System.Web.UI.WebControls;
using Spire.Pdf;
using Spire.Pdf.Widget;
using Aspose.Pdf.Forms;
using Spire.Pdf.Fields;

namespace Cars_System.Pages.MuhanadCars
{
    public partial class MuhanadListCars : System.Web.UI.Page
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
                            GetCars();
                            break;
                        case 2:
                            Response.Redirect("/Goldenhome");
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

        protected void Editbtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int CarID = int.Parse(btn.CommandArgument);
            Response.Redirect("MuhanadEditCar/" + CarID);
        }

        protected void Deletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int CarID = int.Parse(btn.CommandArgument);
            Cars cars = new Cars();
            cars.deletecar(CarID);
            Response.Redirect("/MuhanadListCars");
        }
        protected void GetCars()
        {
            Cars cars = new Cars();
            rptCars.DataSource = cars.getCarsMuhanad(); ;
            rptCars.DataBind();
        }


        protected void rptCars_DataBound(object sender, RepeaterItemEventArgs e)
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

        protected void Printbtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string CarID = (string)(btn.CommandArgument);
            Cars cars = new Cars();
            cars.getCarDeatils(CarID);
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"../../Assets/pdf/muhanadpdf.pdf");
            PdfFormWidget formWidget = doc.Form as PdfFormWidget;
            for (int i = 0; i < formWidget.FieldsWidget.List.Count; i++)
            {
                PdfField field = formWidget.FieldsWidget.List[i] as PdfField;
                if (field is PdfTextBoxFieldWidget)
                {
                    PdfTextBoxFieldWidget textBoxField = field as PdfTextBoxFieldWidget;
                    switch (textBoxField.Name)
                    {
                        case "Carname":
                            textBoxField.Text = cars.CarName;
                            break;
                        case "Buyername":
                            textBoxField.Text = cars.BuyerName;
                            break;
                        case "VIN":
                            textBoxField.Text = cars.VIN;
                            break;
                            case "CarID":
                            textBoxField.Text = CarID.ToString();
                                break;
                        case "CompanyID":
                            textBoxField.Text = cars.CompanyID;
                            break;
                        case "Date":
                            textBoxField.Text =cars.Date;
                            break;
                        case "Employeename":
                            textBoxField.Text = cars.EmployeeName;
                            break;
                        case "ContractNumber":
                            textBoxField.Text =cars.ContractNumber;
                            break;
                        case "TempCarNumber":
                            textBoxField.Text =cars.TempCarNumber;
                            break;
                       
                    }
                }
                //if (field is PdfListBoxWidgetFieldWidget)
                //{
                //    PdfListBoxWidgetFieldWidget listBoxField = field as PdfListBoxWidgetFieldWidget;
                //    switch (listBoxField.Name)
                //    {
                //        case "email_format":
                //            int[] index = { 1 };
                //            listBoxField.SelectedIndex = index;
                //            break;
                //    }
                //}

                //if (field is PdfComboBoxWidgetFieldWidget)
                //{
                //    PdfComboBoxWidgetFieldWidget comBoxField = field as PdfComboBoxWidgetFieldWidget;
                //    switch (comBoxField.Name)
                //    {
                //        case "title":
                //            int[] items = { 0 };
                //            comBoxField.SelectedIndex = items;
                //            break;
                //    }
                //}

                //if (field is PdfRadioButtonListFieldWidget)
                //{
                //    PdfRadioButtonListFieldWidget radioBtnField = field as PdfRadioButtonListFieldWidget;
                //    switch (radioBtnField.Name)
                //    {
                //        case "country":
                //            radioBtnField.SelectedIndex = 1;
                //            break;
                //    }
                //}

                //if (field is PdfCheckBoxWidgetFieldWidget)
                //{
                //    PdfCheckBoxWidgetFieldWidget checkBoxField = field as PdfCheckBoxWidgetFieldWidget;
                //    switch (checkBoxField.Name)
                //    {
                //        case "agreement_of_terms":
                //            checkBoxField.Checked = true;
                //            break;
                //    }
                //}
                //if (field is PdfButtonWidgetFieldWidget)
                //{
                //    PdfButtonWidgetFieldWidget btnField = field as PdfButtonWidgetFieldWidget;
                //    switch (btnField.Name)
                //    {
                //        case "submit":
                //            btnField.Text = "Submit";
                //            break;
                //    }
                //}
            }
            //doc.SaveToFile("C://Users//admin//source//repos//Cars System//Assets//pdf", FileFormat.PDF);
            doc.Print();


        }
    }
}
