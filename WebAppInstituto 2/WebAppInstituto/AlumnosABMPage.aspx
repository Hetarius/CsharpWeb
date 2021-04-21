<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnosABMPage.aspx.cs" Inherits="WebAppInstituto.AlumnosABMPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />

    <div class="form-group">
        <label for="exampleInputEmail1">Nombre</label>
        <asp:TextBox ID="txtNombre" placeholder="Escriba un nombre" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Apellido</label>
        <asp:TextBox ID="txtApellido"  placeholder="Escriba un apellido" class="form-control" runat="server"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <label for="exampleInputEmail1">DNI</label>
        <asp:TextBox ID="txtDni"  placeholder="Escriba un DNI" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Mail</label>
        <asp:TextBox ID="txtMAil" placeholder="Escriba un email" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Telefono</label>
        <asp:TextBox ID="txtTelefono" placeholder="Escriba un telefono" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Cuota</label>
        <asp:TextBox ID="txtCuota" class="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
    
   <%-- <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>--%>


    <br />
    <asp:Label ID="labelAlumno" runat="server" Text=""></asp:Label>
    <br />
    <a class="btn btn-info" href="AlumnosPage.aspx"> volver</a>
</asp:Content>
