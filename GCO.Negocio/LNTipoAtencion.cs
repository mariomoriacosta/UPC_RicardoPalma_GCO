using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNTipoAtencion
    {
        public static List<GCO_Tipo_Atencion> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Tipo_Atencion.ToList();
        }

        public static GCO_Tipo_Atencion Obtener(string id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Tipo_Atencion.FirstOrDefault(x => x.idTipoAtencion == id);
        }
    }
}
