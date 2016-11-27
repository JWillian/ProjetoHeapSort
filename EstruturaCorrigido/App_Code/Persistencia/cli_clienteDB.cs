using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class cli_clienteDB
{
    public static int Insert(cli_cliente cliente)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "insert into cli_cliente(cli_nome, cli_email, cli_cpf, cli_idade, usu_id) values(?cli_nome, ?cli_email, ?cli_cpf, ?cli_idade, ";
            sql += "?usu_id);";                      

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?cli_nome", cliente.Cli_nome));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_email", cliente.Cli_email));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_cpf", cliente.Cli_cpf));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_idade", cliente.Cli_idade));

            //FK
            objCommand.Parameters.Add(Mapped.Parametro("?usu_id", cliente.Usu_id.Usu_id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();
        }
        catch (Exception)
        {
            retorno = -2;
        }
        return retorno;
    }

    public static int Update(cli_cliente cliente)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            //string sql = "Update INTO emp_empresa;
            string sql = "update cli_cliente set cli_nome=?cli_nome cli_email=?cli_email cli_cpf = ?cli_cpf cli_idade = ?cli_idade cli_id = ?cli_id where cli_id = ?cli_id;";



            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            //objCommand.Parameters.Add(Mapped.Parametro("?tip_descricao", tipo.Tip_descricao));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_nome", cliente.Cli_nome));    //ex: aqui teria que ser nome tambem
            objCommand.Parameters.Add(Mapped.Parametro("?cli_email", cliente.Cli_email));      // as informacoes vem pelo objeto
            objCommand.Parameters.Add(Mapped.Parametro("?cli_cpf", cliente.Cli_cpf));
            objCommand.Parameters.Add(Mapped.Parametro("?cli_idade", cliente.Cli_idade));
           

            //FK
            objCommand.Parameters.Add(Mapped.Parametro("?Tpu_id", cliente.Usu_id.Usu_id));

            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();
        }
        catch (Exception e)
        {

            retorno = -2;
        }
        return retorno;
    }



    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando; 
        IDataAdapter objDataAdapter; 
        objConexao = Mapped.Connection();
        objComando = Mapped.Command("Select * from cli_cliente order by cli_nome ASC", objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds); 
        objConexao.Close(); 
        objConexao.Dispose(); 
        objComando.Dispose();
        return ds;
    }

    public static int Delete(int id)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "delete from cli_cliente where cli_id = ?cli_id";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?cli_id", id));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objConexao.Dispose();
            objCommand.Dispose();
        }
        catch (Exception e)
        {

            retorno = -2;
        }
        return retorno;
    }

    public static DataSet SelectbyId(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao; //faz a conexão com o banco
        IDbCommand objComando; // executa uma query e valida
        IDataAdapter objDataAdapter; //faz a ponte entre o banco e nossa memória
        objConexao = Mapped.Connection();
        objComando = Mapped.Command("select * from cli_cliente where cli_id = ?id;", objConexao);

        //está linha é a única alteração
        objComando.Parameters.Add(Mapped.Parametro("?id", id)); //é o id que esta sendo mandado

        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds); // carrega o ds = dataset
        objConexao.Close(); //fecha a conexao
        objConexao.Dispose(); //limpa a memória
        objComando.Dispose();
        return ds;
    }

    public static DataSet SelectGrid()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter objDataAdapter;

        objConexao = Mapped.Connection();
        //string sql = "select cli_id, cli_nome, cli_email, cli_cpf, cli_idade, cid_nome, tpu_descricao, usu_login, usu_senha";
        //sql += "from cli_cliente inner join usu_usuario using (usu_id) ";
        //sql += "inner join tpu_tipo_usuario using (tpu_id) ";
        //sql += "inner join cid_cidade using (cid_id);";

        //objComando = Mapped.Command("select cli_id, cli_nome, cli_email, cli_cpf, cli_idade, cid_nome, tpu_descricao, usu_login from cli_cliente inner join usu_usuario using (usu_id) inner join tpu_tipo_usuario using (tpu_id) inner join cid_cidade using (cid_id) order by cli_id; select pla_nome, pla_qtd_dias from pla_plano; ", objConexao);

        objComando = Mapped.Command("select cli.cli_id, cli.cli_nome, cli.cli_email,  cli.cli_cpf,  cli.cli_idade, cid.cid_nome, tpu.tpu_descricao, pla.pla_nome,  pla.pla_qtd_dias, usu.usu_login, usu.usu_senha from usu_usuario usu inner join cli_cliente cli on(cli.usu_id = usu.usu_id) inner join ctr_controle ctr on(usu.usu_id = ctr.ctr_id) inner join pla_plano pla on(pla.pla_id = ctr.pla_id) inner join tpu_tipo_usuario tpu on(tpu.tpu_id = usu.tpu_id) inner join cid_cidade cid on(cid.cid_id = usu.cid_id);", objConexao);

        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objConexao.Dispose();
        objComando.Dispose();
        return ds;
    }

}