﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leer();
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
        }
    }
}
