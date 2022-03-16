using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Table
    {
        public bool estLibre { get; private set; } = true;
        
        public void installerClient()
        {
            if (!estLibre) throw new InvalidOperationException();
            estLibre = false;
        }

        public void liberer()
        {
            estLibre = true;
        }
    }
}
