using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNConsultorio
    {
        public static List<GCO_Consultorio> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Consultorio.ToList();
        }

        public static GCO_Consultorio Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Consultorio.FirstOrDefault(x => x.idConsultorio == id);
        }
    }
}
