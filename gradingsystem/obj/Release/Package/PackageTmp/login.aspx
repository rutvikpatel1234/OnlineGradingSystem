<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="gradingsystem.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.7.1.js"></script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
     <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        body, html {
  height: 100%;
  font-family: Arial, Helvetica, sans-serif;
}

* {
  box-sizing: border-box;
}

    .bg-img { /* The image used */ 
              background-image: url("img/home.jpg");
              min-height: 100%; /* Center and scale the image nicely */ 
              background-position: center; 
              background-repeat: no-repeat; 
              background-size: cover; 
              position: relative;

    }
        .container1 {
  position: absolute;
  left: 45%;
  top: 20%;
  margin: 20px;
  max-width: 300px;
  padding: 16px;
  background-color: white;
  border-radius: 4px;
}
        .page-header{
            text-align:center;
        }
    </style>
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>

   
     <div class="container">
  <div class="page-header">
    <h1>Login Page</h1>      
  </div>
        </div>
</head>
   
<body>
    <div class="bg-img">
    <div class="container1">
    <form id="form1" runat="server">
        
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="User Name:"></asp:Label>
               <asp:TextBox class="form-control" ID="txtUser" runat="server" placeholder="Enter email" ></asp:TextBox>
              </div>
       
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="Enter password" TextMode="Password"></asp:TextBox>
             </div>
          
         <asp:Button ID="btnLogin" class="btn btn-primary" runat="server" OnClick="btnLogin_Click" Text="Login" />
    </form>
        </div>
        </div>
</body>
</html>
