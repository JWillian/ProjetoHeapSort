using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) //quando se clica e faz um evento, é um postback || executa uma ação
        {
            CarregarDDLCidade();
            CarregarDDLTipoUsuario();

            DataSet dsPlano = pla_planoDB.SelectAll();
            //Carrega o plano do banco na Drop Down Cidade
            ddlPlano.DataSource = dsPlano;
            ddlPlano.DataTextField = "pla_nome";
            ddlPlano.DataValueField = "pla_id";
            //Depois de tudo configurado, ele fixa o valor e o nome da cidade na DropDownList
            ddlPlano.DataBind();
            ddlPlano.Items.Insert(0, "Selecione");

        }

        CarregarGridCliente();

    }

    private void CarregarDDLCidade()
    {
        DataSet dsCidade = cid_cidadeDB.SelectAll();
        //Carrega as cidades do banco na Drop Down Cidade

        ddlCidade.DataSource = dsCidade;
        ddlCidade.DataTextField = "cid_nome";
        ddlCidade.DataValueField = "cid_id";
        //Depois de tudo configurado, ele fixa o valor e o nome da cidade na DropDownList
        ddlCidade.DataBind();
        ddlCidade.Items.Insert(0, "Selecione");

    }

    private void CarregarDDLTipoUsuario()
    {
        DataSet dsTipoUsuario = tpu_tipo_usuarioDB.SelectAll();
        
        ddlTipoUsuario.DataSource = dsTipoUsuario;
        ddlTipoUsuario.DataTextField = "tpu_descricao";
        ddlTipoUsuario.DataValueField = "tpu_id";
        ddlTipoUsuario.DataBind();
        ddlTipoUsuario.Items.Insert(0, "Selecione");

    }


    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        tpu_tipo_usuario tipousuario = new tpu_tipo_usuario();
        tipousuario.Tpu_id = Convert.ToInt32(ddlTipoUsuario.SelectedValue);

        cid_cidade cidade = new cid_cidade();
        cidade.Cid_id = Convert.ToInt32(ddlCidade.SelectedValue);

        pla_plano plano = new pla_plano();
        plano.Pla_id = Convert.ToInt32(ddlPlano.SelectedIndex);
        plano.Pla_nome = Convert.ToString(ddlPlano.SelectedValue);
        plano.Pla_qtd_dias = Convert.ToInt32(txtQtdDias.Text);

        usu_usuario usuario = new usu_usuario();
        usuario.Usu_login = txtLogin.Text;
        usuario.Usu_senha = txtSenha.Text;
        usuario.Cid_id = cidade;
        usuario.Tpu_id = tipousuario;
        usu_usuarioDB.Insert(usuario);
        usuario = usu_usuarioDB.SelectUsuario(usuario);

        cli_cliente cliente = new cli_cliente();
        cliente.Cli_nome = txtNome.Text;
        cliente.Cli_email = txtEmail.Text;
        cliente.Cli_cpf = txtCPF.Text;
        cliente.Cli_idade = Convert.ToInt32(txtIdade.Text);
        cliente.Usu_id = usuario;

        ctr_controle controle = new ctr_controle();
        controle.Pla_id = plano;
        controle.Usu_id = usuario;
        controle.Ctr_data_termino = txtQtdDias.Text;
        ctr_controleDB.Insert(controle);


        if (cli_clienteDB.Insert(cliente) == 0)
        {
            Response.Write("<script>alert('Cadastrado com sucesso')</script>");
            LimparForm();
        }
        else
        {
            Response.Write("<script>alert('Erro ao cadastrar')</script>");
        }

        CarregarGridCliente();
    }

    protected void ddlPlano_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet ds = pla_planoDB.SelectbyId(Convert.ToInt32(ddlPlano.SelectedValue)); //carrega informacoes da coluna emp_id

        if (ds.Tables[0].Rows.Count == 0)
        { //conta qts linhas tem na tabela, se for = 0 nao tem nada dentro da tabela
            //Nada encontrado
        }
        else
        {


            txtQtdDias.Text = ds.Tables[0].Rows[0]["pla_qtd_dias"].ToString();

        }

    }


    protected void LimparForm()
    {
        txtNome.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtCPF.Text = String.Empty;
        txtLogin.Text = String.Empty;
        txtSenha.Text = String.Empty;
        txtIdade.Text = String.Empty;
        txtQtdDias.Text = String.Empty;
        ddlCidade.SelectedIndex = 0;
        ddlTipoUsuario.SelectedIndex = 0;
        ddlPlano.SelectedIndex = 0;
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        LimparForm();
    }


    private void CarregarGridCliente()
    {
        DataSet ds = cli_clientefinalDB.SelectClienteAll();

        GridView.DataSource = ds.Tables[0].DefaultView;

        GridView.DataBind();
    }

}