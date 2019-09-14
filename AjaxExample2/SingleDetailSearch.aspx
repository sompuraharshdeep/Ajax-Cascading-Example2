<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleDetailSearch.aspx.cs" Inherits="AjaxExample2.SingleDetailSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <table>
              <tr>
                  <td>
                      <asp:DropDownList ID="ddlName"  runat="server" AutoPostBack="false" DataSourceID="SqlDataSource1" DataTextField="empName" DataValueField="empId" OnChange="search()"></asp:DropDownList>
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_AjaxConnectionString %>" SelectCommand="SELECT * FROM [employee]"></asp:SqlDataSource>
                  </td>
              </tr>
          </table>
         <br />
        <div id="d1">

        </div>
    </form>
    <script type="text/javascript">
        function search() {
            var msg = new XMLHttpRequest();
            msg.open("GET", "Insert.aspx?opr=search&name=" + document.getElementById("ddlName").value, false);
            msg.send(null);

            document.getElementById("d1").innerHTML = msg.responseText;
            
        }
    </script>
</body>
</html>
