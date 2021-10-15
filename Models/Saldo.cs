using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLiderEntrega.Models
{
    public class Saldo
    {
        public ExtensionDataObject ExtensionData { get; set; }
        public long CuentaOrigen{ get; set; }
        public double SaldoCuenta { get; set; }
        public string Titular { get; set; }
    }
}
    