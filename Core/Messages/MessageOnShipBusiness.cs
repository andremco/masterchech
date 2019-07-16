using System;
using Core.Enum;

namespace Core.Messages
{
    public class MessageOnShipBusiness
    {
        private string[] _responseBadLanguage {
            get{
                return new string[] { "um bocó", "um trouxa", "um sfilkis", "um vacilão",
                    "um tonto", "um tapado", "uma besta", "uma goiaba", "uma cibola",
                    "um miojo", "uma peteca", "uma laranja", "um bolo" };
            }
        }

        private string[] _responseTrouxa {
            get{
                var payload = _responseBadLanguage;

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

                default:
                    return false;
            }
        }

        public string[] ResponseTrouxa()
        {
            return _responseTrouxa;
        }

        public string GetBadLanguage()
        {
            var payload = _responseBadLanguage;

            var randomNumber = new Random().Next(payload.Length);

            return _responseBadLanguage[randomNumber];
        }
    }
}
