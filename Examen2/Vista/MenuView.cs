using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen2.Vista
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        TicketsView vistaTicket;
        DetallesView vistaDetalle;
        TiposView vistaTipos;
        EstadosView vistaEstados;

        private void toolStripTabItem3_Click(object sender, EventArgs e)
        {

            if (vistaTicket == null)
            {
                vistaTicket = new TicketsView();
                vistaTicket.MdiParent = this;
                vistaTicket.FormClosed += Vista_FormClosed;
                vistaTicket.Show();
            }
            else
            {
                vistaTicket.Activate();
            }
        }

        private void Vista_FormClosed(object sender, FormClosedEventArgs e)
            {
                 vistaTicket = null;
            }
     
        private void toolStripTabItem4_Click(object sender, EventArgs e)
        {
            if (vistaDetalle == null)
            {
                vistaDetalle = new DetallesView();
                vistaDetalle.MdiParent = this;
                vistaDetalle.FormClosed += VistaDetalles_FormClosed;
                vistaDetalle.Show();
            }
            else
            {
                vistaDetalle.Activate();
            }
        }

        private void VistaDetalles_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaDetalle = null;
        }

        private void toolStripTabItem1_Click(object sender, EventArgs e)
        {
            if (vistaTipos == null)
            {
                vistaTipos = new TiposView();
                vistaTipos.MdiParent = this;
                vistaTipos.FormClosed += VistaTipos_FormClosed;
                vistaTipos.Show();
            }
            else
            {
                vistaDetalle.Activate();
            }
        }
        private void VistaTipos_FormClosed(object sender, FormClosedEventArgs e)
        {
            vistaTipos = null;
        }

        private void toolStripTabItem2_Click(object sender, EventArgs e)
        {

            if (vistaEstados == null)
            {
                vistaEstados = new EstadosView();
                vistaEstados.MdiParent = this;
                vistaEstados.FormClosed += VistaEstados_FormClosed;
                vistaEstados.Show();
            }
            else
            {
                vistaEstados.Activate();
            }

        }
            private void VistaEstados_FormClosed(object sender, FormClosedEventArgs e)
            {
                vistaTipos = null;
            }
    }
}
