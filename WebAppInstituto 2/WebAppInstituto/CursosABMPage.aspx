<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CursosABMPage.aspx.cs" Inherits="WebAppInstituto.CursosABMPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div class="form-group">
        <label for="exampleInputEmail1">Nombre</label>
        <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Fecha Inicio</label>
        <asp:TextBox ID="txtFechaInicio" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Hora</label>
        <asp:TextBox ID="txtHora" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Precio</label>
        <asp:TextBox ID="txtPrecio" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="exampleInputEmail1">Profesor</label>

        <asp:DropDownList ID="DropListProfesor" class="form-control" runat="server"></asp:DropDownList>
    </div>

    <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" 
                Text="Guardar" OnClick="btnGuardar_OnClick" />
   
    <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server"
        Text="Eliminar" OnClick="btnEliminar_OnClick" />
    <br />
    <asp:Label ID="labelCurso" runat="server" Text=""></asp:Label>
    <br />
    <a class="btn btn-info" href="CursosPage.aspx"> volver</a>



 

</asp:Content>
