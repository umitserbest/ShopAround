<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ShopAroundWeb.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">	

	<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Profile</h1>
        <div class="btn-toolbar mb-2 mb-md-0">
         <%-- <div class="btn-group mr-2">
            <button type="button" class="btn btn-sm btn-outline-secondary">Share</button>
            <button type="button" class="btn btn-sm btn-outline-secondary">Export</button>
          </div>
          <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
            <span data-feather="calendar"></span>
            This week
          </button>--%>
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
		 <%-- <form class="needs-validation" novalidate>--%>
			
			  <div class="mb-3">
				<label for="shopName">Shop Name</label>
				<asp:TextBox ID="txtShopName" CssClass="form-control" runat="server"></asp:TextBox>
				<%--<input type="text" class="form-control shopName" id="shopName" placeholder="Shop name" required>--%>
			  </div>

			<div class="mb-3">
			  <label for="email">Email <%--<span class="text-muted">(Optional)</span>--%></label>
			  <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email" ReadOnly="True"></asp:TextBox>
			  <%--<input type="email" class="form-control" id="email" placeholder="Your e-mail address" required>--%>			  
			</div>

			<div class="mb-3">
				<label for="password">Password</label>
				<asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
				<%--<input type="password" class="form-control" id="password" placeholder="New password">--%>
			</div>			

			<div class="mb-3">
			  <label for="address">Address</label>
				<asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
			  <%--<input type="text" class="form-control" id="address" placeholder="Your address" required>--%>
			  <%--<div class="invalid-feedback">
				Please enter your shipping address.
			  </div>--%>
			</div>

			<div class="row">
			  <div class="col-md-5 mb-3">
				<label for="city">City</label>
				<asp:DropDownList ID="ddlCity" CssClass="custom-select d-block w-100" runat="server"></asp:DropDownList>
				<%--<select class="custom-select d-block w-100" id="city" required>
				  <option class="hidden" selected disabled>City *</option>
				  <option>Eskişehir</option>
                  <option>İstanbul</option>
                  <option>Ankara</option>				  
				</select>--%>
			  </div>			 
			</div>

			<div class="mb-3">
				<label for="phone">Phone</label>
				<asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" TextMode="Phone"></asp:TextBox>
				<%--<input type="text" class="form-control" id="phone" placeholder="Your phone" required>--%>
			  </div>

			  <div class="mb-3">
				<label for="about">About</label>
				<asp:TextBox ID="txtAbout" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
				<%--<textarea class="form-control" id="about" rows="3" placeholder="About you"></textarea>--%>
			  </div>

			<%--<hr class="mb-4">
			<div class="custom-control custom-checkbox">
			  <input type="checkbox" class="custom-control-input" id="same-address">
			  <label class="custom-control-label" for="same-address">Shipping address is the same as my billing address</label>
			</div>
			<div class="custom-control custom-checkbox">
			  <input type="checkbox" class="custom-control-input" id="save-info">
			  <label class="custom-control-label" for="save-info">Save this information for next time</label>
			</div>
			<hr class="mb-4">--%>

        
			<hr class="mb-4">
			<asp:Button ID="btnSave" CssClass="btn btn-primary btn-md btn-block" runat="server" Text="Save" OnClick="btnSave_Click" />
			<%--<button class="btn btn-primary btn-md btn-block btnSave" type="submit"><span data-feather="save"></span> Save</button>--%>

		    <br /><br />

		  <%--</form>--%>
		</div>
  </div>		    

    </main>

</asp:Content>