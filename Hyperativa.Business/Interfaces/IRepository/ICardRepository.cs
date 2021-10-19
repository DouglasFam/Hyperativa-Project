using Hyperativa.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hyperativa.Business.Interfaces.IRepository
{
   public interface ICardRepository : IRepository<Card>
    {
        bool ValidarCard(string numberCard);

        Task<Card> GetCard(string numberCard);

    }
}
