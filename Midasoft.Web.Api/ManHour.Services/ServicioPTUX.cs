using System;
using System.Collections.Generic;
using ManHour.Model;

namespace ManHour.Services
{
    public class ServicioPTUX
    {
        public static bool Agregar(Actividad actividad)
        {
            if (actividad.FechaMarcacion > DateTime.Now)
                throw new Exception("La fecha registrada es posterior a Hoy");
            actividad.FechaProgramada = actividad.FechaMarcacion;
            actividad.UsuarioRegistro = "TMENDEZ";
            actividad.UsuarioAutoriza = "SMENDEZ";
            return RepositorioPTUX.Insertar(actividad);
        }

        public static IEnumerable<Actividad> Obtener(int? id)
        {
            return RepositorioPTUX.Obtener(id);
        }

        public static void Actualizar(Actividad actividad)
        {
            if (actividad.FechaMarcacion > DateTime.Now)
                throw new ValidationException("La fecha registrada es posterior a Hoy");
            actividad.UsuarioRegistro = "TMENDEZ";
            actividad.UsuarioAutoriza = "SMENDEZ";
            RepositorioPTUX.Actualizar(actividad);
        }

        public static void Borrar(int idActividad)
        {
            RepositorioPTUX.Borrar(idActividad);
        }
    }
}
