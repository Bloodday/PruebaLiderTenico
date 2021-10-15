//PRUEBA OLIMPIA
//La función de la aplicación actual es calcular el saldo final de las cuentas de un "banco", para esto se consume un servicio que devuelve 
//las transacciones realizas a la cuentas.

//Paso 1: Hacer funcionar la aplicación. Debido al aumento de transacciones y al  colocar al servicio con SSL la aplicación actual esta fallando.
//Paso 2: Estructurar mejor el codigo. Uso de patrones, buenas practicas, etc.
//Paso 3: Optimizar el codigo, como se menciono en el paso 1 el aumento de transacciones ha causado que el calculo de los saldos se demore demasiado.
//Paso 4: Adicionar una barra de progreso al formulario. Actualizar la barra con el progreso del proceso, evitando bloqueos del GUI.

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsLiderEntrega.Helpers;
using WindowsLiderEntrega.Interfaces;
using WindowsLiderEntrega.Services;

namespace WindowsLiderEntrega
{
    public partial class Form1 : Form
    {
        private AutoMapper.IMapper mapper;
        ITestService testService;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mapper = AutoMapperConfiguration.GetMapper();

            ServicioPrueba.ServiceClient client = new ServicioPrueba.ServiceClient();

#if DEBUG
            client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
                new X509ServiceCertificateAuthentication()
                {
                    CertificateValidationMode = X509CertificateValidationMode.None,
                    RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                };
#endif

            testService = new TestService(client, mapper);
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            
            btnCalcular.Enabled = false;
            await Calcular();
            btnCalcular.Enabled = true;
        }

        private async Task Calcular()
        {
            lblTiempoTotal.Text = string.Empty;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            Models.Saldo[] saldos = await testService.CalcularSaldosAsync(progress => progressBar1.Value = progress);

            sw.Stop();

            lblTiempoTotal.Text = sw.ElapsedMilliseconds.ToString();

            //Enviamos los saldos finales
            await testService.SaveDataAsync("usuariop", "passwordp", saldos);
        }

    }
}
