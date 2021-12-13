<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication8._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TESTING</title>
    <script
    src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js">
    </script>

</head>
<body>
    <form id="form1" runat="server">
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MedischeDatabase %>" SelectCommand="SELECT * FROM [2909ArjanEMC]"></asp:SqlDataSource>
    </form>
<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #dddddd;
}


.False 
{
    background-color:red;

}

</style>
        <table style="font-size:100%;">
                <tr>
                    <th>ID</th>
                    <th>Part-No</th>
                    <th>Description german</th>
                    <th>Reference Price 2006 in EURO</th>
                </tr>

             <% Response.Write(HTMLDATA);%>
       </table>
     
</body>
</html>
