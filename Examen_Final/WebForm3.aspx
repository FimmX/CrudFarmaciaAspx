<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Examen_Final.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista de clientes</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
        <script type="text/javascript">
            function volver() {
                var answer = confirm("¿Esta seguro que desea Salir?")
                if (answer) {
                    location.href = "/WebForm1.aspx";
                    // '<%= Page.ResolveUrl("~/About.aspx") %>';
                }
                else {
                    alert("Puede verificar la información")
                }
            return false;
            }
    </script>
    <style>
        body {
            background-image: url("img/fondo2.jpg");
            background-size: cover;
            background-repeat: no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron container bg-light">
            <div class="container">
                
                    <h1 class="display-2"> Datos BD </h1>
               
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Cargar Datos" />
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-dark" OnClientClick="javascript:volver()" OnClick="Button2_Click" Text="Volver" Width="110px" />
                    <hr> <div class="container">
                    <asp:GridView ID="GridView1" runat="server" Width="525px">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
