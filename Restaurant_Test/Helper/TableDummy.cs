using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurantTest
{
    public class TableDummy : ITable
    {
        public bool estLibre { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public void installerClient() => throw new NotSupportedException();
        public void liberer() => throw new NotSupportedException();
    }
}
