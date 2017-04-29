using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNFichaDental
    {
        public static List<GCO_Ficha_Dental> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Ficha_Dental.ToList();
        }

        public static GCO_Ficha_Dental Obtener(string id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Ficha_Dental.FirstOrDefault(x => x.idFichaDental == id);
        }
    }
}
