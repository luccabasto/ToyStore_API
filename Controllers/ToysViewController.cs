using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyStore_API.Data;
using ToyStore_API.Models;
using System.Collections.Generic;
using System.Linq;


namespace ToyStore_API.Controllers
{
    public class ToysViewController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Dados mockados para ambiente de desenvolvimento
            var brinquedos = new List<Toys>
            {
                new Toys
                {
                    Id_toy = 1,
                    Name_toy = "Carrinho Turbo",
                    Type_toy = "Veículo",
                    Classification_toy = 5,
                    Brand_toy = "Hot Wheels",
                    Price_toy = 59.90m
                },
                new Toys
                {
                    Id_toy = 2,
                    Name_toy = "Boneca Sereia",
                    Type_toy = "Boneca",
                    Classification_toy = 7,
                    Brand_toy = "Barbie",
                    Price_toy = 39.99m
                },
                new Toys
                {
                    Id_toy = 3,
                    Name_toy = "Jogo da Memória",
                    Type_toy = "Jogo Educativo",
                    Classification_toy = 6,
                    Brand_toy = "Estrela",
                    Price_toy = 24.50m
                }
            };

            return View(brinquedos);
        }
    }
}
