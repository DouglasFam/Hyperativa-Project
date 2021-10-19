using Hyperativa.Business.Interfaces.IRepository;
using Hyperativa.Business.Interfaces.IServices;
using Hyperativa.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hyperativa.Business.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<bool> Adicionar(Card card)
        {
            if (!_cardRepository.ValidarCard(card.CardNumber)) 
            {
                 await _cardRepository.Adicionar(card);
                return true;
            }

            return false;
            
        }

        public Guid GetCard(string cardNumber)
        {
            var result = _cardRepository.GetCard(cardNumber);

            if (result.Result != null)
                return result.Result.Id;
            else
                return Guid.Empty;
        }

        public Task ValidarCard(Card card)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _cardRepository?.Dispose();
        }

       
    }
}
