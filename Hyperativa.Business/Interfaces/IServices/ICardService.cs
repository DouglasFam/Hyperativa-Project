using Hyperativa.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hyperativa.Business.Interfaces.IServices
{
   public interface ICardService : IDisposable
    {
        Task<bool> Adicionar(Card card);
        Task ValidarCard(Card card);

        Guid GetCard(string cardNumber);
    }
}
