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
        public static List<GCO_HistoriaClinica> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_HistoriaClinica.ToList();
        }

        public static GCO_HistoriaClinica Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_HistoriaClinica.FirstOrDefault(x => x.idHistoriaClinica == id);
        }
    }
}
