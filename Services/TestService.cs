using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WindowsLiderEntrega.Helpers;
using WindowsLiderEntrega.Interfaces;
using WindowsLiderEntrega.Models;
using WindowsLiderEntrega.Services.Extensions;

namespace WindowsLiderEntrega.Services
{
    public class TestService : ITestService
    {
        private readonly ServicioPrueba.ServiceClient _client;
        private readonly IMapper _mapper;

        public TestService(ServicioPrueba.ServiceClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<Saldo[]> CalcularSaldosAsync(Action<int> progressCallBack)
        {
            var responseData = _client.GetData("usuariop", "passwordp");

            //Variable donse se almacenan los saldos finales
            var saldos = new Dictionary<long, ServicioPrueba.Saldo>();
            var claves = new Dictionary<long, string>();

            for (int i = 0; i < responseData.Length; i++)
            {
                ServicioPrueba.Transaccion transaccion = responseData[i];
                var cuentaActual = transaccion.CuentaOrigen;

                if (!claves.ContainsKey(cuentaActual))
                {
                    string key = await GetKeyAsync(cuentaActual);
                    claves.Add(cuentaActual, key);
                }
                string claveCifrado = claves[cuentaActual];

                var movimientoActual = CryptoHelper.Desencriptar(claveCifrado, transaccion.TipoTransaccion);

                if (!saldos.ContainsKey(cuentaActual))
                {
                    saldos.Add(cuentaActual, new ServicioPrueba.Saldo
                    {
                        CuentaOrigen = cuentaActual,
                        Titular = transaccion.Titular,
                        ExtensionData = transaccion.ExtensionData
                    });
                }

                double comision = CalculationsHelper.CalcularComision(Convert.ToInt64(transaccion.ValorTransaccion));

                if (movimientoActual == "Debito")
                {
                    saldos[cuentaActual].SubstractFromBalance(transaccion.ValorTransaccion);
                }
                else
                {
                    saldos[cuentaActual].AddToBalance(transaccion.ValorTransaccion, comision);
                }

                int progress = calculateProgress(responseData, i);
                progressCallBack.Invoke(progress);
            }

            progressCallBack.Invoke(100);

            var result = _mapper.Map<Models.Saldo[]>(saldos?.Values.ToArray());

            return result;
        }

        public async Task<string> GetKeyAsync(long cuenta)
        {
            var task = Task.Run(() => _client.GetClaveCifradoCuenta("usuariop",
                                                                 "passwordp",
                                                                 cuenta));
            return await task;
        }

        public async Task SaveDataAsync(string user, string password, Saldo[] saldos)
        {
            var saldosParaEnviar = _mapper.Map<ServicioPrueba.Saldo[]>(saldos);
            await Task.Run(() => _client.SaveData(user, password, saldosParaEnviar));
        }

        private static int calculateProgress(ServicioPrueba.Transaccion[] transacciones, int i)
        {
            return 100 * (i + 1) / (transacciones.Length);
        }
    }
}
