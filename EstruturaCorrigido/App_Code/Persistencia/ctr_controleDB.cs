using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class ctr_controleDB
{

    public static int Insert(ctr_controle controle)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "insert into ctr_controle(pla_id, usu_id, ctr_data_inicio,ctr_data_termino) ";
            sql += "values (?pla_id, ?usu_id, ?ctr_data_inicio, ?ctr_data_termino);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?ctr_data_inicio", controle.Ctr_data_inicio));
            objCommand.Parameters.Add(Mapped.Parametro("?ctr_data_termino", controle.Ctr_data_termino));
            //FK
            objCommand.Parameters.Add(Mapped.Parametro("?pla_id", controle.Pla_id.Pla_id)); //VERIFICAR
            objCommand.Parameters.Add(Mapped.Parametro("?usu_id", controle.Usu_id.Usu_id)); //VERIFICAR
            
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

    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao; 
        IDbCommand objComando; 
        IDataAdapter objDataAdapter; 
        objConexao = Mapped.Connection();
        objComando = Mapped.Command("SELECT * FROM ctr_controle", objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds); 
        objConexao.Close(); 
        objConexao.Dispose(); 
        objComando.Dispose();
        return ds;
    }
}