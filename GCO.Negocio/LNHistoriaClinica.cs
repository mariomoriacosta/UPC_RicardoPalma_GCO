using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNHistoriaClinica
    {
        public static List<HistoriaClinica> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.HistoriaClinica.ToList();
        }

        public static HistoriaClinica Obtener(int id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.HistoriaClinica.FirstOrDefault(x => x.nroHistoria == id);
        }
    }
}
