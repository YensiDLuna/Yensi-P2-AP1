using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Yensi_P2_AP1.DAL;
using Yensi_P2_AP1.Entidades;

namespace Yensi_P2_AP1.BLL
{
    class ProyectoBLL
    {
        public static bool Guardar(Proyecto proyecto)
        {
            bool guardado = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Proyectos.Add(proyecto) != null)
                {
                    guardado = contexto.SaveChanges() > 0;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return guardado;
        }

        public static bool Modificar(Proyecto proyecto)
        {
            bool modificado = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete from ProyectosDetalle where ProyectoID = {proyecto.ProyectoID}");
                foreach (var anterior in proyecto.ProyectoDetalles)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(proyecto).State = EntityState.Modified;
                modificado = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return modificado;
        }

        public static bool Eliminar(int Id)
        {
            bool eliminado = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Proyectos.Find(Id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

                eliminado = contexto.SaveChanges() > 0;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return eliminado;
        }

        public static Proyecto Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Proyecto proyecto = new Proyecto();

            try
            {
                proyecto = contexto.Proyectos.Include(x => x.ProyectoDetalles).Where(p => p.ProyectoID == Id).SingleOrDefault();

            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyecto;
        }

        public static List<Proyecto> GetList(Expression<Func<Proyecto, bool>> Proyecto)
        {
            List<Proyecto> lista = new List<Proyecto>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Proyectos.Where(Proyecto).AsNoTracking().ToList();
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
