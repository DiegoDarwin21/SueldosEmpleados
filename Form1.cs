using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SueldosEmpleados
{
    public partial class Form1 : Form
    {
        List<Empleado> listaEmpleados = new List<Empleado>();
        List<Asistencia> listaAsistencia = new List<Asistencia>();
        List<Reporte_Sueldos> listaSueldos = new List<Reporte_Sueldos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leer();

           
           /* for(int x=0; x<listaEmpleados.Count; x++)
            {
                Reporte_Sueldos p = new Reporte_Sueldos();
                p.Nombre = listaEmpleados[x].Nombre;
               // comboBox1.Items.Add(p.Nombre);// se cargan de una vez los nombres al combo
                p.SueldoHora = listaEmpleados[x].SueldoHora;
                p.HorasMes = listaAsistencia[x].HorasMes;
                p.SueldoTotal = (p.SueldoHora * p.HorasMes);

                listaSueldos.Add(p);
            }*/
           for(int x=0; x<listaEmpleados.Count; x++)
            {
                for(int y=0; y<listaAsistencia.Count; y++)
                {
                    if (listaEmpleados[x].Codigo == listaAsistencia[y].Codigo)
                    {
                        Reporte_Sueldos em= new Reporte_Sueldos();
                        em.Codigo = listaEmpleados[x].Codigo;
                        em.Nombre = listaEmpleados[x].Nombre;
                        em.SueldoHora = listaEmpleados[x].SueldoHora;
                        em.HorasMes = listaAsistencia[y].HorasMes;
                        em.SueldoTotal = em.SueldoHora * em.HorasMes;
                        em.Mes = listaAsistencia[y].Mes;

                        listaSueldos.Add(em);

                    }
                }
            }
        }

        private void leer()
        {
            FileStream stream = new FileStream("Empleados.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Empleado personaTemp = new Empleado();

                personaTemp.Codigo = Convert.ToInt16(reader.ReadLine());
                personaTemp.Nombre = reader.ReadLine();
                personaTemp.SueldoHora = Convert.ToSingle(reader.ReadLine()); // es el método para convetir un string a float

                listaEmpleados.Add(personaTemp);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
            //ESTA PARTE ES PARA CARGAR LOS DATOS  A UNA LISTA
            FileStream stream2 = new FileStream("Asistencia.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);

            while (reader2.Peek() > -1)
            {
                Asistencia personaTemp = new Asistencia();

                personaTemp.Codigo = Convert.ToInt32(reader2.ReadLine());
                personaTemp.HorasMes = Convert.ToInt32(reader2.ReadLine());
                personaTemp.Mes = reader2.ReadLine(); 

                listaAsistencia.Add(personaTemp);
            }
            reader2.Close();
        }
        private void buttonCargar_Datos_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaEmpleados;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaAsistencia;
            dataGridView2.Refresh();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = listaSueldos;
            dataGridView3.Refresh();

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Codigo";
            comboBox1.DataSource = null;
            comboBox1.DataSource = listaEmpleados;
            comboBox1.Refresh();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textNombre.Text = " ";
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            /* int i = comboBox1.SelectedIndex;
             textNombre.Text = "Q." + listaSueldos[i].SueldoTotal;*/
            int noEmpleado = Convert.ToInt32(comboBox1.SelectedValue);
            Reporte_Sueldos empleadoSueldo = listaSueldos.Find(s => s.Codigo == noEmpleado);
            textNombre.Text = empleadoSueldo.Nombre;
            textSueldo.Text = "Q." + empleadoSueldo.SueldoTotal;
            textMes.Text = empleadoSueldo.Mes;

        }
    }
}
