using GCO.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCO.Negocio
{
    public class LNPaciente
    {
        public static List<GCO_Paciente> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Paciente.ToList();
        }

        public static GCO_Paciente Obtener(Guid id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Paciente.FirstOrDefault(x => x.idPaciente == id);
        }

        public static GCO_Paciente Obtener(string numDoc, string tipoDoc)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.GCO_Paciente.FirstOrDefault(x => x.NumDocIdentidad == numDoc && x.TipoDocIdentidad == tipoDoc);
        }

        public static void update(GCO_Paciente p)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            var pa = db.GCO_Paciente.FirstOrDefault(x => x.idPaciente == p.idPaciente);

            pa.TipoDocIdentidad = p.TipoDocIdentidad;
            pa.NumDocIdentidad = p.NumDocIdentidad;
            pa.nombresPaciente = p.nombresPaciente;
            pa.apePatPaciente = p.apePatPaciente;
            pa.apeMatPaciente = p.apeMatPaciente;
            pa.fechaNacPaciente = p.fechaNacPaciente;
            pa.PaisNacPaciente = p.PaisNacPaciente;
            pa.sexo = p.sexo;
            pa.telefono = p.telefono;
            pa.direccion = p.direccion;
            pa.distrito = p.distrito;
            pa.provincia = p.provincia;
            pa.departamento = p.departamento;

            db.SaveChanges();
        }
    }
}
