﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentGateway.Application.Business
{
    public class PaymentRequest: Model
    {
        [Required]
        public Guid MerchantId { get; set; }
        [Required]
        public string CardHolderName { get; set; }
        [Required]
        [RegularExpression(@"([0-9]{4}\s?){4}", ErrorMessage = "Invalid Credit Card Number")]
        public string CardNumber { get; set; }
        [Required, MinLength(3), MaxLength(3)]
        [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "Invalid Card Cvv")]
        public string CardCvv { get; set; }
        [Required, MinLength(2), MaxLength(2)]
        public string ExpiryYear { get; set; }
        [Required, MinLength(2), MaxLength(2)]
        public string ExpiryMonth { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }
        [Required, MinLength(3), MaxLength(3)]
        public string Currency { get; set; }
    }
}
