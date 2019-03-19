<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopAroundWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/login.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container register">
                <div class="row">
                    <div class="col-md-3 register-left">
                        <img src="img/hanger.png" alt=""/>
                        <h3>Welcome</h3>
                        <p>You are 30 seconds away from earning your own money!</p>
						<a href="/Register" class="registerLink">Register</a><br/>
                        <%--<input type="submit" class="navigateRegister" name="" value="Register"/><br/>--%>
                    </div>
                    <div class="col-md-9 register-right">                        
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                <h3 class="register-heading">Connect to Your Shop</h3>
                                <div class="row register-form">
                                    <div class="col-md-12">
                                        <div class="form-group">
											<asp:TextBox ID="txtEmail" CssClass="form-control email" placeholder="Email" runat="server" TextMode="Email"></asp:TextBox>
                                            <%--<input type="email" class="form-control email" placeholder="Your Email *" value="" />--%>
                                        </div>                                       
                                        <div class="form-group">
											<asp:TextBox ID="txtPassword" CssClass="form-control email" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <%--<input type="password" class="form-control password" placeholder="Password *" value="" />--%>
                                        </div>                    
										<asp:Button ID="btnLogin" CssClass="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                        <%--<input type="submit" class="btnLogin" value="Login"/>--%>                                     
                                    </div>                                   
                                </div>
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>

	<%--<script src="js/login.js"></script>--%>

</asp:Content>