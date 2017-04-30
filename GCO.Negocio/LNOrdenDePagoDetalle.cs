using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNOrdenDePagoDetalle
    {
        public static List<GCO_Orden_De_Pago_Detalle> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Orden_De_Pago_Detalle.ToList();
        }

        public static GCO_Orden_De_Pago_Detalle Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Orden_De_Pago_Detalle.FirstOrDefault(x => x.idOrdenDePago == id);
        }

        public static void add(GCO_Orden_De_Pago_Detalle ordenDePago)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            db.GCO_Orden_De_Pago_Detalle.Add(ordenDePago);
            db.SaveChanges();
        }
        
    }
}
