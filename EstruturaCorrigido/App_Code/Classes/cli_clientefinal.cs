using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cli_clientefinal
/// </summary>
public class cli_clientefinal
{

    private ctr_controle ctr_id;
    private cli_cliente cli_id;

    public ctr_controle Ctr_id
    {
        get
        {
            return ctr_id;
        }

        set
        {
            ctr_id = value;
        }
    }

    public cli_cliente Cli_id
    {
        get
        {
            return cli_id;
        }

        set
        {
            cli_id = value;
        }
    }
}