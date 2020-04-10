// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.6.2

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Proyecto.Bots
{
    public class DialogAndWelcomeBot<T> : DialogBot<T>
        where T : Dialog
    {
        public DialogAndWelcomeBot(ConversationState conversationState, UserState userState, T dialog, ILogger<DialogBot<T>> logger)
            : base(conversationState, userState, dialog, logger)
        {
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                // Greet anyone that was not the target (recipient) of this message.
                // To learn more about Adaptive Cards, see https://aka.ms/msbot-adaptivecards for more details.
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var attachments = new List<Attachment>();
                    //var welcomeCard =GetWelcomeHeroCard();
                    var reply = MessageFactory.Text($"Hola {member.Name}");
                    var response = MessageFactory.Attachment(attachments);
                    response.Attachments.Add(GetWelcomeHeroCard().ToAttachment());
                    await turnContext.SendActivityAsync(response, cancellationToken);
                    await turnContext.SendActivityAsync(reply, cancellationToken);
                    //await Dialog.RunAsync(turnContext, ConversationState.CreateProperty<DialogState>("DialogState"), cancellationToken);
                }
            }
        }

        // Load attachment from embedded resource.
        public static HeroCard GetWelcomeHeroCard()
        {
            var heroCard = new HeroCard
            {
                Title = "Barman Bot",
                Subtitle = "Recomendaciones de bebidas",
                Text = " Bienvenido, soy Barman un Bot que te puede recomendar que beber.",
                Images = new List<CardImage> { new CardImage("https://media.istockphoto.com/vectors/mixologist-vector-id501794331?k=6&m=501794331&s=612x612&w=0&h=2JXH9ZMPL4CWooV1PrGl3NPf17mYveZEVvmxmars_G0=") },
                Buttons = new List<CardAction> { new CardAction(ActionTypes.MessageBack, "Empezar", value: "Empezar") },
            };

            return heroCard;
        }
    }
}

