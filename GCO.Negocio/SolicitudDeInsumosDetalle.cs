using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class SolicitudDeInsumosDetalle
    {
        public static List<GCO_Solicitud_De_Insumos_Detalle> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Solicitud_De_Insumos_Detalle.ToList();
        }

        public static GCO_Solicitud_De_Insumos_Detalle Obtener(string id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Solicitud_De_Insumos_Detalle.FirstOrDefault(x => x.idSolInsumDet == id);
        }
    }
}
