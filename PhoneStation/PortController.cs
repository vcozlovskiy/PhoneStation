using System.Collections.Generic;

namespace PhoneStation
{
    public class PortController
    {
        private IDictionary<string, Port> _ports;

        public IDictionary<string, Port> Ports { get { return _ports; } }
        
        public PortController(IDictionary<string, Port> ports)
        {
            _ports = ports;
        }
    }
}