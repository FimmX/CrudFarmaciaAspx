<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Examen_Final.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu Clientes</title>
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
        function mensaje() {
            alert("No existen Datos");
            return false;
        }
        function msgdelet() { alert("Cliente eliminado con exito"); }
        function msgcreat() { alert("Cliente guardado con exito"); }
        function msgupdea() { alert("Cliente modificado con exito"); }
    </script>
    <style>
        body {
            background-image: url("img/fondo1.jpg");
            background-size: cover;
            background-repeat: no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div class="container justify-content-center w-50" >
            <div class=" jumbotron p-2 mt-5">
                <div class="form-group">
                   
                    <h2>Sistema de Clientes</h2>
                </div>
                <div class="form-group">
                   <asp:Label ID="Label1" runat="server" CssClass="control-label " Text="rut"></asp:Label>                     
                   <div class="">
                       <asp:TextBox ID="txtrut" CssClass="form-control shadow p-3 mb-3 bg-white rounded" runat="server" TextMode="SingleLine"/>
                   </div>
                 </div>             
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Nombre"></asp:Label>
                    <div class="">
                        <asp:TextBox ID="txtNombre" CssClass="form-control shadow p-3 mb-3 bg-white rounded" runat="server" TextMode="SingleLine" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label " Text="Apellido"></asp:Label>
                        <div class="">
                            <asp:TextBox ID="txtApellido" CssClass="form-control shadow p-3 mb-3 bg-white rounded" runat="server" TextMode="SingleLine" />
                        </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Direccion"></asp:Label>
                    <div class="">
                        <asp:TextBox ID="txtDireccion" CssClass="form-control shadow p-3 mb-5 bg-white rounded" runat="server" TextMode="SingleLine" />
                    </div>
               </div>
                   <div class="d-flex justify-content-center">
                        <asp:Button runat="server" Text="Guardar"  CssClass="btn-danger rounded-pill" OnClick="Unnamed1_Click" />
                        <asp:Button runat="server" Text="Buscar"  CssClass="btn-primary rounded-pill"  Width="73px" OnClick="Unnamed3_Click" />
                        <asp:Button ID="Button1" runat="server" Text="Modificar" CssClass="btn-primary rounded-pill" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Eliminar" CssClass="btn-primary rounded-pill" OnClick="Button2_Click" />
                        <asp:Button runat="server" Text="Volver"  CssClass="btn-dark rounded-pill" OnClientClick="javascript:volver()" Width="73px" OnClick="Unnamed2_Click" />
                    </div>               
            </div>
    </form>
</body>
</html>
