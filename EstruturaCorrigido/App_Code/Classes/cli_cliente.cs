using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class cli_cliente
{
    private int cli_id; //PK
    private string cli_nome;
    private string cli_email;
    private string cli_cpf;
    private string cli_telefone;
    private string cli_status;
    private int cli_idade;
    private usu_usuario usu_id; //FK

    public usu_usuario Usu_id
    {
        get { return usu_id; }
        set { usu_id = value; }
    }

    public int Cli_idade
    {
        get { return cli_idade; }
        set { cli_idade = value; }
    }
     
    public string Cli_status
    {
        get { return cli_status; }
        set { cli_status = value; }
    }
   
    public string Cli_telefone
    {
        get { return cli_telefone; }
        set { cli_telefone = value; }
    }

    public string Cli_cpf
    {
        get { return cli_cpf; }
        set { cli_cpf = value; }
    }

    public string Cli_email
    {
        get { return cli_email; }
        set { cli_email = value; }
    }

    public string Cli_nome
    {
        get { return cli_nome; }
        set { cli_nome = value; }
    }
    
    public int Cli_id
    {
        get { return cli_id; }
        set { cli_id = value; }
    }
    
}