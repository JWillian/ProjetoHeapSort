<%@ Page Title="Pagina Inicial" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaginaInicial.aspx.cs" Inherits="Paginas_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <h3 style="text-align: center">Dados Cadastrais: </h3>
            <div class="col-lg-6">
                <br />
                Nome:
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox><br />
                E-mail:
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox><br />
                CPF:
                <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control"></asp:TextBox><br />
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
                        <asp:Button ID="btnSalvar" runat="server" CssClass="btn-success btn" Text="Salvar" OnClick="btnSalvar_Click" />

                        <a href="Aterar.aspx" class="btn btn-primary">Alterar</a>


                    </div>
                </div>

            </div>
            <br />
        </div>

        <br />

        <div class="row">
            <div class="col-lg-12">
                <h3>Lista Desordenada:</h3>
                <br />

                <asp:GridView ID="GridView" runat="server" CssClass="table-hover table" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="cli_id" HeaderText="Id" />
                        <asp:BoundField DataField="cli_nome" HeaderText="Nome" />
                        <asp:BoundField DataField="cli_email" HeaderText="E-mail" />
                        <asp:BoundField DataField="cli_cpf" HeaderText="CPF" />
                        <asp:BoundField DataField="cli_idade" HeaderText="Idade" />
                        <asp:BoundField DataField="cid_nome" HeaderText="Cidade" />
                        <asp:BoundField DataField="tpu_descricao" HeaderText="Tipo de Usuário" />
                        <asp:boundfield datafield="pla_nome" headertext="plano" />
                        <asp:boundfield datafield="pla_qtd_dias" headertext="qtd de dias" />
                        <asp:BoundField DataField="usu_login" HeaderText="Login" />
                        <asp:BoundField DataField="usu_senha" HeaderText="Senha" />
                        
                    </Columns>
                </asp:GridView>

            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <h3>Lista Ordenada:</h3>
                <br />

                <%--<asp:GridView ID="GridView1" runat="server" CssClass="table-hover table" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="cli_id" HeaderText="Id" />
                        <asp:BoundField DataField="cli_nome" HeaderText="Nome" />
                        <asp:BoundField DataField="cli_email" HeaderText="E-mail" />
                        <asp:BoundField DataField="cli_cpf" HeaderText="Cpf" />
                        <asp:BoundField DataField="cli_idade" HeaderText="Idade" />
                        <asp:BoundField DataField="cid_nome" HeaderText="Cidade" />
                        <asp:BoundField DataField="tpu_descricao" HeaderText="Tipo de Usuário" />
                        <asp:BoundField DataField="usu_login" HeaderText="Login" />
                    </Columns>
                </asp:GridView>--%>
            </div>
        </div>

    </div>
    <br />
</asp:Content>
