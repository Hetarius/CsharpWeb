<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnosPage.aspx.cs" Inherits="WebAppInstituto.AlumnosPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <%-- PlaceHolder es semejante a un PANEL--%>
    <%--Use el control PlaceHolder como contenedor para almacenar controles de servidor que se agregan dinámicamente a la página web. 
        El control PlaceHolder no produce ningún resultado visible y se usa solo como contenedor para otros controles en la página web. Puede usar la colección Control.Controls para agregar, insertar o eliminar un control en el control PlaceHolder .--%>
    <asp:PlaceHolder ID="Panel1" runat="server">
    <a class="btn btn-primary" href="AlumnosABMPage.aspx?accion=1">Agregar</a>
    </asp:PlaceHolder>
    <br />

   <%-- <asp:Label ID="labelAlumno" runat="server" Text="Label"></asp:Label>--%>

    <table class="table">
  <thead>
    <tr>
      <th scope="col">Numero</th>
      <th scope="col">Nombre</th>
      <th scope="col">Apellido</th>
      <th scope="col">DNI</th>
    </tr>
  </thead>
  <tbody>

      <asp:Literal ID="litTablaAlumno" runat="server"></asp:Literal>



    <%--<tr>
      <th scope="row">1</th>
      <td>Rodrigo</td>
      <td>Moreiras</td>
      <td>@mdo</td>
    </tr>--%>
    
  </tbody>
</table>



</asp:Content>
