using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ctr_controle
{
    private int ctr_id; //PK
    private string ctr_data_inicio;
    private string ctr_data_termino;
    private usu_usuario usu_id; //FK
    private pla_plano pla_id; //FK

    public pla_plano Pla_id
    {
        get { return pla_id; }
        set { pla_id = value; }
    }

    public usu_usuario Usu_id
    {
        get { return usu_id; }
        set { usu_id = value; }
    }

    public int Ctr_id
    {
        get { return ctr_id; }
        set { ctr_id = value; }
    }

    public string Ctr_data_inicio
    {
        get { return ctr_data_inicio; }
        set { ctr_data_inicio = value; }
    }

    public string Ctr_data_termino
    {
        get { return ctr_data_termino; }
        set { ctr_data_termino = value; }
    }
}