using LeGrandRestaurant;
using System.Collections.Generic;

namespace LeGrandRestaurantTest
{
    internal class TableGenerator
    {
        private readonly TableBuilder _builder;

        public TableGenerator()
        {
            _builder = new TableBuilder();
        }

        public IEnumerable<Table> Generate(int nombre)
        {
            for (var i = 0; i < nombre; i++)
            {
                yield return _builder.Build();
            }
        }
    }
}
