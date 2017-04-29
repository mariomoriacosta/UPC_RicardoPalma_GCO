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
        public static List<Cita> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Cita.ToList();
        }

        public static Cita Obtener(int id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Cita.FirstOrDefault(x => x.idPaciente == id);
        }
    }
}
