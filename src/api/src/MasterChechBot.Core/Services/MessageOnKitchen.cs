using MasterChechBot.Core.Enum;
using System;
using System.Linq;

namespace MasterChechBot.Core.Services
{
    public class MessageOnKitchen
    {
        private readonly Context.Context _context;

        public MessageOnKitchen(Context.Context context)
        {
            _context = context;
        }

        public ResponseForUser CommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/culinariadodia":
                case "/culinariadodia@masterchechbot":
                    return ResponseForUser.CulinariaDoDia;
                default:
                    return ResponseForUser.None;
            }
        }

        public bool IsCommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/culinariadodia":
                case "/culinariadodia@masterchechbot":
                    return true;
                default:
                    return false;
            }
        }

        public string GetRandomRecipe()
        {
            var nameDescription = RetrieveOneRandomDataFromContext((int)Category.NomePrato);

            var ingredients = RetrieveMultipleRandomDataFromContext((int)Category.Ingredientes);

            var preparation = RetrieveOneRandomDataFromContext((int)Category.ModoPreparo);

            //Format of message for telegram
            var message = (!string.IsNullOrEmpty(nameDescription)) ? $"*Prato* \U0001F372: {nameDescription} \n" : "";

            if (ingredients != null)
            { 
                message += $"*Ingredientes* \U0001F96B\U0001F961\U0001F95A\U0001F35D\U0001F9C2: \n";
                foreach (var item in ingredients)
                {
                    message += $"\t {item} \n";
                }
            }

            message += (!string.IsNullOrEmpty(preparation)) ? $"*Preparo* \U0001F52A\U0001F373: {preparation}" : "";

            return message;
        }

        public string RetrieveOneRandomDataFromContext(int id)
        {
            var random = new Random();
            var totalRecipes = _context.Recipes.Count(d => d.Category.Id == id);
            var toSkip = random.Next(0, totalRecipes);

            var recipes = _context.Recipes.Where(d => d.Category.Id == id).Skip(toSkip).Take(1).FirstOrDefault();

            return (recipes != null ? recipes.Descript : "");
        }

        public string[] RetrieveMultipleRandomDataFromContext(int id)
        {
            var random = new Random();
            var totalRecipes = _context.Recipes.Count(d => d.Category.Id == id);
            var toSkip = random.Next(0, totalRecipes);

            var recipes = _context.Recipes.Where(d => d.Category.Id == id).Skip(toSkip).Take(5).Select(d => d.Descript).ToArray();

            return (recipes != null ? recipes : null);
        }
    }
}
