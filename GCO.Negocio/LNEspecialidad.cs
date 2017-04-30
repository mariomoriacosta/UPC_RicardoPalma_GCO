using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNEspecialidad
    {
        public static List<GCO_Especialidad> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Especialidad.ToList();
        }

        public static GCO_Especialidad Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Especialidad.FirstOrDefault(x => x.idEspecialidad == id);
        }
    }
}
