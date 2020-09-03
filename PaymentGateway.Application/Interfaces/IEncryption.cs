using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Application.Interfaces
{
    public interface IEncryption
    {
        string Encrypt(string CardNumber);
        string Decrypt(string cardNumber);
        string Mask(string cardNumber);
    }
}
