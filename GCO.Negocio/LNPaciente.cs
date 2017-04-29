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
        public static List<Paciente> ListarTodos()
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Paciente.ToList();
        }

        public static Paciente Obtener(int id)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            return db.Paciente.FirstOrDefault(x => x.idPaciente == id);
        }

        public static void update(Paciente p)
        {
            RicardoPalmaBDEntities db = new RicardoPalmaBDEntities();
            var pa = db.Paciente.FirstOrDefault(x => x.idPaciente == p.idPaciente);

            pa.TipoDocIdentidad = p.TipoDocIdentidad;
            pa.NumDocIdentidad = p.NumDocIdentidad;
            pa.nombresPaciente = p.nombresPaciente;
            pa.apePatPaciente = p.apePatPaciente;
            pa.apeMatPaciente = p.apeMatPaciente;
            pa.fechaNacPaciente = p.fechaNacPaciente;
            pa.PaisNacPaciente = p.PaisNacPaciente;
            pa.edad = p.edad;
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
