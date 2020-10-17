using BatlteCards.Data;
using BattleCards.ViewModels.Cards;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }        

        public int AddCard(AddCardInputModel input)
        {
            var card = new Card
            {
                Name = input.Name,
                ImageUrl = input.Image,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description,
            };
            this.db.Cards.Add(card);
            this.db.SaveChanges();

            return card.Id;
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            return db.Cards
                .Select(x => new CardViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Attack = x.Attack,
                    Health = x.Health,
                    ImageUrl = x.ImageUrl,
                    Type = x.Keyword,
                    Id=x.Id,
                })
                .ToList();
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
            return this.db.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Name = x.Card.Name,
                    Description = x.Card.Description,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    ImageUrl = x.Card.ImageUrl,
                    Type = x.Card.Keyword,
                    Id = x.CardId,
                })
                .ToList();
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x=> x.UserId==userId && x.CardId==cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId,
            });
            this.db.SaveChanges();
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);

            if (userCard!=null)
            {
                this.db.UserCards.Remove(userCard);
                this.db.SaveChanges();
            }            
        }
    }
}
