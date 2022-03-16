using System;
using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Franchise
    {
        private readonly Menu _menu;
        private readonly List<Restaurant> _restaurants;

        public Franchise(List<Restaurant> restaurants)
        {
            this._restaurants = restaurants;
            _menu = new Menu();
            foreach(var restaurant in restaurants)
            {
                restaurant.ImposerMenu(_menu);
            }
        }

        public IEnumerable<Restaurant> getRestaurants()
        {
            return this._restaurants;
        }

        public double getChiffreAffaire()
        {
            double chiffreDAffaire = 0;
            foreach(Restaurant restaurant in _restaurants)
            {
                foreach(Serveur serveur in restaurant.getServeurs())
                {
                    chiffreDAffaire = chiffreDAffaire + serveur.getChiffreAffaire();
                }
            }
            return chiffreDAffaire;
        }

        public void fixerPrix(Plat plat, decimal nouveauPrix)
            => _menu.fixerPrix(plat, nouveauPrix);
    }
}
