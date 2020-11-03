using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yensi_P2_AP1.Entidades
{

  public  class Proyecto
    {
        [Key]
        public int ProyectoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }


        [ForeignKey(" ProyectoID")]
        public List<ProyectoDetalle> ProyectoDetalles { get; set; }
        public Proyecto(int proyectoID, DateTime fecha, string descripcion)
        {
            ProyectoID = proyectoID;
            Fecha = fecha;
            Descripcion = descripcion;
        }

        public Proyecto()
        {
            ProyectoID = 0;
            Fecha = DateTime.Now;
            Descripcion = string.Empty;
            ProyectoDetalles = new List<ProyectoDetalle>();
        }
    }


}
