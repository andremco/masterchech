using System;
using System.Linq;
using Core.Enum;
using Core.Repositories;

namespace Core.Messages
{
    public class MessageOnShipBusiness
    {
        private readonly UnitOfWork _uow;

        public MessageOnShipBusiness(UnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        private string[] _responsePhrases {
            get{
                return new string[] { "um bocó", "um trouxa", "um sfilkis", "um vacilão",
                    "um tonto", "um tapado", "uma besta", "uma goiaba", "uma cibola",
                    "um miojo", "uma peteca", "uma laranja", "um bolo", "um hamburguer", "uma batata" };
            }
        }


        public ResponseForUserEnum CommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/trouxa":
                case "/trouxa@masterchechbot":
                    return ResponseForUserEnum.Trouxa;

                case "/culinariadodia":
                case "/culinariadodia@masterchechbot":
                    return ResponseForUserEnum.CulinariaDoDia;

                default:
                    return ResponseForUserEnum.None;
            }
        }

        public bool IsCommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/trouxa":
                case "/trouxa@masterchechbot":
                    return true;

                case "/culinariadodia":
                case "/culinariadodia@masterchechbot":
                    return true;

                default:
                    return false;
            }
        }


        public string GetPhrase()
        {
            var payload = _responsePhrases;

            var randomNumber = new Random().Next(payload.Length);

            return _responsePhrases[randomNumber];
        }

        public string GetRandomRecipe()
        {
            var context = _uow.GetContext();

            //Nome do prato => Id == 1!!!
            var nameDescription = RetrieveOneRandomDataFromContext(context, 1);

            //Ingrediente => Id == 2!!!
            var ingredients = RetrieveMultipleRandomDataFromContext(context, 2);

            //Modo de preparo => Id == 3!!!
            var preparation = RetrieveOneRandomDataFromContext(context, 3);

            //Format of message for telegram
            var message = (!string.IsNullOrEmpty(nameDescription)) ? $"*Prato* \U0001F372: {nameDescription} \n" : "";

            if (ingredients != null)
            {
                int amountTotalIngredient = new Random().Next(0, 10); 
                message += $"*Ingredientes* \U0001F96B\U0001F961\U0001F95A\U0001F35D\U0001F9C2: \n";
                foreach (var item in ingredients)
                {
                    message += $"\t {amountTotalIngredient}x {item} \n";
                    //New value for amount!
                    amountTotalIngredient = new Random().Next(0, 10);
                }
            }

            message += (!string.IsNullOrEmpty(preparation)) ? $"*Preparo* \U0001F52A\U0001F373: {preparation}" : "";

            return message;
        }

        public string RetrieveOneRandomDataFromContext(Context.Context context, int id)
        {
            var random = new Random();
            var totalDescriptions = context.Descriptions.Count(d => d.Category.Id == id);
            var toSkip = random.Next(0, totalDescriptions);

            var description = context.Descriptions.Where(d => d.Category.Id == id).Skip(toSkip).Take(1).FirstOrDefault();

            return (description != null ? description.Descript : "");
        }

        public string[] RetrieveMultipleRandomDataFromContext(Context.Context context, int id)
        {
            var random = new Random();
            var totalDescriptions = context.Descriptions.Count(d => d.Category.Id == id);
            var toSkip = random.Next(0, totalDescriptions);

            var descriptions = context.Descriptions.Where(d => d.Category.Id == id).Skip(toSkip).Take(5).Select(d => d.Descript).ToArray();

            return (descriptions != null ? descriptions : null);
        }
    }
}
