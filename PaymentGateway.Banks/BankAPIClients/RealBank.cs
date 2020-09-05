﻿using PaymentGateway.Application.Business;
using PaymentGateway.Application.Interfaces.Bank;
using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Banks.BankClients
{
    public class RealBank : IBankClient
    {
        public async Task<BankResponse> ProcessPayment(BankRequest bankRequest)
        {
            //Actual real bank call comes here.
            throw new NotImplementedException();
        }
    }
}
