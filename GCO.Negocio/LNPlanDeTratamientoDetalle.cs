using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNPlanDeTratamientoDetalle
    {
        public static List<GCO_Plan_De_Tratamiento_Detalle> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Plan_De_Tratamiento_Detalle.ToList();
        }

        public static GCO_Plan_De_Tratamiento_Detalle Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Plan_De_Tratamiento_Detalle.FirstOrDefault(x => x.idPlanTratamiento == id);
        }

        public static void add(GCO_Plan_De_Tratamiento_Detalle o)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            db.GCO_Plan_De_Tratamiento_Detalle.Add(o);
            db.SaveChanges();
        }

    }
}
