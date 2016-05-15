<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="foodista.aspx.cs" Inherits="WebApplication2.foodista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
	<title>Foodista - your ultimate food guide</title>
    
  <!-- CSS start here -->
	<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" media="screen" />
	<link rel="stylesheet" type="text/css" href="css/styles.css" />
	<link rel="stylesheet" type="text/css" href="css/font-awesome.css" />
	<link rel="stylesheet" type="text/css" href="css/animate.css" />
	<!-- CSS end here -->
	<!-- Google fonts start here -->
	<link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css'/>
	<link href='http://fonts.googleapis.com/css?family=Roboto:300' rel='stylesheet' type='text/css'/>
	<!-- Google fonts end here -->

       <style type="text/css">
      div.imageSub { position: relative; }
      div.imageSub img { z-index: 1; }
      div.imageSub div {
        position: absolute;
        left: 15%;
        right: 15%;
        bottom: 0;
        padding: 4px;
      }
      div.imageSub div.blackbg {
        z-index: 2;
        color: #000;
        background-color: #000;
        -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=50)";
        filter: alpha(opacity=50);
        opacity: 0.5;
      }
      div.imageSub div.label {
        z-index: 3;
        color: white;
      }
    </style>

</head>
<body class="ux">
  <div class="bg-overlay"></div>

<!-- Contact Icon end here -->
	<!-- Main container start here -->
	<section class="container main-wrapper">

		<!-- Slogan start here -->
		<section class="slogan fade-down">
			<h1 style="font-size:80px">Foodista</h1>
            <h4 style="color:white;font-size:28px">your ultimate food guide</h4>			
		</section>

		<!-- Newsletter start here -->
		<section class="row fade-down">      
			
                <form id="form1" runat="server" class="contact col-md-6 fade-down validate">

                <div class="form-group">            
                    <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                        <asp:ListItem Value="1">I am male</asp:ListItem>
                        <asp:ListItem Value="2">I am female</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group"> 
                    <asp:DropDownList ID="ddlAge" runat="server" class="form-control">
                        <asp:ListItem Value="1">I am a teenager</asp:ListItem>
                        <asp:ListItem Value="2">I am a young adult (18-25)</asp:ListItem>
                        <asp:ListItem Value="3">I am an adult (25-40)</asp:ListItem>
                        <asp:ListItem Value="4">I am above 40</asp:ListItem>
                    </asp:DropDownList>             
                </div>

                <div class="form-group">
                    <asp:DropDownList ID="ddlResidence" runat="server" class="form-control">
                        <asp:ListItem Value="1">I live near Defence / Clifton</asp:ListItem>
                        <asp:ListItem Value="2">I live near Society / Gulshan</asp:ListItem>
                        <asp:ListItem Value="3">I live near Nazimabad / North Karach</asp:ListItem>
                        <asp:ListItem Value="4">I live near Gulistan e Jauhar / Malir</asp:ListItem>
                        <asp:ListItem Value="5">I live near Saddar / Old City</asp:ListItem>
                        <asp:ListItem Value="6">I live somewhere else</asp:ListItem>
                    </asp:DropDownList>              
                </div>

                <div class="form-group">  
                    <asp:DropDownList ID="ddlfrequencyMealsDay" runat="server" class="form-control">
                        <asp:ListItem Value="1">I eat once day</asp:ListItem>
                        <asp:ListItem Value="2">I eat twice a day</asp:ListItem>
                        <asp:ListItem Value="3">I eat thrice a day</asp:ListItem>
                        <asp:ListItem Value="4">I eat more than thrice</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">  
                    <asp:DropDownList ID="ddlFrequencyOutPerweek" runat="server" class="form-control">
                        <asp:ListItem Value="0">I never eat out</asp:ListItem>
                        <asp:ListItem Value="2">I eat out twice</asp:ListItem>
                        <asp:ListItem Value="4">I eat out more than twice</asp:ListItem>
                        <asp:ListItem Value="7">I eat out everyday</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
              
                      <asp:Button ID="LoadSuggestion" class="btn btn-success" runat="server"  text="Surprise me..." style="width:100%"  OnClick="LoadSuggestion_Click"  />
                    
                      </div>        
        
            </form>
            <asp:Panel Visible="false" ID="Panel1" runat="server">
            <section class="row fade-down">

               <div class="alert alert-success blackbg" style="text-align:center;background-color:white;color:black" role="alert">
                   We'll suggest you following foods:<br /><br />
                    <b><asp:Literal ID="food1" runat="server">food1 </asp:Literal></b>
                    <b><asp:Literal Visible="false" ID="food2" runat="server">food2 </asp:Literal></b>
                    <b><asp:Literal Visible="false" ID="food3" runat="server">food3 </asp:Literal>
                </div>
                
            </section>

             <section class="row fade-down">

               <div class="alert alert-success blackbg" style="text-align:center;background-color:white;color:black" role="alert">
                   We'll suggest you following Locations:<br /><br />
                    <b><asp:Literal ID="Literal1"  runat="server">Location1</asp:Literal></b>,
                    <b><asp:Literal ID="Literal2" runat="server">Location2</asp:Literal></b>  ,  
                    <b><asp:Literal ID="Literal3"  runat="server">Location3</asp:Literal>
                </div>
                
            </section>
                </asp:Panel>


    		</section>
        </section>



		<!-- Main container start here -->
		<!-- Javascript framework and plugins start here -->
		<script type="text/javascript" src="js/jquery.js"></script> 
		<script type="text/javascript" src="js/bootstrap.min.js"></script> 
		<script src="js/jquery.validate.min.js"></script>
		<script src="js/modernizr.js"></script> 
		<script type="text/javascript" src="js/appear.js"></script> 		
		<script src="js/jquery.knob.js"></script>
		<script src="js/jquery.ccountdown.js"></script>
		<script src="js/init.js"></script>
		<script src="js/general.js"></script>
		
<!-- Javascript framework and plugins end here -->
</body>
</html>