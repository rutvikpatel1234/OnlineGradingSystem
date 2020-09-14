<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="assignment.aspx.cs" Inherits="gradingsystem.assignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
 
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
</head>
   
   <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
  <ul class="navbar-nav">
    <li class="nav-item active">
      <a class="nav-link" href="/course.aspx">Course</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="/addstudent.aspx">Add Student</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="/RemoveStudent.aspx">Remove Student</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="/AssginmentRemove.aspx">Remove Assignment</a>
    </li>   
 <li class="nav-item">
      <a class="nav-link" href="logout.aspx">Logout</a>
    </li>   
      </ul>
       </nav>
     <div class="container">
  <div class="page-header">
   <h1>Add Assignment</h1>   
  </div>
        </div>
<body>


    <form id="form1" runat="server">
         <div class="container">
        <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Assignment"></asp:Label>
<asp:TextBox class="form-control" ID="txtAssignment" placeholder="Please Enter Assignment" runat="server"></asp:TextBox>
         </div>
        <asp:Button ID="btnassignment" class="btn btn-primary" runat="server" OnClick="btnassignment_Click" Text="Add" />
       </div>
    </form>
</body>
</html>

