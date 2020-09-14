<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createcourseform.aspx.cs" Inherits="gradingsystem.createcourseform" %>


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

   
     <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
  <ul class="navbar-nav">
    <li class="nav-item active">
      <a class="nav-link" href="login.aspx">Login</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="course.aspx">Course</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="createcourseform.aspx">Add Course</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" href="CourseRemove.aspx">Remove Course</a>
    </li>
  </ul>
</nav>
   
</head>
<body style="width: 1829px; height: 607px">
     <div class="container">
  <div class="page-header">
    <h1>Creat Course</h1>      
        </div>
    <form id="form1" runat="server">
        <div class="auto-style23">
        <div class="auto-style25">
            </div>
       
            <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Course Title"></asp:Label>
            <asp:TextBox class="form-control" ID="txttitle" runat="server" placeholder="Please Enter Course Title"></asp:TextBox>
                 </div>

            <div class="form-group">
            <asp:Label runat="server" Text="Description"></asp:Label>
        <asp:TextBox class="form-control" ID="txtDesc" runat="server" placeholder="Please Enter Course Description" ></asp:TextBox>
            </div>

             
             <asp:Label runat="server" Text="Semester:"></asp:Label>
            <div class="form-group">
                  <div class="dropdown">
                  <asp:DropDownList class="btn btn-light dropdown-toggle" ID="CourseAddSemesterDropDown" AutoPostBack="true" runat="server">
             <asp:ListItem Text="2019 Fall"></asp:ListItem>
            <asp:ListItem Text="2020 Spring"></asp:ListItem>
            <asp:ListItem Text="2021 Fall"></asp:ListItem>
            </asp:DropDownList>
                      </div>
                </div>
             <asp:Label runat="server" Text="Department:"></asp:Label>
             <div class="form-group">
                 <div class="dropdown">
                 <asp:DropDownList class="btn btn-light dropdown-toggle" ID="CourseDepartmentDropDown" AutoPostBack="true" runat="server">
             <asp:ListItem Text="IST"></asp:ListItem>
            <asp:ListItem Text="CIS"></asp:ListItem>
            <asp:ListItem Text="CHEM"></asp:ListItem>
            </asp:DropDownList>
                 </div>
                 </div>
            
             <div class="form-group">
                 <asp:Label runat="server" Text="Image:"></asp:Label>
           
            <asp:FileUpload class="caret" ID="FileUpload1" runat="server"/>
             </div>

       
            
        
        <asp:Button ID="btnAddCourse" class="btn btn-primary" runat="server" OnClick="btnAddCourse_Click" Text="Submit" />
        
        </div>
    </form>
  </div>
    
</body>
</html>
