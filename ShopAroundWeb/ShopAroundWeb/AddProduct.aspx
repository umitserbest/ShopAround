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
				<asp:TextBox ID="txtProductCode" CssClass="form-control" runat="server"></asp:TextBox>
				<%--<input type="text" class="form-control shopName" id="productCode" placeholder="Product Code" required>--%>
			  </div>

			  <div class="mb-3">
				<label for="productName">Product Name</label>
				  <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>
				<%--<input type="text" class="form-control shopName" id="productName" placeholder="Product Name" required>--%>
			  </div>

			<div class="row">
			  <div class="col-md-5 mb-3">
				<label for="category">Category</label>
				<asp:DropDownList ID="ddlCategory" CssClass="custom-select d-block w-100" runat="server"></asp:DropDownList>
				<%--<select class="custom-select d-block w-100" id="category" required>
				  <option class="hidden" selected disabled>Category</option>
				  <option>Clothes</option>
                  <option>Shoes</option>
                  <option>Watches</option>				  
				</select>--%>
			  </div>			 
			</div>

			<div class="mb-3">
				<label for="productName">Combine Image</label>
			    <asp:FileUpload ID="fuCombineImage" runat="server" />
			</div>

			<div class="mb-3">
				<label for="productName">Cover Image</label>
			     <asp:FileUpload ID="fuCoverImage" runat="server" />
			</div>

			<div class="mb-3">
				<label for="productName">1st Image</label>
			    <asp:FileUpload ID="fuImage2" runat="server" />
			</div>

			<div class="mb-3">
				<label for="productName">2nd Image</label>
				<asp:FileUpload ID="fuImage3" runat="server" />
			</div>

			<div class="mb-3">
				<label for="productName">3rd Image</label>
			    <asp:FileUpload ID="fuImage4" runat="server" />
			</div>
						

			<div class="mb-3">
			  <label for="brand">Brand</label>
				<asp:TextBox ID="txtBrand" CssClass="form-control" runat="server"></asp:TextBox>
			  <%--<input type="text" class="form-control" id="brand" placeholder="Brand">--%>			  
			</div>	

			<div class="mb-3">
			  <label for="color">Color</label>
				<asp:TextBox ID="txtColor" CssClass="form-control" runat="server"></asp:TextBox>
			  <%--<input type="text" class="form-control" id="color" placeholder="Color" required>--%>			  
			</div>

			<div class="mb-3">
				<label for="size">Size</label>
				<asp:TextBox ID="txtSize" CssClass="form-control" runat="server"></asp:TextBox>
				<%--<input type="text" class="form-control" id="size" placeholder="Size" required>--%>
			</div>			
			
			<div class="mb-3">
				<label for="material">Material</label>
				<asp:TextBox ID="txtMaterial" CssClass="form-control" runat="server"></asp:TextBox>
				<%--<input type="text" class="form-control" id="material" placeholder="Material" required>--%>
			</div>	

			  <div class="mb-3">
				<label for="details">Details</label>
				  <asp:TextBox ID="txtDetails" CssClass="form-control" runat="server"></asp:TextBox>
				<%--<textarea class="form-control" id="details" rows="3" placeholder="Details"></textarea>--%>
			  </div>			
        
			<hr class="mb-4">
			<%--<button class="btn btn-primary btn-md btn-block btnSave" type="submit"><span data-feather="save"></span> Save</button>--%>
				<asp:Button ID="btnSave" CssClass="btn btn-primary btn-md btn-block" runat="server" Text="Save" OnClick="btnSave_Click" />

		    <br /><br />

		</div>
  </div>

		    

    </main>
		 

</asp:Content>