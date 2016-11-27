using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class usu_usuarioDB
{


    public static int Insert(usu_usuario usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "insert into usu_usuario (usu_login, usu_senha, cid_id, tpu_id) values(?usu_login, ?usu_senha, ?cid_id, ?tpu_id);";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?usu_login", usuario.Usu_login));
            objCommand.Parameters.Add(Mapped.Parametro("?usu_senha", usuario.Usu_senha));
            //FK
            objCommand.Parameters.Add(Mapped.Parametro("?cid_id", usuario.Cid_id.Cid_id));
            objCommand.Parameters.Add(Mapped.Parametro("?tpu_id", usuario.Tpu_id.Tpu_id)); 
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
        objComando = Mapped.Command("Select * from usu_usuario", objConexao);
        objDataAdapter = Mapped.Adapter(objComando);
        objDataAdapter.Fill(ds);
        objConexao.Close();
        objConexao.Dispose();
        objComando.Dispose();
        return ds;
    }

    public static usu_usuario SelectUsuario(usu_usuario usuario)
    {
        usu_usuario usu = null;
        IDbConnection objConexao;
        IDbCommand objCommando;
        string sql = "Select usu_id from usu_usuario where usu_login = ?usu_login;";
        objConexao = Mapped.Connection();
        objCommando = Mapped.Command(sql, objConexao);
        objCommando.Parameters.Add(Mapped.Parametro("?usu_login", usuario.Usu_login));
        IDataReader reader = objCommando.ExecuteReader();
        while (reader.Read())
        {
            usu = new usu_usuario();
            usu.Usu_id = Convert.ToInt32(reader["usu_id"]);
        }
        objConexao.Close();
        objConexao.Dispose();
        objCommando.Dispose();
        reader.Dispose();
        return usu;
    }

    

    public static int Delete(int usuario)
    {
        int retorno = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;
            string sql = "delete from usu_usuario where usu_id = ?usu_id";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?usu_id", usuario));
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



}