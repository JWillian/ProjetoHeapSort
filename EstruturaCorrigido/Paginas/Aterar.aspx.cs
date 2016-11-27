using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Aterar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DataSet dsCidade = cid_cidadeDB.SelectAll();
            //Carrega as cidades do banco na Drop Down Cidade
            ddlCidade.DataSource = dsCidade;
            ddlCidade.DataTextField = "cid_nome";
            ddlCidade.DataValueField = "cid_id";
            //Depois de tudo configurado, ele fixa o valor e o nome da cidade na DropDownList
            ddlCidade.DataBind();

            DataSet dsTipoUsuario = tpu_tipo_usuarioDB.SelectAll();
            ddlTipoUsuario.DataSource = dsTipoUsuario;
            ddlTipoUsuario.DataTextField = "tpu_descricao";
            ddlTipoUsuario.DataValueField = "tpu_id";
            ddlTipoUsuario.DataBind();

            DataSet dsPlano = pla_planoDB.SelectAll();
            //Carrega o plano do banco na Drop Down Cidade
            ddlPlano.DataSource = dsPlano;
            ddlPlano.DataTextField = "pla_nome";
            ddlPlano.DataValueField = "pla_id";
            //Depois de tudo configurado, ele fixa o valor e o nome da cidade na DropDownList
            ddlPlano.DataBind();
            ddlPlano.Items.Insert(0, "Selecione");
        }


        DataSet dsCpf = cli_clienteDB.SelectAll();
        //Carrega o plano do banco na Drop Down Cidade
        ddlCpf.DataSource = dsCpf;
        ddlCpf.DataTextField = "cli_cpf";
        ddlCpf.DataValueField = "cli_id";
        //Depois de tudo configurado, ele fixa o valor e o nome da cidade na DropDownList
        ddlCpf.DataBind();

    }

    //SELECT PLANO
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


    //SELECT CPF
    protected void ddlCpf_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet ds = cli_clientefinalDB.SelectById(Convert.ToInt32(ddlCpf.SelectedValue));

        if (ds.Tables[0].Rows.Count == 0)
        {

        }
        else
        {
            txtNome.Text = ds.Tables[0].Rows[0]["cli_nome"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["cli_email"].ToString();
            txtIdade.Text = ds.Tables[0].Rows[0]["cli_idade"].ToString();
            ddlCidade.DataValueField = ds.Tables[0].Rows[0]["cid_id"].ToString();
            ddlTipoUsuario.DataValueField = ds.Tables[0].Rows[0]["tpu_id"].ToString();
            ddlPlano.DataValueField = ds.Tables[0].Rows[0]["pla_id"].ToString();
            txtQtdDias.Text = ds.Tables[0].Rows[0]["pla_qtd_dias"].ToString();
            txtLogin.Text = ds.Tables[0].Rows[0]["usu_login"].ToString();
            txtSenha.Text = ds.Tables[0].Rows[0]["usu_senha"].ToString();
        }

    }

    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        cli_clientefinal cliente = new cli_clientefinal();
        cli_cliente cli = new cli_cliente();
        pla_plano pla = new pla_plano();
        ctr_controle ctr = new ctr_controle();
        cid_cidade cid = new cid_cidade();
        usu_usuario usu = new usu_usuario();
        tpu_tipo_usuario tpu = new tpu_tipo_usuario();

        cli.Cli_id = 1;
        cli.Cli_nome = txtNome.Text;
        cli.Cli_email = txtEmail.Text;
        cli.Cli_cpf = ddlCpf.SelectedValue;
        cli.Cli_idade = Convert.ToInt32(txtIdade.Text);
        cid.Cid_nome = ddlCidade.SelectedValue;
        tpu.Tpu_descricao = ddlTipoUsuario.SelectedValue;
        pla.Pla_qtd_dias = Convert.ToInt32(txtQtdDias.Text);
        usu.Usu_login = txtLogin.Text;
        usu.Usu_senha = txtSenha.Text;

        usu.Tpu_id = tpu;

        cli.Usu_id = usu;

        cliente.Cli_id = cli;
        cliente.Ctr_id = ctr;

        cliente.Ctr_id.Pla_id = pla;

        cli_clientefinalDB.Update(cliente);

        switch (cli_clientefinalDB.Update(cliente))
        {
            case 0:
                lblAlterar.Text = "<div class='alert-success alert'>Alterado com Sucesso</div>";
                break;
            case -2:
                lblAlterar.Text = "<div class='alert-danger alert'>Erro</div>";
                break;
        }

    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {

        DataSet dsCliente = cli_clienteDB.SelectbyId(Convert.ToInt32(ddlCpf.SelectedValue));

        int usu_id = Convert.ToInt32(dsCliente.Tables[0].Rows[0]["usu_id"]);
        int cli_id = Convert.ToInt32(dsCliente.Tables[0].Rows[0]["cli_id"]);

        cli_clienteDB.Delete(cli_id);
        ctr_controleDB.Delete(usu_id);

        switch (usu_usuarioDB.Delete(usu_id))
        {
            case 0:
                lblDeletar.Text = "<div class = 'alert-success alert text-center'>Registro Deletado</div>";
                break;
            case -2:
                lblDeletar.Text = "<div class = 'alert-danger alert text-center'>Erro!!!</div>";
                break;
        }
    }
}