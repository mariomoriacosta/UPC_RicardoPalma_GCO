using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNOrdenDeAtencion
    {
        public static List<GCO_Orden_De_Atencion> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Orden_De_Atencion.ToList();
        }

        public static GCO_Orden_De_Atencion Obtener(string id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Orden_De_Atencion.FirstOrDefault(x => x.idPlanTratamiento == id);
        }
    }
}
