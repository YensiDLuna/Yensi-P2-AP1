using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yensi_P2_AP1.Entidades
{
   
  public class ProyectoDetalle
    {
        [Key]
        public int ID { get; set; }
        public int ProyectoID { get; set; }
        public int TipoID { get; set; }
        public string Requerimiento { get; set; }

        public int Tiempo { get; set; }

        public ProyectoDetalle(int iD, int proyectoID, int tipoID, string requerimiento, int tiempo)
        {
            ID = iD;
            ProyectoID = proyectoID;
            TipoID = tipoID;
            Requerimiento = requerimiento;
            Tiempo = tiempo;
        }
        public ProyectoDetalle()
        {
            ID = 0;
            ProyectoID = 0;
            TipoID = 0;
            Requerimiento = string.Empty;
            Tiempo = 0;
        }
    }


}
