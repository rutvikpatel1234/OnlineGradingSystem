<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="gradingsystem.course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="jquery-1.7.1.js"></script>
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
     <style>
         body {
            
  background-image: url("img/owl.jpg");
  background-repeat: no-repeat;
  background-position: right;

}
         .alertmessagge {
            padding: 10px;
            width: 100%;
            margin: 0 auto;
            text-align: center;
        }

        .imgheight {
            height: 200px;
            border-radius: 0px;
            
        }

        .details {
            top:25px;
            display: inline-block;
            margin: auto auto;
            vertical-align: top;
            margin: 0 10px 40px 0;
            border-radius: 0px;
            border: 2px solid #0275d8;
            left: 50px;
            
        }
         .card:hover {
             box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
         }
         
         h1 {
             
             
             text-align: center;
         }
         

     </style>   
     
    <script type="text/javascript">
        function preventBack() { window.history.forward();}
        setTimeout("preventBack()", 20);
        window.onbeforeunload = function () { null };
        
    </script>
</head>
    
 <nav class="navbar navbar-expand-sm bg-dark navbar-dark">  
  <ul class="navbar-nav">
    <li class="nav-item active">
      <a class="nav-link" href="login.aspx">Login</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="course.aspx">Dashboard</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="createcourseform.aspx">Add Course</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="CourseRemove.aspx">Remove Course</a>
    </li>   
 <li class="nav-item">
      <a class="nav-link" href="logout.aspx">Logout</a>
    </li>   
      </ul>
       </nav>

     
 
<body>
    
    <h1>Course</h1>
     
    <form id="form1" runat="server">
       
          <div runat="server" id="details">
            </div>
    </form>
     
   

   
 

</body>
</html>
