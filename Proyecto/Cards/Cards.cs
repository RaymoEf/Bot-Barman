using System.Collections.Generic;
using System.IO;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using AdaptiveCards.Rendering;
using AdaptiveCards;

namespace Proyecto.Cards
{
    public class Cards
    {

        //Aqui estan las funciones para crear las tarjetas
        //Copien el primero, cambien el nombre de la funcion y la ruta
        public static Attachment CreateAdaptiveCardAttachment()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "mintCard.json" }; //la ruta del archivo, solo cambiar el ultimo parametro por el nombre de tu archivo
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        public static Attachment cafeIrlandesCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "cafeirlandesCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        public static Attachment manhattanCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "manhattanCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        public static Attachment lagunaAzulCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "lagunaAzulCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
       
        public static Attachment vodkaTonicCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "vodkaTonicCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        public static Attachment coctelJulioCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "coctelJulioCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Shirleytemple()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Shirleytemple.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment mojitoCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "mojitoCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment pinadaCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "pinadaCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
       
        public static Attachment sanClementeCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "sanClementeCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment limonadaCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "limonadaCard.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment naranjadaCard()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "naranjada.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment TequilaSunrise()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "TequilaSunrise.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        public static Attachment MexicanMule()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "MexicanMule.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment NieblasDelCaribe()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "NieblasDelCaribe.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Michelada()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Michelada.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment LaCubana()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "LaCubana.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment CervezaTradicional()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "CervezaTradicional.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment QueenCharlotte()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "QueenCharlotte.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Calimocho()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Calimocho.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Clericot()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Clericot.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }

        
        public static Attachment Cocacola()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Cocacola.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Capuccino()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Capuccino.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment CafeExpresso()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "CafeExpresso.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment CafeAmericano()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "CafeAmericano.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Sabor()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Sabor.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Jamaica()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Jamaica.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Orchata()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Orchata.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment frutas()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "frutas.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Verde()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Verde.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
        public static Attachment Chicle()
        {
            // combine path for cross platform support
            string[] paths = { ".", "Cards", "Chicle.json" };
            var adaptiveCardJson = File.ReadAllText(Path.Combine(paths));

            var adaptiveCardAttachment = new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCardJson),
            };
            return adaptiveCardAttachment;
        }
    }
}
