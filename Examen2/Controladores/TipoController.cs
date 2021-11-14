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
    public class TipoController
    {

        TiposView vista;

        TipoDAO tipoDAO = new TipoDAO();
        Tipos tipos = new Tipos();

        string operacion = string.Empty;

        public TipoController(TiposView view)
        {
            vista = view;
            vista.btn_aceptar.Click += new EventHandler(Aceptar);
            vista.btn_limpiar.Click += new EventHandler(nuevo);
            vista.Load += new EventHandler(load);
        }


        private void load(object sender, EventArgs e)
        {
            ListarTipo();
        }

        private void ListarTipo()
        {
            tipoDAO.GetTipo();
        }


        private void nuevo(object serder, EventArgs e)
        {
            LimpiarControles();
            operacion = "Nuevo";
        }

        private void Aceptar(object serder, EventArgs e)
        {
            if (vista.txt_tipo.Text == "")
            {
                vista.errorProvider1.SetError(vista.txt_tipo, "Ingrese un tipo");
                vista.txt_tipo.Focus();
                return;
            }


            //ticket.Tipo = vista.txt_tipo.Text;
             tipos.Tipo = vista.txt_tipo.Text;
            operacion = "Nuevo";

            if (operacion == "Nuevo")
            {

               bool inserto = tipoDAO.InsertarTipo(tipos);
                //bool inserto = ticketDAO.InsertarTicket(ticket);

                if (inserto)
                {

                    MessageBox.Show("Tipo Creado Exitosamente", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                  
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el tipo", "Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                }
            }
        }
        private void LimpiarControles()
        {
            vista.txt_tipo.Clear();
        }
    }
}

