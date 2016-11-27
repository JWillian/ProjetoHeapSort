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





    public static List<cli_clientefinal> SelectClienteAll()
    {
        List<cli_clientefinal> clientes = new List<cli_clientefinal>();
        IDbConnection objConexao;
        IDbCommand objCommando;
        string sql = "select ";
        sql += "cli.cli_id, ";
        sql += "cli.cli_nome, ";
        sql += "cli.cli_email, ";
        sql += "cli.cli_cpf, ";
        sql += "cli.cli_idade, ";
        sql += "cid.cid_nome, ";
        sql += "tpu.tpu_descricao, ";
        sql += "pla.pla_nome, ";
        sql += "pla.pla_qtd_dias, ";
        sql += "usu.usu_login, ";
        sql += "usu.usu_senha ";
        sql += "from usu_usuario usu ";
        sql += "inner join cli_cliente cli on(cli.usu_id = usu.usu_id) ";
        sql += "inner join ctr_controle ctr on(usu.usu_id = ctr.ctr_id) ";
        sql += "inner join pla_plano pla on(pla.pla_id = ctr.pla_id) ";
        sql += "inner join tpu_tipo_usuario tpu on(tpu.tpu_id = usu.tpu_id) ";
        sql += "inner join cid_cidade cid on(cid.cid_id = usu.cid_id); ";

        objConexao = Mapped.Connection();
        objCommando = Mapped.Command(sql, objConexao);
        IDataReader reader = objCommando.ExecuteReader();
        while (reader.Read())
        {
            cli_clientefinal clifinal = new cli_clientefinal();
            cli_cliente cli = new cli_cliente();
            cid_cidade cidade = new cid_cidade();
            pla_plano plano = new pla_plano();
            tpu_tipo_usuario tipo = new tpu_tipo_usuario();
            usu_usuario usuario = new usu_usuario();
            ctr_controle controle = new ctr_controle();


            cli.Cli_id = Convert.ToInt32(reader["cli.cli_id"]);
            cli.Cli_nome = Convert.ToString(reader["cli.cli_nome"]);
            cli.Cli_email = Convert.ToString(reader["cli.cli_email"]);
            cli.Cli_cpf = Convert.ToString(reader["cli.cli_cpf"]);
            cli.Cli_idade = Convert.ToInt32(reader["cli.cli_idade"]);

            cidade.Cid_nome = Convert.ToString(reader["cid.cid_nome"]);

            tipo.Tpu_descricao = Convert.ToString(reader["tpu.tpu_descricao"]);

            plano.Pla_nome = Convert.ToString(reader["pla.pla_nome"]);
            plano.Pla_qtd_dias = Convert.ToInt32(reader["pla_qtd_dias"]);


            usuario.Usu_login = Convert.ToString(reader["usu.usu_login"]);
            usuario.Usu_senha = Convert.ToString(reader["usu.usu_senha"]);

            usuario.Cid_id = cidade;
            usuario.Tpu_id = tipo;

            cli.Usu_id = usuario;

            controle.Pla_id = plano;
  
            clifinal.Cli_id = cli;

            clifinal.Ctr_id = controle;



            clientes.Add(clifinal);

        }
        objConexao.Close();
        objConexao.Dispose();
        objCommando.Dispose();
        reader.Dispose();
        return clientes;
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