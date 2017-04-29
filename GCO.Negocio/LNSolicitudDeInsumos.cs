using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNSolicitudDeInsumos
    {
        public static List<GCO_Solicitud_De_Insumos> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Solicitud_De_Insumos.ToList();
        }

        public static GCO_Solicitud_De_Insumos Obtener(string id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Solicitud_De_Insumos.FirstOrDefault(x => x.idSolicitudInsumos == id);
        }
    }
}
