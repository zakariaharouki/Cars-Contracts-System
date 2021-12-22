<%@ Page Title="" Language="C#" MasterPageFile="~/GoldenSite.Master" AutoEventWireup="true" CodeBehind="GoldenEditEmployee.aspx.cs" Inherits="Cars_System.Pages.GoldenCars.GoldenEditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left: 20px;">Edit Employee</h1>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-2">
                <label>First Name</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Fnametxt" CssClass=" form-control" placeholder="First Name" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Last Name</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Lnametxt" CssClass="form-control" placeholder="Last Name" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Email</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="useremail" CssClass=" form-control" placeholder="Email" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <label>Phone</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="Phonenumtxt" CssClass=" form-control" placeholder="Phone" />
            </div>
        </div>
        <br />
                <div class="row">
            <div class="col-2">
                <label>Role</label>
            </div>
            <div class="col-3">
                <asp:DropDownList runat="server" ID="rolesdropdown" CssClass=" form-control"/>
            </div>
        </div>
        <br />

                        <div class="row">
            <div class="col-2">
                <label>Date of Birth</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" TextMode="Date" ID="Dob" CssClass="form-control" ></asp:TextBox>
            </div>
        </div>
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
        <br />
    <%--    <div class="row">
            <div class="col-2">
                <label>Password</label>
            </div>
            <div class="col-3">
                <asp:TextBox runat="server" ID="userpass" TextMode="Password" CssClass=" form-control" placeholder="Password" />
            </div>
        </div>
        <br />
        <div class="row">
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
                <asp:Button runat="server" ID="EditUserbtn" CssClass="btn btn-primary" Text="Register" OnClick="EditUserbtn_Click" />
            </div>
            <label id="message"></label>

        </div>
    </div>
    
</asp:Content>
