using System;
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
    }
}
