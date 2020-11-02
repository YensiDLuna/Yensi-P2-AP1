using System;
using System.Collections.Generic;
using System.Text;

namespace Yensi_P2_AP1.BLL
{
  public class Utilidades
    {
        public static int ToInt(string valor)

        {

            int retorno = 0;



            int.TryParse(valor, out retorno);



            return retorno;

        }

    }
}

