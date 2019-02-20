<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ShopAroundWeb.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Add Product</h1>
        <div class="btn-toolbar mb-2 mb-md-0">     
        </div>
      </div>
		
      <div class="row">    
		<div class="col-md-8 order-md-1">
		  <h4 class="mb-3">Create Your New Product</h4>
			
			<div class="mb-3">
				<label for="productCode">Product Code</label>
				<input type="text" class="form-control shopName" id="productCode" placeholder="Product Code" required>
			  </div>

			  <div class="mb-3">
				<label for="productName">Product Name</label>
				<input type="text" class="form-control shopName" id="productName" placeholder="Product Name" required>
			  </div>

			<div class="row">
			  <div class="col-md-5 mb-3">
				<label for="category">Category</label>
				<select class="custom-select d-block w-100" id="category" required>
				  <option class="hidden" selected disabled>Category</option>
				  <option>Clothes</option>
                  <option>Shoes</option>
                  <option>Watches</option>				  
				</select>
			  </div>			 
			</div>

			<div class="mb-3">
				<div class="custom-file">
				  <input type="file" class="custom-file-input" id="combineImage">
				  <label class="custom-file-label" for="customFile">Combine Image</label>
				</div>
				<span class="badge badge-success combineImageNotification">Saved</span>
			</div>

			<div class="mb-3">
				<div class="custom-file">
				  <input type="file" class="custom-file-input" id="coverImage">
				  <label class="custom-file-label" for="customFile">Cover Image</label>
				</div>
				<span class="badge badge-success coverImageNotification">Saved</span>
			</div>

			<div class="mb-3">
				<div class="custom-file">
				  <input type="file" class="custom-file-input" id="secondImage">
				  <label class="custom-file-label" for="customFile">2nd Image</label>
				</div>
				<span class="badge badge-success secondImageNotification">Saved</span>
			</div>

			<div class="mb-3">
				<div class="custom-file">
				  <input type="file" class="custom-file-input" id="thirdImage">
				  <label class="custom-file-label" for="customFile">3rd Image</label>
				</div>
				<span class="badge badge-success thirdImageNotification">Saved</span>
			</div>

			<div class="mb-3">
				<div class="custom-file">
				  <input type="file" class="custom-file-input" id="fourthImage">
				  <label class="custom-file-label" for="customFile">4th Image</label>
				</div>
				<span class="badge badge-success fourthImageNotification">Saved</span>
			</div>

			<div class="mb-3">
			  <label for="brand">Brand</label>
			  <input type="text" class="form-control" id="brand" placeholder="Brand">			  
			</div>	

			<div class="mb-3">
			  <label for="color">Color</label>
			  <input type="text" class="form-control" id="color" placeholder="Color" required>			  
			</div>

			<div class="mb-3">
				<label for="size">Size</label>
				<input type="text" class="form-control" id="size" placeholder="Size" required>
			</div>			
			
			<div class="mb-3">
				<label for="material">Material</label>
				<input type="text" class="form-control" id="material" placeholder="Material" required>
			</div>	

			  <div class="mb-3">
				<label for="details">Details</label>
				<textarea class="form-control" id="details" rows="3" placeholder="Details"></textarea>
			  </div>			
        
			<hr class="mb-4">
			<button class="btn btn-primary btn-md btn-block btnSave" type="submit"><span data-feather="save"></span> Save</button>

		    <br /><br />

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
	<script src="js/addproduct.js"></script>

</asp:Content>
