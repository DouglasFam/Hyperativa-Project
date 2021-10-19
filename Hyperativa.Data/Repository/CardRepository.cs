using Hyperativa.Business.Interfaces.IRepository;
using Hyperativa.Business.Models;
using Hyperativa.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyperativa.Data.Repository
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(AppDbContext context) : base(context) { }

        public async Task<Card> GetCard(string cardNumber)
        {
           return await Db.Cards
                 .Where(n => n.CardNumber == cardNumber).FirstOrDefaultAsync();
        }

        public bool ValidarCard(string numberCard)
        {
            var result = Db.Cards
                  .Where(n => n.CardNumber == numberCard).FirstOrDefaultAsync();

            if(result.Result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
