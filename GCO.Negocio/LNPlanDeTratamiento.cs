using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNPlanDeTratamiento
    {
        public static List<GCO_Plan_De_Tratamiento> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Plan_De_Tratamiento.ToList();
        }

        public static GCO_Plan_De_Tratamiento Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Plan_De_Tratamiento.FirstOrDefault(x => x.idPlanTratamiento == id);
        }
    }
}
