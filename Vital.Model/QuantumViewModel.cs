using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class QuantumViewModel
    {
        public QuantumViewResponse _ResponseModel { get; set; }
        public QuantumViewOutbound Outbound { get; set; }
        public QuantumViewOutbound Inbound { get; set; }
        public QuantumViewOutbound Combined { get; set; }
    }
}
