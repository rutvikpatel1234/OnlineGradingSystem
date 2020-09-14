﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssginmentRemove.aspx.cs" Inherits="gradingsystem.AssginmentRemove" %>

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
   <style>
.Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}

.Grid td {

      padding: 2px;

      border: solid 1px #c1c1c1; }

.Grid th  {

      padding : 4px 2px;

      color: #fff;

      background: #000000 url(Images/grid-header.png) repeat-x top;

      border-left: solid 1px #525252;

      font-size: 0.9em; }

.Grid .alt {

      background: #fcfcfc url(Images/grid-alt.png) repeat-x top; }

.Grid .pgr {background: #363670 url(Images/grid-pgr.png) repeat-x top; }

.Grid .pgr table { margin: 3px 0; }

.Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #666; font-weight: bold; color: #fff; line-height: 12px; }  

.Grid .pgr a { color: Gray; text-decoration: none; }

.Grid .pgr a:hover { color: #000; text-decoration: none; }
   </style>
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
      <a class="nav-link" href="/assignment.aspx">Add Assignment</a>
    </li>   
     <li class="nav-item">
      <a class="nav-link" href="logout.aspx">Logout</a>
    </li>   
      </ul>
       </nav>

    <div class="container">
  <div class="page-header">
   <h1>Remove Assignment</h1>   
  </div>
        </div>
<body>
     <div class="container">
    <form id="form1" runat="server">
       
               
                    <asp:GridView ID="gv_assignmentremove" runat="server" AutoGenerateColumns="False" Width="600px"

                      AllowPaging="True" PageSize="8" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" CellPadding="4" ForeColor="#333333" GridLines="None">
<AlternatingRowStyle CssClass="alt" BackColor="White"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="remove_assignment" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="assignment_id" HeaderText="Assignment ID" />
                            <asp:BoundField DataField="name" HeaderText="Assignment Name" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

<PagerStyle CssClass="pgr" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                     <asp:Button ID="btndelete" class="btn btn-danger" runat="server" Text="Delete" OnClientClick="ClickDelete" OnClick="btndelete_Click" />
             
    </form>
          
         </div>
  
</body>
</html>

