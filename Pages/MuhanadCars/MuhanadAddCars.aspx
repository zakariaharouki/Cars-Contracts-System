<%@ Page Title="" Language="C#" MasterPageFile="~/MuhanadSite.Master" AutoEventWireup="true" CodeBehind="MuhanadAddCars.aspx.cs" Inherits="Cars_System.Pages.MuhanadCars.MuhanadAddCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <h1 style="margin-left: 20px;">Add Employee</h1>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-2">
                <label>Car Name</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Carnametxt" CssClass=" form-control" placeholder="Car Name" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Buyer Name</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Purchasernametxt" CssClass="form-control" placeholder="Buyer Name" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Contract Number</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="contractnumtxt" CssClass=" form-control" placeholder="Contract Number"/>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Temporary Car Number</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Tempcarnumtxt" CssClass=" form-control" placeholder="Temporary Car Number" />
            </div>
        </div>
        <br />   
        <div class="row">
            <div class="col-2">
                <label>Employee Name</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Employeenametxt" CssClass=" form-control" placeholder="Employee Name"/>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>VIN</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="vintxt" CssClass=" form-control" placeholder="VIN" />
            </div>
        </div>
        <br />
          <div class="row">
            <div class="col-2">
                <label>Date</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" TextMode="Date" ID="buydate" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
        <br />
         <%--  <br />
          <div class="row">
            <div class="col-2">
                <label>Turn Notifications On</label>
            </div>
         <div class="col-3">
               <label class="switch">
        <input runat="server" id="notifications" type="checkbox" checked>
     <span class="slider round"></span>
        </label>
            </div>
        </div>--%>
    <%--    <br />
        <div class="row">
            <div class="col-2">
                <label>Password</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="userpass" TextMode="Password" CssClass=" form-control" placeholder="Password" />
            </div>
        </div>--%>
 
     <%--   <div class="row">
            <div class="col-2">
                <label>Confirm Password</label>
            </div>
            <div class="col-3">
                <input runat="server" ID="cpassword" class=" form-control" placeholder="Confirm Password" type="password" onkeyup="passvalidate()"/>
            </div>
        </div>
        <br />--%>
        <div class="row">
            <div class="col-2"></div>
            <div class="col-3">
                <asp:Button runat="server" ID="AddCarbtn" CssClass="btn btn-primary" Text="Add Car" OnClick="AddCarbtn_Click" />
            </div>
            <label id="message"></label>

        </div>
    </div>

</asp:Content>
