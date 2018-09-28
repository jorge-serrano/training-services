using System;

namespace ManHour.Model
{
    public class Actividad
    {
        public int? Id { get; set; }
        public string CodigoEmpleado { get; set; }

        public DateTime? FechaProgramada { get; set; }

        public string CentroCosto { get; set; }

        public string TipoMovimiento { get; set; }

        public string UsuarioAutoriza { get; set; }

        public string UsuarioRegistro { get; set; }

        public string TipoRegistro { get; set; }

        public string Horario { get; set; }

        public string Directorio { get; set; }

        public DateTime? FechaMarcacion { get; set; }

        public string Novedad { get; set; }

        public string Observacion { get; set; }

        public string Dispositivo { get; set; }

        public string Compania { get; set; }

        public string Contrato { get; set; }


    }
}
