using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class cid_cidade
{
    private int cid_id; //PK
    private string cid_nome; 

    public string Cid_nome
    {
        get { return cid_nome; }
        set { cid_nome = value; }
    }

    public int Cid_id
    {
        get { return cid_id; }
        set { cid_id = value; }
    }

}