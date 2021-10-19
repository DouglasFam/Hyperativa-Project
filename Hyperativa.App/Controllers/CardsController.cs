using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hyperativa.Business.Models;
using Hyperativa.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Hyperativa.Business.Interfaces.IRepository;
using Hyperativa.App.ViewModels;
using AutoMapper;
using Hyperativa.Business.Interfaces.IServices;
using System.Net.Http;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hyperativa.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : MainController
    {

        private readonly ICardService _cardService;
        private readonly IMapper _mapper;
       

        public CardsController(ICardService cardService,
                               IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<CardViewModel> GetCardByNumber(string cardNumber)
        {
            var card = _cardService.GetCard(cardNumber);

            if (card == Guid.Empty) return NotFound(new { message = "O Cartão não está cadastrado na base!" });
            return Ok(card);
        }

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardViewModel>> AdicionarCard(CardViewModel cardViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var card = _mapper.Map<Card>(cardViewModel);
            var result = await _cardService.Adicionar(card);

            if (!result) return NotFound(new { message = "Cartão já está cadastrado em nossa base!" });

            return Ok(card);

        }

        [HttpPost("upload")]
    public async Task<ActionResult<CardViewModel>> UpoladFile(List<IFormFile> fileupload)
        {
            var listCards = new List<CardViewModel>();
            var PostlistCards = new List<CardViewModel>();


            listCards = CreateListCards(fileupload);

            foreach (var card in listCards)
            {
                var mapCard = _mapper.Map<Card>(card);

                var result =  await _cardService.Adicionar(mapCard);

                if (result)
                {
                    card.Id = mapCard.Id;
                    PostlistCards.Add(card);
                }

            
               

                //if (!result) return NotFound(new { message = "Cartão já está cadastrado em nossa base!" });

                    //return Ok(card);
            }

            return Ok(PostlistCards);
          

        }    

        private List<CardViewModel> CreateListCards(List<IFormFile> files)
        {
            var cards = new List<CardViewModel>();

            foreach (var file in files)
            {
                using (var stream = new StreamReader(file.OpenReadStream()))
                {
                    string line = "";
                    string lineValues = "";
                    int count = 0;
                    while (!stream.EndOfStream)
                    {
                        line = stream.ReadLine();

                        if (line.StartsWith("C"))
                        {
                            int index = line.IndexOf('/');
                            if (index > 0)
                                line = line.Substring(0, index);

                            lineValues += line;
                            count++;
                        }

                        if(count > 0)
                        {
                            var arrayValues = lineValues.TrimEnd();



                            cards.Add(new CardViewModel()
                            {
                                Identifier = arrayValues[0].ToString(),
                                Lote = arrayValues[1].ToString(),
                                CardNumber = arrayValues.Substring(8)

                            }); ;

                            count = 0;
                            lineValues = "";

                        }
                    }
                }

            }

            return cards;
        }



        private async Task<bool> UploadFiles(IFormFile file, string prefixFile)
        {
            if (file.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", prefixFile, file.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Esse arquivo ja existe");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }

    }
}
