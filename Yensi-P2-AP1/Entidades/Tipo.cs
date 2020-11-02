using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yensi_P2_AP1.Entidades
{
  public class Tipo
    {
        [Key]
        public int TipoID { get; set; }
        public string tipo { get; set; }

        public Tipo(int tipoID, string tipo)
        {
            TipoID = tipoID;
            this.tipo = tipo;
        }

        public Tipo()
        {
            TipoID = 0;
            this.tipo = string.Empty;
        }
    }
}
