using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class usu_usuario
{
    private int usu_id; //PK
    private string usu_login;
    private string usu_senha;
    private tpu_tipo_usuario tpu_id; //FK
    private cid_cidade cid_id;  //FK

    public cid_cidade Cid_id
    {
        get { return cid_id; }
        set { cid_id = value; }
    }

    public tpu_tipo_usuario Tpu_id
    {
        get { return tpu_id; }
        set { tpu_id = value; }
    }
    

    public string Usu_senha
    {
        get { return usu_senha; }
        set { usu_senha = value; }
    }

    public string Usu_login
    {
        get { return usu_login; }
        set { usu_login = value; }
    }

    public int Usu_id
    {
        get { return usu_id; }
        set { usu_id = value; }
    }
}