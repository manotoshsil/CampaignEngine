using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignEngine.DomainObjects
{
   public class ShoppingCart
    {
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
		public IReadOnlyCollection<ShoppingCartItem> Items => _items.AsReadOnly();

		public void AddItemWithPriceAndQuantity(string sku, decimal unitPrice, int quantity = 1)
		{
			if (!Items.Any(i => i.Sku == sku))
			{
				_items.Add(new ShoppingCartItem(sku, quantity, unitPrice));
				return;
			}
			var existingItem = Items.FirstOrDefault(i => i.Sku == sku);
			existingItem?.AddQuantity(quantity);
		}

		public decimal GetCartTotal() =>
			Items.Sum(x => x.NetPrice);

	}
}
