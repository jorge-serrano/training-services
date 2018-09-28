using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManHour.Model;

namespace ManHour.Services
{
    public class ServicioTNM
    {
        public static bool Agregar(string codigo, string descripcion)
        {
            TipoNomina tnm = new TipoNomina();
            tnm.Tipo = codigo;
            tnm.Descripcion = descripcion;
            tnm.HorasMes = 240;
            tnm.HorasDia = 8;
            tnm.DiasPeriodo = 30;
            RepositorioTNM.Agregar(tnm);
            return true;
        }

        public static IEnumerable<TipoNomina> Find(string  tipo)
        {
            return RepositorioTNM.Find(tipo);
        }
    }
}
