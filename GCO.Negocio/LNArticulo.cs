using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
   public class LNArticulo
    {
        public static List<Articulo> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Articulo.ToList();
        }

        public static Articulo Obtener(int id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Articulo.Include("GCO_Solicitud_De_Insumos_Detalle").FirstOrDefault(x => x.codArticulo == id);
        }
    }
}
