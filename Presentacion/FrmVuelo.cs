using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Datos;
using System.Drawing.Text;
using System.Windows.Annotations;

namespace Presentacion
{
    public partial class FrmVuelo : Form
    {
        nVuelo nvuelo;
        List<Vuelo> vuelos;
        nAvion navion;
        List<Avion> aviones;
        private int vueloIdSeleccionado;


        public FrmVuelo()
        {
            InitializeComponent();
            nvuelo = new nVuelo();
            vuelos = new List<Vuelo>();
            navion = new nAvion();
            aviones = new List<Avion>();

        }

        private void MostrarListaVuelos(List<Vuelo> lista)
        {
            dataVuelo.Rows.Clear();
            foreach (Vuelo vuelo in lista)
            {
                dataVuelo.Rows.Add(
                    vuelo.Codigo_Vuelo,
                    vuelo.Identificador_Vuelo,
                    vuelo.Avion_Codigo,
                    vuelo.Llegada_Vuelo.ToShortDateString(),  
                    vuelo.Salida_Vuelo.ToShortDateString(),  
                    vuelo.Estado,
                    vuelo.Origen,
                    vuelo.Destino,
                    vuelo.Cantidad_de_Equipaje
                );
            }
        }

        private void CrearColumnaVuelo()
        {
            dataVuelo.Columns.Clear();
            dataVuelo.Columns.Add("Codigo_Vuelo", "Codigo_Vuelo");
            dataVuelo.Columns.Add("Identificador_Vuelo", "Identificador_Vuelo");
            dataVuelo.Columns.Add("Avion_Codigo", "Avion_Codigo");
            dataVuelo.Columns.Add("Llegada_Vuelo", "Llegada_Vuelo");
            dataVuelo.Columns.Add("Salida_Vuelo", "Salida_Vuelo");
            dataVuelo.Columns.Add("Estado", "Estado");
            dataVuelo.Columns.Add("Origen", "Origen");
            dataVuelo.Columns.Add("Destino", "Destino");
            dataVuelo.Columns.Add("Cantidad_de_Equipaje", "Cantidad_de_Equipaje");
        }

        private void FrmVuelo_Load(object sender, EventArgs e)
        {
            CrearColumnaVuelo();
            MostrarVuelos();
            CargarAviones();
        }

        private void MostrarVuelos()
        {
            vuelos = nvuelo.ListarVuelos();
            MostrarListaVuelos(vuelos);
        }

        private void CargarAviones()
        {
            aviones = navion.ListarAviones();
            cbCodigoAvion.DataSource = aviones;
            cbCodigoAvion.DisplayMember = "Modelo";
            cbCodigoAvion.ValueMember = "Codigo_Avion";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           

            if (textIdentificadorVuelo.Text == "" || cbCodigoAvion.Text == "" || cbEstados.Text == "" || textOrigen.Text == "" || textDestino.Text == "")
            {
                MessageBox.Show("Por favor, llene todos los campos.");
            }
            else
            {
                if (!int.TryParse(textCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número mayor a 0.");
                    return;
                }
                else
                {
                    Vuelo vuelo = new Vuelo();
                    vuelo.Identificador_Vuelo = textIdentificadorVuelo.Text;
                    vuelo.Avion_Codigo = (int)cbCodigoAvion.SelectedValue;
                    vuelo.Llegada_Vuelo = dateTimeLLegada.Value.Date;
                    vuelo.Salida_Vuelo = dateTimeSalida.Value.Date;
                    vuelo.Estado = cbEstados.Text;
                    vuelo.Origen = textOrigen.Text;
                    vuelo.Destino = textDestino.Text;
                    vuelo.Cantidad_de_Equipaje = cantidad;

                    string respuesta = nvuelo.Insertar(vuelo);
                    MessageBox.Show(respuesta);
                    MostrarVuelos();
                    LimpiarCampos();
                }
            }
        }

        private void dataVuelo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataVuelo.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataVuelo.SelectedRows[0];
                vueloIdSeleccionado = Convert.ToInt32(selectedRow.Cells["Codigo_Vuelo"].Value);

                Vuelo vueloSeleccionado = vuelos.FirstOrDefault(v => v.Codigo_Vuelo == vueloIdSeleccionado);

                if (vueloSeleccionado != null)
                {
                    textIdentificadorVuelo.Text = vueloSeleccionado.Identificador_Vuelo;
                    cbCodigoAvion.SelectedValue = vueloSeleccionado.Avion_Codigo;
                    dateTimeLLegada.Value = vueloSeleccionado.Llegada_Vuelo;
                    dateTimeSalida.Value = vueloSeleccionado.Salida_Vuelo;
                    cbEstados.Text = vueloSeleccionado.Estado;
                    textOrigen.Text = vueloSeleccionado.Origen;
                    textDestino.Text = vueloSeleccionado.Destino;
                    textCantidad.Text = vueloSeleccionado.Cantidad_de_Equipaje.ToString();

                   
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
          
            if (vueloIdSeleccionado != 0)
            {
                Vuelo vueloModificado = new Vuelo
                {
                    Codigo_Vuelo = vueloIdSeleccionado,
                    Identificador_Vuelo = textIdentificadorVuelo.Text,
                    Avion_Codigo = (int)cbCodigoAvion.SelectedValue,
                    Llegada_Vuelo = dateTimeLLegada.Value.Date,
                    Salida_Vuelo = dateTimeSalida.Value.Date,
                    Estado = cbEstados.Text,
                    Origen = textOrigen.Text,
                    Destino = textDestino.Text,
                    Cantidad_de_Equipaje = int.Parse(textCantidad.Text)
                };

                string respuesta = nvuelo.Editar(vueloModificado);
                MessageBox.Show(respuesta);

                MostrarVuelos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vuelo para modificar.");
            }

        }

        private void LimpiarCampos()
        {
            textIdentificadorVuelo.Text = "";
            cbCodigoAvion.SelectedIndex = -1;
            dateTimeLLegada.Value = DateTime.Now;
            dateTimeSalida.Value = DateTime.Now;
            cbEstados.SelectedIndex= -1;
            textOrigen.Text = "";
            textDestino.Text = "";
            textCantidad.Text = "";

            vueloIdSeleccionado = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (vueloIdSeleccionado != 0)
            {
                Vuelo vueloAEliminar = new Vuelo
                {
                    Codigo_Vuelo = vueloIdSeleccionado
                };

                string respuesta = nvuelo.Eliminar(vueloAEliminar);
                MessageBox.Show(respuesta);

                MostrarVuelos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vuelo para eliminar.");
            }
        }
        
    }
}
