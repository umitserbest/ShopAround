<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="EditDiscount.aspx.cs" Inherits="ShopAroundWeb.EditDiscount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Edit Discount</h1>
        <div class="btn-toolbar mb-2 mb-md-0">     
        </div>
      </div>
		
      <div class="row">    
		<div class="col-md-8 order-md-1">
		  <h4 class="mb-3">Edit Your Discount</h4>

			<asp:Panel ID="pnlError" runat="server">
				<div class="alert alert-danger alert-dismissible fade show" role="alert">
				  <strong>Failed!</strong> You should check the fields.
				  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				  </button>
				</div>
			</asp:Panel>			
            
			<div class="row">
			  <div class="col-md-5 mb-3">
				<label for="category">Product</label>
				<asp:DropDownList ID="ddlProduct" CssClass="custom-select d-block w-100" runat="server"></asp:DropDownList>
			  </div>			 
			</div>			

			  <div class="mb-3">
				<label for="productName">Details</label>
				  <asp:TextBox ID="txtDetails" CssClass="form-control" runat="server"></asp:TextBox>		
			  </div>

            <div class="mb-3">
				<label for="productName">Expiry Date & Time</label>
                <asp:Calendar ID="clndrExpiry" runat="server"></asp:Calendar>
				<asp:TextBox ID="txtTime" placeholder="Time (Hour)" CssClass="form-control" runat="server"></asp:TextBox>	
			</div>
        
			<hr class="mb-4">			
			<asp:Button ID="btnSave" CssClass="btn btn-primary btn-md btn-block" runat="server" Text="Save" OnClick="btnSave_Click" />
		    <br /><br />

		</div>
  </div>

		    

    </main>
		 

</asp:Content>