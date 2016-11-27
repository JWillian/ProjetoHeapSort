using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class pla_plano
{
    private int pla_id; //PK
    private string pla_nome;
    private int pla_qtd_publicacao;
    private int pla_qtd_dias;
    private string pla_descricao;

    public string Pla_descricao
    {
        get { return pla_descricao; }
        set { pla_descricao = value; }
    }

    public int Pla_qtd_dias
    {
        get { return pla_qtd_dias; }
        set { pla_qtd_dias = value; }
    }

    public int Pla_qtd_publicacao
    {
        get { return pla_qtd_publicacao; }
        set { pla_qtd_publicacao = value; }
    }

    public string Pla_nome
    {
        get { return pla_nome; }
        set { pla_nome = value; }
    }

    public int Pla_id
    {
        get { return pla_id; }
        set { pla_id = value; }
    }
}