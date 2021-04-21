<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfesoresABMPage.aspx.cs" Inherits="WebAppInstituto.ProfesoresABMPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <br />

    <div class="form-group">
        <label for="exampleInputEmail1">Nombre</label>
        <asp:TextBox ID="txptNombre" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Apellido</label>
        <asp:TextBox ID="txtpApellido" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">DNI</label>
        <asp:TextBox ID="txtpDni" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Mail</label>
        <asp:TextBox ID="txtpMAil" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Telefono</label>
        <asp:TextBox ID="txtpTelefono" class="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <label for="exampleInputEmail1">Sueldo</label>
        <asp:TextBox ID="txtpSueldo" class="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button ID="btnpGuardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnpGuardar_Click1"/>


    
    <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server"
        Text="Eliminar" OnClick="btnEliminar_Click" />


    <br />
    <asp:Label ID="labelProfesor" runat="server" Text=""></asp:Label>
    <br />
    <a class="btn btn-info" href="ProfesoresPage.aspx"> volver</a>
</asp:Content>
