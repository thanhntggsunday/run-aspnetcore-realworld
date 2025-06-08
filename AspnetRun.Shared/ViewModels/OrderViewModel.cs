﻿using AspnetRun.Shared;
using System.ComponentModel.DataAnnotations;

namespace AspnetRun.Web.ViewModels
{
    public class OrderViewModel : TransactionalInformation
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        public AddressViewRequired? BillingAddress { get; set; }
        public AddressView? ShippingAddress { get; set; }
        public PaymentMethodView PaymentMethod { get; set; }
        public int Status { get; set; } = 1; // Processing

        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();

        public decimal GrandTotal
        {
            get
            {
                decimal grandTotal = 0;
                foreach (var item in Items)
                {
                    decimal? totalPrice = item.Data.TotalPrice;
                    grandTotal += totalPrice.Value;
                }

                return grandTotal;
            }
        }
    }

    public class AddressViewRequired
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? EmailAddress { get; set; }
        [Required]
        public string? PhoneNo { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? AddressLine { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? ZipCode { get; set; }
    }

    public class AddressView
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNo { get; set; }
        public string? CompanyName { get; set; }
        public string? AddressLine { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }

    public enum PaymentMethodView
    {
        Check = 1,
        BankTransfer = 2,
        Cash = 3,
        Paypal = 4,
        Payoneer = 5
    }

}
