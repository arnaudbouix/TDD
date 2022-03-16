using LeGrandRestaurant;
using System.Collections.Generic;

namespace LeGrandRestaurantTest
{
    internal class ServeurBuilder
    {
        private readonly IList<Commande> _commandes;

        public ServeurBuilder(bool isIntegration = false)
        {
            _commandes = isIntegration ? new DatabaseCommandeRepository() : new List<Commande>();
        }

        public Serveur Build() => new (_commandes);
    }
}
