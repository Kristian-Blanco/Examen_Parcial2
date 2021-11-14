using Examen2.Modelos.DAO;
using Examen2.Modelos.Entidades;
using Examen2.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2.Controladores
{
    public class EstadoController
    {

        EstadosView vista;
        EstadoDAO estadoDAO = new EstadoDAO();
        Estado estado = new Estado();
        string operacion = string.Empty;

        public EstadoController(EstadosView view)
        {
            vista = view;
            vista.btn_aceptar.Click += new EventHandler(Aceptar);
            vista.btn_limpiar.Click += new EventHandler(Nuevo);
            vista.Load += new EventHandler(load);
        }

        private void load(object sender, EventArgs e)
        {
            ListarEstado();
        }

        private void ListarEstado()
        {
            estadoDAO.GetEstado();
        }

        private void Nuevo(object serder, EventArgs e)
        {
            LimpiarControles();
        }

        private void Aceptar(object serder, EventArgs e)
        {
            if (vista.txt_estado.Text == "")
            {
                vista.errorProvider1.SetError(vista.txt_estado, "Ingrese un Estado");
                vista.txt_estado.Focus();
                return;
            }

            estado.Estados = vista.txt_estado.Text;
            operacion = "Nuevo";

            if (operacion == "Nuevo")
            {
                bool inserto = estadoDAO.InsertarEstado(estado);

                if (inserto)
                {

                    MessageBox.Show("Estado Creado Exitosamente", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el estado", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarControles()
        {
            vista.txt_estado.Clear();
        }
    }


}

