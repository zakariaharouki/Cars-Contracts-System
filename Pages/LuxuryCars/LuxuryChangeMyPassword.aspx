<%@ Page Title="" Language="C#" MasterPageFile="~/LuxurySite.Master" AutoEventWireup="true" CodeBehind="LuxuryChangeMyPassword.aspx.cs" Inherits="Cars_System.Pages.LuxuryCars.LuxuryChangeMyPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card">
        <div class=" card-header">
            <h1>Change My Password</h1>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-3">
                    <h3><label style="font-family:'Helvetica';font-size: large;">Old Password </label></h3>
                </div>
            <div class="col-3">
                  <asp:TextBox CssClass="form-control" TextMode="Password" placeholder="Old Password" runat="server" ID="Oldpasstxt"/>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-3">
                    <h3><label style="font-family:'Helvetica';font-size: large;">New Password </label></h3>
                </div>
            <div class="col-3">
                  <asp:TextBox CssClass="form-control" TextMode="Password" placeholder="New Password" runat="server" ID="Newpasstxt"/>
                </div>
            </div>
            <hr />
                 <div class="row">
                <div class="col-3">
                    <h3><label style="font-family:'Helvetica'; font-size: large;">Confirm Password </label></h3>
                </div>
            <div class="col-3">
                 <%-- <input runat="server" class="form-control" type="password" placeholder="Confirm Password"  id="Cpasstxt" name="Cpasstxt" />--%>
                <input id="Cpasstxt" name="Cpasstxt" type="password"  placeholder="Confirm Password" runat="server" class="form-control" onkeyup="disablebtn()" />
                    <label id="message"></label>    
            </div>
            </div>
            <br />
            <div class="row">
                <div class="col-3">
                    <asp:Button runat="server" Width="250" ID="Changepassbtn" OnClick="Changepassbtn_Click" Text="Change Password" CssClass="btn btn-primary"  />
                    </div>
            </div>
            <hr />
        </div>
    </div>
      <%--  <asp:CompareValidator ID="CompareValidator1" runat="server"   
            ControlToCompare="Cpasstxt" ControlToValidate="Newpasstxt"   
            ErrorMessage="Password Mismatch"  ForeColor="Red" SetFocusOnError="true"></asp:CompareValidator>  --%>

    <script type="text/javascript">
        function disablebtn() {
            if (document.getElementById('<%=Newpasstxt.ClientID%>').value ==
                document.getElementById('<%=Cpasstxt.ClientID%>').value) {
                document.getElementById('message').style.color = 'green';
                document.getElementById('message').innerHTML = 'matching';
                var btn = document.getElementById("<%=Changepassbtn.ClientID%>");
                btn.disabled = false;
                <%--document.getEelementById('<%=saveResto.ClientID%>').disabled = false;--%>

            } else {
                document.getElementById('message').style.color = 'red';
                document.getElementById('txtCPass').style.borderColor = 'red';
                document.getElementById('message').innerHTML = 'not matching';
                var btn = document.getElementById("<%=Changepassbtn.ClientID%>");
                btn.disabled = true;
                <%--document.getEelementById('<%=saveResto.ClientID%>').disabled = true;--%>
            }
        }
    </script>
</asp:Content>
