using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManHour.Model
{
    public class TipoNomina
    {
        public string Tipo{ get; set; }

        public string Descripcion { get; set; }

        public double HorasMes { get; set; }
        public double HorasDia { get; set; }
        public double DiasPeriodo { get; set; }
        public double DescuentoMinimo { get; set; }


    }
}
