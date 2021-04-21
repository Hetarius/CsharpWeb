<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfesoresPage.aspx.cs" Inherits="WebAppInstituto.ProfesoresPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <a class="btn btn-primary" href="ProfesoresABMPage.aspx?accion=1">Agregar</a>
    
    <br />

   <%-- <asp:Label ID="labelProfesor" runat="server" Text="Label"></asp:Label>--%>

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




      <asp:Literal ID="litTablaProfesor" runat="server"></asp:Literal>
    <%--<tr>
      <th scope="row">1</th>
      <td>Rodrigo</td>
      <td>Moreiras</td>
      <td>@mdo</td>
    </tr>--%>
    
  </tbody>
</table>

</asp:Content>
