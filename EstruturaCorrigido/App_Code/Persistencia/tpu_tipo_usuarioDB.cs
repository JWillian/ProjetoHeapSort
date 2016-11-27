using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class tpu_tipo_usuarioDB
{

    public static int Insert(tpu_tipo_usuario tipo_usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO tpu_tipo_usuario(tpu_descricao) values(?tpu_descricao); SELECT LAST_INSERT_ID();";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?tpu_descricao", tipo_usuario.Tpu_descricao));
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

    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao; 
        IDbCommand objComando; 
        IDataAdapter objDataAdapter; 
        objConexao = Mapped.Connection();
        objComando = Mapped.Command("select * from tpu_tipo_usuario order by tpu_descricao;", objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds); 
        objConexao.Close(); 
        objConexao.Dispose(); 
        objComando.Dispose();
        return ds;
    }


    //public static DataSet SelectbyId(int id)
    //{
    //    DataSet ds = new DataSet();
    //    IDbConnection objConexao; //faz a conexão com o banco
    //    IDbCommand objComando; // executa uma query e valida
    //    IDataAdapter objDataAdapter; //faz a ponte entre o banco e nossa memória
    //    objConexao = Mapped.Connection();
    //    objComando = Mapped.Command("select tpu_id , tpu_descricao from tpu_tipo_usuario where tpu_id = ?id;", objConexao);

    //    //está linha é a única alteração
    //    objComando.Parameters.Add(Mapped.Parametro("?id", id)); //é o id que esta sendo mandado

    //    objDataAdapter = Mapped.Adapter(objComando);
    //    objDataAdapter.Fill(ds); // carrega o ds = dataset
    //    objConexao.Close(); //fecha a conexao
    //    objConexao.Dispose(); //limpa a memória
    //    objComando.Dispose();
    //    return ds;
    //}

}