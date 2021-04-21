<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CursosPage.aspx.cs" Inherits="WebAppInstituto.CursosPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <a class="btn btn-primary" href="CursosABMPage.aspx?accion=1">Agregar</a>

    <br />

    <table class="table">
        <thead>
            <tr>
                <th scope="col">Numero</th>
                <th scope="col">Nombre</th>
                <th scope="col">FechaInicio</th>
                <th scope="col">Hora</th>
                <th scope="col">Precio</th>
                <th scope="col">Profesor</th>
                <th scope="col"></th>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="litTablaCurso" runat="server"></asp:Literal>
          
        </tbody>
    </table>

</asp:Content>
