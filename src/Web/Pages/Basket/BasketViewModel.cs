﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microsoft.eShopWeb.Web.Pages.Basket
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public string BuyerId { get; set; }

        [Display(Name = "Checkout Method")]
        public string CheckoutMethod { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Courier Arrival Time")]
        public DateTime CourierArrivalTime { get; set; }

        [Display(Name = "Recipient Name")]
        public string RecipientName { get; set; }

        [Display(Name = "Recipient Surname")]
        public string RecipientSurname { get; set; }

        [Display(Name = "Recipient Address")]
        public string RecipientAddress { get; set; }

        [Phone]
        [Display(Name = "Recipient Phone No")]
        public string RecipientPhoneNo { get; set; }


        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }
    }
}