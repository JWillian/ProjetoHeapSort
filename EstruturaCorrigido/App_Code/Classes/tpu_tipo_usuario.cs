using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class tpu_tipo_usuario
{
    private int tpu_id; //PK
    private string tpu_descricao;

    public string Tpu_descricao
    {
        get { return tpu_descricao; }
        set { tpu_descricao = value; }
    }

    public int Tpu_id
    {
        get { return tpu_id; }
        set { tpu_id = value; }
    }
}