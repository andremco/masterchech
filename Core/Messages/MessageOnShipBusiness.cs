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

        private string[] _responseTrouxa {
            get{
                var payload = _responsePhrases;

                var randomNumber = new Random().Next(payload.Length);

                return new string[]
                {
                    "Gus",
                    "Ta",
                    "Vo",
                    "Vc é " + payload[randomNumber]
                };
            }
        }

        public ResponseForUserEnum CommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/trouxa":
                case "/trouxa@zuerotopbot":
                    return ResponseForUserEnum.GustavoTrouxa;

                case "/proximotrouxa":
                case "/proximotrouxa@zuerotopbot":
                    return ResponseForUserEnum.ProximoTrouxa;

                case "/receitadodia":
                case "/receitadodia@zuerotopbot":
                    return ResponseForUserEnum.ReceitaDoDia;

                default:
                    return ResponseForUserEnum.None;
            }
        }

        public bool IsCommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/trouxa":
                case "/trouxa@zuerotopbot":
                    return true;

                case "/proximotrouxa":
                case "/proximotrouxa@zuerotopbot":
                    return true;

                case "/receitadodia":
                case "/receitadodia@zuerotopbot":
                    return true;

                default:
                    return false;
            }
        }

        public string[] ResponseTrouxa()
        {
            return _responseTrouxa;
        }

        public string GetPhrase()
        {
            var payload = _responsePhrases;

            var randomNumber = new Random().Next(payload.Length);

            return _responsePhrases[randomNumber];
        }

        public string GetRandomDescription()
        {
            var context = _uow.GetContext();
            var random = new Random();
            var totalDescriptions = context.Descriptions.Count();
            var toSkip = random.Next(0, totalDescriptions);

            var description = context.Descriptions.Skip(toSkip).Take(1).First();

            return description.Descript;
        }


    }
}
