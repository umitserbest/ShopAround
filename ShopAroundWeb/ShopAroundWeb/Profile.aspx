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
		
      <div class="row">    
		<div class="col-md-8 order-md-1">
		  <h4 class="mb-3">Update Your Information</h4>
		 <%-- <form class="needs-validation" novalidate>--%>
			
			  <div class="mb-3">
				<label for="shopName">Shop Name</label>
				<input type="text" class="form-control shopName" id="shopName" placeholder="Shop name" required>
			  </div>

			<div class="mb-3">
			  <label for="email">Email <%--<span class="text-muted">(Optional)</span>--%></label>
			  <input type="email" class="form-control" id="email" placeholder="Your e-mail address" required>			  
			</div>

			<div class="mb-3">
				<label for="password">Password</label>
				<input type="password" class="form-control" id="password" placeholder="New password">
			</div>			

			<div class="mb-3">
			  <label for="address">Address</label>
			  <input type="text" class="form-control" id="address" placeholder="Your address" required>
			  <div class="invalid-feedback">
				Please enter your shipping address.
			  </div>
			</div>

			<div class="row">
			  <div class="col-md-5 mb-3">
				<label for="city">City</label>
				<select class="custom-select d-block w-100" id="city" required>
				  <option class="hidden" selected disabled>City *</option>
				  <option>Eskişehir</option>
                  <option>İstanbul</option>
                  <option>Ankara</option>				  
				</select>
			  </div>			 
			</div>

			<div class="mb-3">
				<label for="phone">Phone</label>
				<input type="text" class="form-control" id="phone" placeholder="Your phone" required>
			  </div>

			  <div class="mb-3">
				<label for="about">About</label>
				<textarea class="form-control" id="about" rows="3" placeholder="About you"></textarea>
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
			<button class="btn btn-primary btn-md btn-block btnSave" type="submit"><span data-feather="save"></span> Save</button>

		    <br /><br />

		  <%--</form>--%>
		</div>
  </div>

		    <!-- Button trigger modal -->
			<button type="button" class="btn btn-primary btnSaved" data-toggle="modal" data-target="#exampleModal" style="display:none;">
			  Launch demo modal
			</button>

			<!-- Modal -->
			<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
			  <div class="modal-dialog" role="document">
				<div class="modal-content">
				  <div class="modal-header">
					<h5 class="modal-title" id="exampleModalLabel">Profile</h5>
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
					  <span aria-hidden="true">&times;</span>
					</button>
				  </div>
				  <div class="modal-body">
					Information saved.
				  </div>
				  <%--<div class="modal-footer">
					<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
					<button type="button" class="btn btn-primary">Save changes</button>
				  </div>--%>
				</div>
			  </div>
			</div>

    </main>

	    

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="js/profile.js"></script>

</asp:Content>