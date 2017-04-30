using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNCita
    {
        public static List<GCO_Cita> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Cita.ToList();
        }

        public static GCO_Cita Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Cita.FirstOrDefault(x => x.idPaciente == id);
        }
    }
}
