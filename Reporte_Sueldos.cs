using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SueldosEmpleados
{
    class Reporte_Sueldos
    {
        string nombre;
        float sueldoHora;
        int horasMes;
        float sueldoTotal;

        public string Nombre { get => nombre; set => nombre = value; }

        public float SueldoHora { get => sueldoHora; set => sueldoHora = value; }
        public int HorasMes { get => horasMes; set => horasMes = value; }
        public float SueldoTotal { get => sueldoTotal; set => sueldoTotal = value; }
    }
}
