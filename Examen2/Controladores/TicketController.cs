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
   public class TicketController
    {

        TicketsView vista;
        TicketDAO ticketDAO = new TicketDAO();
        Ticket ticket = new Ticket();
        string operacion = string.Empty;

        public TicketController (TicketsView view)
        {
            vista = view;
            vista.btn_anadir.Click += new EventHandler(Anadir);
            vista.btn_nuevo.Click += new EventHandler(Nuevo);
            vista.Load += new EventHandler(load);
        }

        private void load (object sender, EventArgs e)
        {
            ListarTicket();
        }

        private void ListarTicket()
        {
            ticketDAO.GetTicket();
        }

        private void Nuevo(object serder, EventArgs e)
        {
            LimpiarControles();
        }

        private void Anadir(object serder, EventArgs e)
        {
            if (vista.txt_nombre.Text == "")
            {
                vista.errorProvider1.SetError(vista.txt_nombre, "Ingrese un nombre");
                vista.txt_nombre.Focus();
                return;
            }
            if (vista.txt_email.Text == "")
            {
                vista.errorProvider1.SetError(vista.txt_email, "Ingrese un email");
                vista.txt_email.Focus();
                return;
            }
            if (vista.txt_direccion.Text == "")
            {
                vista.errorProvider1.SetError(vista.txt_direccion, "Ingrese una clave");
                vista.txt_direccion.Focus();
                return;
            }

            ticket.Nombre = vista.txt_nombre.Text;
            ticket.Email = vista.txt_email.Text;
            ticket.Direccion = vista.txt_direccion.Text;
            operacion = "Nuevo";

            if (operacion == "Nuevo")
            {
                bool inserto = ticketDAO.InsertarTicket(ticket);
                
                if (inserto)
                {
                    MessageBox.Show("Ticket Creado Exitosamente", "Atención", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                   //ListarTicket();
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el usuario", "Atención", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void LimpiarControles()
        {
            vista.txt_id.Clear();
            vista.txt_nombre.Clear();
            vista.txt_email.Clear();
            vista.txt_direccion.Clear();
        }

    }
}
