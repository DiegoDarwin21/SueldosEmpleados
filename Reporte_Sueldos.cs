namespace SueldosEmpleados
{
    class Reporte_Sueldos
    {
        int codigo;
        string nombre;
        float sueldoHora;
        int horasMes;
        float sueldoTotal;
        string mes;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public float SueldoHora { get => sueldoHora; set => sueldoHora = value; }
        public int HorasMes { get => horasMes; set => horasMes = value; }
        public string Mes { get => mes; set => mes = value; }
        public float SueldoTotal { get => sueldoTotal; set => sueldoTotal = value; }
       
    }
}
