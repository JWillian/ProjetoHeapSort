using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class pla_planoDB
{
    public static int Insert(pla_plano plano)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "insert into pla_plano(pla_nome) values(?pla_nome);"; 
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?pla_nome", plano.Pla_nome)); 
            retorno = objCommand.ExecuteNonQuery();
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

    public static DataSet SelectbyId(int id)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao; //faz a conexão com o banco
        IDbCommand objComando; // executa uma query e valida
        IDataAdapter objDataAdapter; //faz a ponte entre o banco e nossa memória
        objConexao = Mapped.Connection();
        objComando = Mapped.Command("select pla_qtd_dias from pla_plano where pla_id = ?id;", objConexao);

        //está linha é a única alteração
        objComando.Parameters.Add(Mapped.Parametro("?id", id)); //é o id que esta sendo mandado

        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds); // carrega o ds = dataset
        objConexao.Close(); //fecha a conexao
        objConexao.Dispose(); //limpa a memória
        objComando.Dispose();
        return ds;
    }


    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao; 
        IDbCommand objComando; 
        IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection();
        objComando = Mapped.Command("Select * from pla_plano ORDER BY pla_nome;", objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds); 
        objConexao.Close(); 
        objConexao.Dispose(); 
        objComando.Dispose();
        return ds;
    }

}