using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLiderEntrega.Services.Extensions
{
    public static class SaldoExtensions
    {
        public static void SubstractFromBalance(this ServicioPrueba.Saldo saldo, double valorTransaccion)
        {
            saldo.SaldoCuenta -= valorTransaccion;
        }

        public static void AddToBalance(this ServicioPrueba.Saldo saldo, double valorTransaccion, double comision)
        {
            saldo.SaldoCuenta += valorTransaccion - comision;
        }
    }
}
