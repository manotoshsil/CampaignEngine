using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignEngine.DomainObjects
{
   public  class ShoppingCartItem
    {
		public decimal UnitPrice { get; private set; }
		public int Quantity { get; private set; }
		public string Sku { get; set; }
		public decimal NetPrice { get; private set; }
		public bool IsBelongsToActiveCampaigns { get; set; }

		public ShoppingCartItem(string sku, int quantity, decimal unitPrice)
		{
			Sku = sku;
			Quantity = quantity;
			UnitPrice = unitPrice;
			NetPrice = unitPrice * Quantity;
		}

		public void AddQuantity(int quantity)
		{
			Quantity += quantity;
		}

		public void SetNewQuantity(int quantity)
		{
			Quantity = quantity;
		}
		public void SetPrice(decimal price)
		{
			NetPrice = price;
		}
	}
}
