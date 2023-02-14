﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ensayo
{
    public partial class Form1 : Form
    {
        string serviceDetenerIniciar = "Acceso a datos de usuarios_56aad63";
        public Form1()
        {
            InitializeComponent();
        }

        //Cambiar valor
        private void button1_Click(object sender, EventArgs e)
        {

            //cambiar atributos de un archivo
            string path = @"C:\Users\Crist\OneDrive\Documentos\Workspace\ASP.NET\proyectoastrans\Simplexity.AsTrans.RNDC.exe.config";
            if (!File.Exists(path))
            {
                MessageBox.Show("El archivo no existe");
            }

            FileAttributes attributes = File.GetAttributes(path);

            MessageBox.Show(path);

            



            //String SERVICEURL = ConfigurationManager.AppSettings["hola"];
            //MessageBox.Show(SERVICEURL);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StopService()
        {
            ServiceController sc = new ServiceController(serviceDetenerIniciar);

            try
            {
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    MessageBox.Show("El servicio ya se encuentra denido ");
                }
                if (sc != null || sc.Status == ServiceControllerStatus.Running)
                {

                    sc.Stop();
                    MessageBox.Show("Servicio denido exitosamente");
                    
                }

                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al detener el servicio:" + ex.Message);

            }


        }

        private void StartService()
        {
            ServiceController sc = new ServiceController(serviceDetenerIniciar);

            try
            {
                if (sc != null && sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();

                    MessageBox.Show("Servicio iniciado exitosamente");
                }
                sc.WaitForStatus(ServiceControllerStatus.Running);
                sc.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar el servicio:" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopService ();
        }
    }
}