using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;

namespace Proyecto.Dialogs
{
    public class AlcoholDialog : ComponentDialog
    {

        //Constructor de nuestra nuestra clase
        public AlcoholDialog()
            : base(nameof(AlcoholDialog))
        {
            
            //Definimos los Dialogos
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt))); //El Dialogo de las opciones
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[] //El dialogo en cascada con los dialogos a mostrar
            {
                ChoiceCardStepAsync,
                ShowCardStepAsync,
            }));

            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> ChoiceCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            

            //Creamos el mensaje con las opciones dadas a el usuario
            var options = new PromptOptions()
            {
                Prompt = MessageFactory.Text("De que tipo de bebida quiere?."), //lo que se envia primero
                RetryPrompt = MessageFactory.Text("Lo siento no entendi, por favor seleccione una opcion o un numero del 1 al 5."), //Si se escoge una opcion invalida
                Choices = GetChoices(), //Las opciones, tomadas de la funcion correspondiente
            };

            // Prompt the user with the configured PromptOptions.
            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken); //envia el mensaje al usuario, y se manda a llamar el siguiente paso
        }


        private async Task<DialogTurnResult> ShowCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

            // Cards are sent as Attachments in the Bot Framework.
            // So we need to create a list of attachments for the reply activity.
            var attachments = new List<Attachment>(); //la variable en laque se guardaan las tarjetas para despues mostrarse

            // Reply to the activity we received with an activity.
            var reply = MessageFactory.Attachment(attachments); //la variable repl, que sera la encargada de mostrat los mensajes

            // Segun la opcion elegida, se despliegan las tarjetas corresponientes
            switch (((FoundChoice)stepContext.Result).Value)
            {
                case "Whiskey":
                    // Display an Adaptive Card
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel; //le decimos que se envien en forma de carrucel
                    reply.Attachments.Add(Cards.Cards.CreateAdaptiveCardAttachment()); //se añade al "carrucel" cada tarjeta, segun la bebida
                    reply.Attachments.Add(Cards.Cards.cafeIrlandesCard());
                    reply.Attachments.Add(Cards.Cards.manhattanCard());
                    break;
                case "Tequila":
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments.Add(Cards.Cards.TequilaSunrise());
                    reply.Attachments.Add(Cards.Cards.MexicanMule());
                    reply.Attachments.Add(Cards.Cards.NieblasDelCaribe());
                    break;
                case "Vodka":
                    // Display an AudioCard
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments.Add(Cards.Cards.lagunaAzulCard());
                    reply.Attachments.Add(Cards.Cards.vodkaTonicCard());
                    reply.Attachments.Add(Cards.Cards.coctelJulioCard());
                    break;
                case "Cerveza":
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments.Add(Cards.Cards.Michelada());
                    reply.Attachments.Add(Cards.Cards.LaCubana());
                    reply.Attachments.Add(Cards.Cards.CervezaTradicional());
                    break;
                case "Vino":
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments.Add(Cards.Cards.QueenCharlotte());
                    reply.Attachments.Add(Cards.Cards.Calimocho());
                    reply.Attachments.Add(Cards.Cards.Clericot());
                    break;
                default:
                    return await stepContext.ReplaceDialogAsync(nameof(MainDialog), null, cancellationToken); //Regresar al dialogo principal en caso de seleccionar la opcion de volver
                    break;
            }

            await stepContext.Context.SendActivityAsync(reply, cancellationToken); //se muestra el mensaje

            // Give the user instructions about what to do next
            await stepContext.Context.SendActivityAsync(MessageFactory.Text("Disfruta tu bebida"), cancellationToken);
            string status = "Gracias por usar Barman Bot, envia cualquier mensaje para comenzar de nuevo";
            await stepContext.Context.SendActivityAsync(status);

            return await stepContext.EndDialogAsync(); //fin del dialogo se regresa al dialogo principal
        }
        //las opciones de bebidas, primero va el valor y despues los sinonimos con los que se pueden seleccionar
        private IList<Choice> GetChoices()
        {
            var cardOptions = new List<Choice>()
            {
                new Choice() { Value = "Whiskey", Synonyms = new List<string>() { "Whisky","Bourbon" } },
                new Choice() { Value = "Tequila", Synonyms = new List<string>() { "Tequilongo" } },
                new Choice() { Value = "Vodka", Synonyms = new List<string>() { "absolute" } },
                new Choice() { Value = "Cerveza", Synonyms = new List<string>() { "Cheve","Chela" } },
                new Choice() { Value = "Vino", Synonyms = new List<string>() { "Tinto" } },
                new Choice() {Value = "Volver", Synonyms=new List<string>() {"Atras","Regresar","Cancelar"}}
            };

            return cardOptions;
        }

        
    }


}
