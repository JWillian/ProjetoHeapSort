<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Aterar.aspx.cs" Inherits="Paginas_Aterar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
             

    <div class="container">
        <div class="row">
            <h3 style="text-align: center">Dados Cadastrais: </h3>
            <div class="col-lg-6">
                <br />
                Cpf
                <asp:DropDownList ID="ddlCpf" runat="server" CssClass="form-control" autopostback="true" OnSelectedIndexChange=""></asp:DropDownList>
               <br />
                 Nome:
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox><br />
                E-mail:
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox><br />
                Idade:
                <asp:TextBox ID="txtIdade" runat="server" CssClass="form-control" TextMode="Number" min="0" step="1"></asp:TextBox><br />
            </div>

            <div class="col-lg-6">
               
                <div class="row">
                    <div class="col-lg-12">
                        <br />
                        Cidade:
                <asp:DropDownList ID="ddlCidade" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;
                        
                        <br />
                        Tipo de usuário:
                <asp:DropDownList ID="ddlTipoUsuario" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                      

                    </div>
                </div>

              
                <div class="row">
                    <div class="col-lg-12">
                        <br />Plano
                    <asp:DropDownList ID="ddlPlano" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPlano_SelectedIndexChanged" CssClass="form-control">
                    </asp:DropDownList>
                    </div>
                </div>


                
                <div class="row">
                    <div class="col-lg-12"><br />
                        Quantidade de dias:
                    <asp:TextBox ID="txtQtdDias" runat="server" CssClass="form-control" MaxLength="10" Enabled="false"></asp:TextBox><br />
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-6">
                        Login:
                    <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox><br />
                    </div>

                    <div class="col-lg-6">
                        Senha:
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox><br />
                    </div>
                </div>

                 <div class="row">
                    <br />
                    <div class="col-lg-12 text-center">
                        <asp:Button ID="btnAlterar" runat="server" CssClass="btn-info btn" Text="Alterar" OnClick="btnAlterar_Click" />
                        <asp:Button ID="btnDeletar" runat="server" Text="Deletar" CssClass="btn btn-danger" OnClick="btnDeletar_Click" />
                        <a href="PaginaInicial.aspx" class="btn btn-success">Voltar para o Cadastro</a>
                    </div>
                </div>

                <asp:Label ID="lblAlterar" runat="server" ></asp:Label>
                <asp:Label ID="lblDeletar" runat="server" ></asp:Label>
                </div>
            </div>
        <br />
        </div>
    

              



</asp:Content>

