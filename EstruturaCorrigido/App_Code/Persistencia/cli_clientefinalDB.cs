using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cli_clientefinalDB
/// </summary>
public class cli_clientefinalDB
{





    public static DataSet SelectClienteAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;

        objConexao = Mapped.Connection();

        objComando = Mapped.Command("select " +
        "cli.cli_id, " +
        "cli.cli_nome, " +
        "cli.cli_email, " +
        "cli.cli_cpf, " +
        "cli.cli_idade, " +
        "cid.cid_nome, " +
        "tpu.tpu_descricao, " +
        "pla.pla_nome, " +
        "pla.pla_qtd_dias, " +
        "usu.usu_login, " +
        "usu.usu_senha " +
        "from usu_usuario usu " +
        "inner join cli_cliente cli on(cli.usu_id = usu.usu_id) " +
        "inner join ctr_controle ctr on(usu.usu_id = ctr.usu_id) " +
        "inner join pla_plano pla on(pla.pla_id = ctr.pla_id) " +
        "inner join tpu_tipo_usuario tpu on(tpu.tpu_id = usu.tpu_id) " +
        "inner join cid_cidade cid on(cid.cid_id = usu.cid_id); ", objConexao);

        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objConexao.Dispose();
        objComando.Dispose();
        return ds;
    }


    public static int Update(cli_clientefinal cliente)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            //string sql = "Update INTO emp_empresa;
            string sql = "update  cli_cliente  set ";
            sql += "cli_nome = ?cli_nome, ";
            sql += "cli_email = ?cli_email, ";
            sql += "cli_cpf = ?cli_cpf, ";
            sql += "cli_idade = ?cli_idade, ";
            sql += "tpu_descricao = ?tpu_descricao, ";
            sql += "pla_nome = ?pla_nome, ";
            sql += "pla_qtd_dias = ?pla_qtd_dias, ";
            sql += "usu_login = ?usu_login, ";
            sql += "usu_senha = ?usu_senha ";
            sql += "where cli_id = ?cli_id ";
            

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            //objCommand.Parameters.Add(Mapped.Parametro("?tip_descricao", tipo.Tip_descricao));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_nome", cliente.Cli_id.Cli_nome));    //ex: aqui teria que ser nome tambem
            objCommand.Parameters.Add(Mapped.Parametro("?cli_email", cliente.Cli_id.Cli_email));      // as informacoes vem pelo objeto
            objCommand.Parameters.Add(Mapped.Parametro("?cli_cpf", cliente.Cli_id.Cli_cpf));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_idade", cliente.Cli_id.Cli_idade));
            objCommand.Parameters.Add(Mapped.Parametro("?tpu_descricao", cliente.Cli_id.Usu_id.Tpu_id.Tpu_descricao));
            objCommand.Parameters.Add(Mapped.Parametro("?pla_nome", cliente.Ctr_id.Pla_id.Pla_nome));
            objCommand.Parameters.Add(Mapped.Parametro("?pla_qtd_dias", cliente.Ctr_id.Pla_id.Pla_qtd_dias));
            objCommand.Parameters.Add(Mapped.Parametro("?usu_login", cliente.Cli_id.Usu_id.Usu_login));
            objCommand.Parameters.Add(Mapped.Parametro("?usu_senha", cliente.Cli_id.Usu_id.Usu_senha));

            //FK
            objCommand.Parameters.Add(Mapped.Parametro("?ctr_id", cliente.Ctr_id.Ctr_id));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_id", cliente.Cli_id.Cli_id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();
        }
        catch (Exception e)
        {
            retorno = -2;
            Debug.WriteLine(e.ToString());
        }
        return retorno;
    }

}