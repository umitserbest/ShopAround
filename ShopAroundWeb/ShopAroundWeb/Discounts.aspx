<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Discounts.aspx.cs" Inherits="ShopAroundWeb.Discounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <link href="css/products.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Discounts</h1>
        <div class="btn-toolbar mb-2 mb-md-0">     
        </div>
      </div>
		
      <div class="row">
          
          <% try
              {
                  foreach (var discount in discounts)
                  { %>

                      <div class="col-md-3 col-sm-6">
                              <div class="product-grid2">
                                  <div class="product-image2">
                                      <a href="#">
                                          <img class="pic-1" src="img/hanger.png">
                                          <img class="pic-2" src="img/hanger.png">
                                      </a>
                                      <ul class="social">
                                          <li><a href="/EditDiscount?DiscountID=<%= discount.DiscountID %>" data-tip="Edit"><i class="fas fa-highlighter"></i></a></li>
                                      </ul>
                      
                                  </div>
                                  <div class="product-content">
                                      <h3 class="title"><a href="#"><%= discount.Details %></a></h3>                          
                                  </div>
                              </div>
                          </div>

          <%      }
              }
              catch (Exception)
              {

              } %>

       
            

	</div>

</main>

</asp:Content>