using System.Collections.Generic;

namespace PhoneStation
{
    public class PortController
    {
        private ICollection<Port> _ports;

        public IEnumerable<Port> Ports { get { return _ports; } }
        
        public PortController(ICollection<Port> ports)
        {
            _ports = ports;
        }
    }
}