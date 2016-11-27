using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class cid_cidadeDB
{

    public static int Insert(cid_cidade cidade)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "INSERT INTO cid_cidade(cid_nome) values(?cid_nome);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?cid_nome", cidade.Cid_nome));
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
        objComando = Mapped.Command("select * from cid_cidade order by cid_nome;", objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds); 
        objConexao.Close(); 
        objConexao.Dispose(); 
        objComando.Dispose();
        return ds;
    }
}