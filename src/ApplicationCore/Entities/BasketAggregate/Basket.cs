﻿using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        public string BuyerId { get; private set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public string RecipientName { get; private set; }
        public string CheckoutMethod { get; private set; }
        public DateTime CourierArrivalTime { get; private set; }
        public string RecipientSurname { get; private set; }
        public string RecipientAddress { get; private set; }
        public string RecipientPhoneNo { get; private set; }

        public Basket(string buyerId)
        {
            BuyerId = buyerId;
        }

        public void AddItem(int catalogItemId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                _items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }

        public void SetNewRecipientName(string recipientName)
        {
            RecipientName = recipientName;
        }

        internal void SetNewCheckoutMethod(string checkoutMethod)
        {
            CheckoutMethod = checkoutMethod;
        }

        internal void SetNewCourierArrivalTime(string courierArrivalTime)
        {
            CourierArrivalTime = DateTime.Parse(courierArrivalTime);
        }

        internal void SetNewRecipientSurname(string recipientSurname)
        {
            RecipientSurname = recipientSurname;
        }

        internal void SetNewRecipientAddress(string recipientAddress)
        {
            RecipientAddress = recipientAddress;
        }

        internal void SetNewRecipientPhoneNo(string recipientPhoneNo)
        {
            RecipientPhoneNo = recipientPhoneNo;
        }
    }
}
