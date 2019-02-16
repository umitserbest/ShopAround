<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ShopAroundWeb.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/register.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container register">
                <div class="row">
                    <div class="col-md-3 register-left">
                        <img src="img/hanger.png" alt=""/>
                        <h3>Welcome</h3>
                        <p>You are 30 seconds away from earning your own money!</p>
                        <input type="submit" class="navigateLogin" name="" value="Login"/><br/>
                    </div>
                    <div class="col-md-9 register-right">                        
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                <h3 class="register-heading">Create a shop</h3>
                                <div class="row register-form">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <input type="text" class="form-control shopName" placeholder="Shop Name *" value="" />
                                        </div>                                       
                                        <div class="form-group">
                                            <input type="password" class="form-control password" placeholder="Password *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <input type="password" class="form-control"  placeholder="Confirm Password *" value="" />
                                        </div>                                     
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <input type="email" class="form-control email" placeholder="Your Email *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <input type="text" minlength="10" maxlength="10" name="txtEmpPhone" class="form-control phone" placeholder="Your Phone *" value="" />
                                        </div>
                                        <div class="form-group">
                                            <select class="form-control city">
                                                <option class="hidden"  selected disabled>City *</option>
                                                <option>Eskişehir</option>
                                                <option>İstanbul</option>
                                                <option>Ankara</option>
                                            </select>
                                        </div>                                       
                                        <input type="submit" class="btnRegister" value="Register"/>
                                    </div>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>

	    <script src="js/register.js"></script>

</asp:Content>