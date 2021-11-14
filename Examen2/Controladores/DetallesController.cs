using Examen2.Modelos.DAO;
using Examen2.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Controladores
{
    public class DetallesController
    {

        DetallesView vista;
        TicketDAO ticketDAO = new TicketDAO();
        EstadoDAO estadoDAO = new EstadoDAO();
        TipoDAO tipoDAO = new TipoDAO();

        public DetallesController(DetallesView view)
        {
            vista = view;
            vista.Load += new EventHandler(Load);
        }

        private void Load(object sender, EventArgs e)
        {
            ListarTicket();
            ListarEstado();
            ListarTipo();
        }

        private void ListarTicket()
        {
           vista.dataGridView3.DataSource = ticketDAO.GetTicket();
        }

        private void ListarEstado()
        {
            vista.dataGridView2.DataSource = estadoDAO.GetEstado();
        }

        private void ListarTipo()
        {
            vista.dataGridView1.DataSource = tipoDAO.GetTipo();
        }
    }
}
