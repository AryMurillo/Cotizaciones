using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ImportarJson
{
    public partial class Cotizaciones : Form
    {
        private static string _path = "https://www.byma.com.ar/wp-admin/admin-ajax.php?action=get_panel&panel_id=0";
        string datosFromJson = getDatosFromJson(_path);
        List<destinoJson> datosBajados;
        int contador;
        public Cotizaciones()
        {
           InitializeComponent();
            datosBajados = Deserializar(datosFromJson);
            contador = datosBajados.Count;
            for (int i = 0; i < contador; i++)
            {
                CBoxDenominacion.Items.Add(datosBajados[i].Denominacion);
            }
        }
        public static string getDatosFromJson(string _path)
        {
            string datosFromJson;
            WebRequest oRequest = WebRequest.Create(_path);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader reader = new StreamReader(oResponse.GetResponseStream());
            datosFromJson = reader.ReadToEnd().Trim();
            datosFromJson = datosFromJson.Substring(16, datosFromJson.Length - 17);
            return datosFromJson;
         }
        public static List<destinoJson> Deserializar(string datosBajados)
        {
            List<destinoJson> datos = new List<destinoJson>();
            datos  = JsonConvert.DeserializeObject<List<destinoJson>>(datosBajados);
            return datos;
        }

        private void CBoxDenominacion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = CBoxDenominacion.SelectedIndex;
            TxApertura.Text = datosBajados[index].Apertura.ToString();
            TxCantidad_Nominal_Compra.Text = datosBajados[index].Cantidad_Nominal_Compra.ToString();
            TxCantidad_Nominal_Venta.Text = datosBajados[index].Cantidad_Nominal_Venta.ToString();
            TxCantidad_Operaciones.Text = datosBajados[index].Cantidad_Operaciones;
            TxCierre_Anterior.Text = datosBajados[index].Cierre_Anterior.ToString();
            TxEstado.Text = datosBajados[index].Estado;
            TxEx.Text = datosBajados[index].Ex;
            TxHora_Cotizacion.Text = datosBajados[index].Hora_Cotizacion;
            TxMaximo.Text = datosBajados[index].Maximo.ToString();
            TxMinimo.Text = datosBajados[index].Minimo.ToString();
            TxMonto_Operado_Pesos.Text = datosBajados[index].Monto_Operado_Pesos.ToString();
            TxPrecio_Compra.Text = datosBajados[index].Precio_Compra.ToString();
            TxPrecioPromedio.Text = datosBajados[index].Precio_Promedio.ToString();
            TxPrecio_Promedio_Ponderado.Text = datosBajados[index].Precio_Promedio_Ponderado.ToString();
            TxPrecio_Venta.Text = datosBajados[index].Precio_Venta.ToString();
            TxSimbolo.Text = datosBajados[index].Simbolo;
            TxTendencia.Text = datosBajados[index].Tendencia.ToString();
            TxTipo_Liquidacion.Text = datosBajados[index].Tipo_Liquidacion;
            TxUltimo.Text = datosBajados[index].Ultimo.ToString();
            TxVariacion.Text = datosBajados[index].Variacion.ToString();
            TxVencimiento.Text = datosBajados[index].Vencimiento;
            TxVolumen_Nominal.Text = datosBajados[index].Volumen_Nominal.ToString();
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }

    public class destinoJson
    {
        public float Apertura { get; set; }
        public int Cantidad_Nominal_Compra { get; set; }
        public int Cantidad_Nominal_Venta { get; set; }
        public string Cantidad_Operaciones { get; set; }
        public float Cierre_Anterior { get; set; }
        public string Denominacion { get; set; }
        public string Estado { get; set; }
        public string Ex { get; set; }
        public string Hora_Cotizacion { get; set; }
        public float Maximo { get; set; }
        public float Minimo { get; set; }
        public float Monto_Operado_Pesos { get; set; }
        public float Precio_Compra { get; set; }
        public float Precio_Promedio { get; set; }
        public float Precio_Promedio_Ponderado { get; set; }
        public float Precio_Venta { get; set; }
        public string Simbolo { get; set; }
        public int Tendencia { get; set; }
        public string Tipo_Liquidacion { get; set; }
        public float Ultimo { get; set; }
        public float Variacion { get; set; }
        public string Vencimiento { get; set; }
        public int Volumen_Nominal { get; set; }
    }
}
