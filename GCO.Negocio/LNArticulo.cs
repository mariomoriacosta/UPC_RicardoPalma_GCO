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
        public static List<GCO_Articulo> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Articulo.ToList();
        }

        public static GCO_Articulo Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Articulo.Include("GCO_Solicitud_De_Insumos_Detalle").FirstOrDefault(x => x.idArticulo == id);
        }
    }
}
