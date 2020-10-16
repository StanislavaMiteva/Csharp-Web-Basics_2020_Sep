using BatlteCards.Data;
using BattleCards.ViewModels.Cards;
using SUS.HTTP;
using SUS.MVCFramework;
using System.Linq;

namespace BattleCards.Controllers
{
    public class CardsController: Controller
    {
        private readonly ApplicationDbContext db;

        public CardsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd(AddCardInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }            

            if (this.Request.FormData["name"].Length<5)
            {
                return this.Error("Name should be at least 5 characters long.");
            }

            this.db.Cards.Add(new Card
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Attack = model.Attack,                
                Health = model.Health,
                Description = model.Description,
            });

            this.db.SaveChanges();                       

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var cardsViewModel = db.Cards
                .Select(x => new CardViewModel
                {
                    Name=x.Name,
                    Description=x.Description,
                    Attack=x.Attack,
                    Health=x.Health,
                    ImageUrl=x.ImageUrl,
                    Type=x.Keyword
                })
                .ToList();
            
            return this.View(cardsViewModel);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }
    }
}
