using System;
using Core.Enum;

namespace Core.Messages
{
    public class MessageOnShipBusiness
    {
        private string[] _responseTrouxa {
            get{
                var payload = new string[] { "bocó", "trouxa", "sfilkis", "vacilão" };

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

        public ResponseForUser CommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/trouxa":
                case "/trouxa@zuerotopbot":
                    return ResponseForUser.Trouxa;

                default:
                    return ResponseForUser.None;
            }
        }

        public bool IsCommandForBot(string value)
        {
            switch (value.ToLower())
            {
                case "/trouxa":
                case "/trouxa@zuerotopbot":
                    return true;

                default:
                    return false;
            }
        }

        public string[] ResponseTrouxa()
        {
            return _responseTrouxa;
        }
    }
}
