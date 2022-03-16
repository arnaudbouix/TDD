using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
	public interface IServeur
	{
    public IList<Commande> Commandes { get; set; }

    public double getChiffreAffaire();

    public void PrendCommande(Commande commande);

    public IList<Commande> GetCommandes();
  }
}
