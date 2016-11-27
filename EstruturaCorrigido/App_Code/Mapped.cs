using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// importar
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

public class Mapped
{
    //Abrir a conexão
    public static IDbConnection Connection()
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.AppSettings["srtConexao"]);
        objConexao.Open();
        return objConexao;
    }

    // Validar o comando
    public static IDbCommand Command(string query, IDbConnection objConexao)
    {
        IDbCommand command = objConexao.CreateCommand();
        command.CommandText = query;
        return command;
    }

    //Ponte
    public static IDataAdapter Adapter(IDbCommand command)
    {
        IDbDataAdapter adap = new MySqlDataAdapter();
        adap.SelectCommand = command;
        return adap;
    }

    // Parametrização - Validar os dados
    public static IDbDataParameter Parametro(string nomeDoParametro, object valor)
    {
        return new MySqlParameter(nomeDoParametro, valor);
    }
}