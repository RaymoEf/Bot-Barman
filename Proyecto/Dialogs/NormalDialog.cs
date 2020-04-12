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
    public class NormalDialog : ComponentDialog
    {
        public NormalDialog() : base(nameof(NormalDialog))
        {
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt))); //El Dialogo de las opciones
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[] //El dialogo en cascada 
            {
                ChoiceCardStepAsync,
                ShowCardStepAsync,
            }));

            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> ChoiceCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var options = new PromptOptions()
            {
                Prompt = MessageFactory.Text("De que tipo de bebida quiere?."), //lo que se envia primero
                RetryPrompt = MessageFactory.Text("Lo siento no entendi, por favor seleccione una opcion o un numero del 1 al 5."), //Si se escoge una opcion invalida
                Choices = GetChoices(), //Las opciones, tomadas de la funcion correspondiente
            };
            return await stepContext.PromptAsync(nameof(ChoicePrompt), options, cancellationToken);
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
                case "Soda":
                    // Display an Adaptive Card
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel; //le decimos que se envien en forma de carrucel
                    ///reply.Attachments.Add(Cards.Cards.CreateAdaptiveCardAttachment()); //se añade al "carrucel" cada tarjeta, segun la bebida
                    reply.Attachments.Add(Cards.Cards.mojitoCard());
                    reply.Attachments.Add(Cards.Cards.Shirleytemple());
                    reply.Attachments.Add(Cards.Cards.sanClementeCard());
                    break;
                case "Jugo":
                    // Display an AnimationCard.
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel; //le decimos que se envien en forma de carrucel
                    //reply.Attachments.Add(Cards.Cards.CreateAdaptiveCardAttachment()); //se añade al "carrucel" cada tarjeta, segun la bebida
                    reply.Attachments.Add(Cards.Cards.limonadaCard());
                    reply.Attachments.Add(Cards.Cards.naranjadaCard());
                    //reply.Attachments.Add(Cards.GetAnimationCard().ToAttachment());
                    break;
                case "Coctel":
                    // Display an AudioCard
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments.Add(Cards.Cards.mojitoCard());
                    reply.Attachments.Add(Cards.Cards.sanClementeCard());
                    reply.Attachments.Add(Cards.Cards.Shirleytemple());
                    reply.Attachments.Add(Cards.Cards.pinadaCard());
                    break;
                case "Agua":
                    // Display a HeroCard.
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel; //le decimos que se envien en forma de carrucel
                    //reply.Attachments.Add(Cards.Cards.CreateAdaptiveCardAttachment()); //se añade al "carrucel" cada tarjeta, segun la bebida
                    reply.Attachments.Add(Cards.Cards.limonadaCard());
                    reply.Attachments.Add(Cards.Cards.naranjadaCard());
                    //reply.Attachments.Add(Cards.GetHeroCard().ToAttachment());
                    break;
                case "Café":
                    // Display a HeroCard.
                    //reply.Attachments.Add(Cards.GetHeroCard().ToAttachment());
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
        private IList<Choice> GetChoices()
        {
            var cardOptions = new List<Choice>()
            {
                new Choice() { Value = "Soda", Synonyms = new List<string>() { "Refresco","Chesco" } },
                new Choice() { Value = "Jugo", Synonyms = new List<string>() { "Zumo" } },
                new Choice() { Value = "Coctel", Synonyms = new List<string>() { "Combinado","Bebistrajo" } },
                 new Choice() { Value = "Agua", Synonyms = new List<string>() { "Agua" } },
                 new Choice() { Value = "Café", Synonyms = new List<string>() { "Cafetín","cafetucho" } },
                new Choice() {Value = "Volver", Synonyms=new List<string>() {"Atras","Regresar","Cancelar"}}
            };

            return cardOptions;
        }
    }

}
