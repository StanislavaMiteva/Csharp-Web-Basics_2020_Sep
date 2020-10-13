using BatlteCards.Data;
using BatlteCards.ViewModels;
using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.MVCFramework;
using System.Linq;

namespace BattleCards.Controllers
{
    public class CardsController: Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
            var dbContext = new ApplicationDbContext();

            dbContext.Cards.Add(new Card
            {
                Name = this.Request.FormData["name"],
                ImageUrl = this.Request.FormData["image"],
                Keyword = this.Request.FormData["keyword"],
                Attack = int.Parse(this.Request.FormData["attack"]),                
                Health = int.Parse(this.Request.FormData["health"]),
                Description = this.Request.FormData["description"],
            });

            dbContext.SaveChanges();                       

            return this.Redirect("/");
        }

        public HttpResponse All()
        {
            var db = new ApplicationDbContext();
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
            
            return this.View(new AllCardsViewModel { Cards=cardsViewModel});
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
