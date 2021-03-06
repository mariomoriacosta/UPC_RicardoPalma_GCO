﻿using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNOrdenDePago
    {
        public static List<GCO_Orden_De_Pago> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Orden_De_Pago.ToList();
        }

        public static GCO_Orden_De_Pago Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Orden_De_Pago.FirstOrDefault(x => x.idOrdenDePago == id);
        }

        public static void add(GCO_Orden_De_Pago ordenDePago)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            db.GCO_Orden_De_Pago.Add(ordenDePago);
            db.SaveChanges();
        }
    }
}
