using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yensi_P2_AP1.DAL;
using Yensi_P2_AP1.Entidades;

namespace Yensi_P2_AP1.BLL
{
  public class TipoBLL
    {
        public static List<Tipo> GetList()
        {
            List<Tipo> lista = new List<Tipo>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Tipos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
