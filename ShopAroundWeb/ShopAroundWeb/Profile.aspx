<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ShopAroundWeb.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">	

	<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Profile</h1>
        <div class="btn-toolbar mb-2 mb-md-0"> 
        </div>
      </div>
		
		<asp:Panel ID="pnlError" runat="server">
			<div class="alert alert-danger alert-dismissible fade show" role="alert">
			  <strong>Failed!</strong> You should check the fields.
			  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
				<span aria-hidden="true">&times;</span>
			  </button>
			</div>
		</asp:Panel>

		<asp:Panel ID="pnlSuccessful" runat="server">
			<div class="alert alert-success alert-dismissible fade show" role="alert">
			  <strong>Successful!</strong> Information updated.
			  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
				<span aria-hidden="true">&times;</span>
			  </button>
			</div>
		</asp:Panel>
		
      <div class="row">    
		<div class="col-md-8 order-md-1">
		  <h4 class="mb-3">Update Your Information</h4>	
			
			  <div class="mb-3">
				<label for="shopName">Shop Name</label>
				<asp:TextBox ID="txtShopName" CssClass="form-control" runat="server"></asp:TextBox>			
			  </div>

			<div class="mb-3">
			  <label for="email">Email</label>
			  <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>			  
			</div>

			<div class="mb-3">
				<label for="password">Password</label>
				<asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>			
			</div>	
			
			<div class="mb-3">
			  <label for="address">Logo</label>
			  <asp:FileUpload ID="fuLogo" runat="server" />
			</div>

			<div class="mb-3">
			  <label for="address">Address</label>
				<asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>		
			</div>

			<div class="row">
			  <div class="col-md-5 mb-3">
				<label for="city">City</label>
				<asp:DropDownList ID="ddlCity" CssClass="custom-select d-block w-100" runat="server"></asp:DropDownList>		
			  </div>			 
			</div>

			<div class="mb-3">
				<label for="phone">Phone</label>
				<asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" TextMode="Phone"></asp:TextBox>			
			  </div>

			  <div class="mb-3">
				<label for="about">About</label>
				<asp:TextBox ID="txtAbout" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>		
			  </div>		
        
			<hr class="mb-4">
			<asp:Button ID="btnSave" CssClass="btn btn-primary btn-md btn-block" runat="server" Text="Save" OnClick="btnSave_Click" />	
		    <br /><br />
	
		</div>
  </div>		    

    </main>

</asp:Content>