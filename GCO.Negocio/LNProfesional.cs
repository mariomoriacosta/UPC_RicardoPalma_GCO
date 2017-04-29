using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNProfesional
    {
        public static List<Profesional> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Profesional.ToList();
        }

        public static Profesional Obtener(int id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Profesional.FirstOrDefault(x => x.nroIdentificProf == id);
        }
    }
}
