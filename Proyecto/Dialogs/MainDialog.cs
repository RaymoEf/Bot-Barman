// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio CoreBot v4.6.2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;

using Proyecto.CognitiveModels;

namespace Proyecto.Dialogs
{
    public class MainDialog : ComponentDialog
    {
        //Se inicializan variables que podrian ser utiles
        protected readonly ILogger Logger;
        private readonly UserState _userState;

        // Dependency injection uses this constructor to instantiate MainDialog
        //Constructor del dialogo principal
        public MainDialog(ConversationState conversationState, UserState userState, ILogger<MainDialog> logger)
            : base(nameof(MainDialog))
        {
            _userState = userState;

            //se declaran los dialogos choice para las opciones
            //y WaterFall para los dialogos en cascada
            AddDialog(new AlcoholDialog());  //se delara el dialogo que inicializara a el dialogo de alcohol

            AddDialog(new ChoicePrompt(nameof(ChoicePrompt))); //Se declara el dialogo de las opciones
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), new WaterfallStep[] //Se declara la secuencia principal de dialogos
            {
                IntroStepAsync, //El dialog inicial, donde se pregunta al usuario que bebida tomara
                ActStepAsync,   //El dialogo donde se evaluan las opciones y se manda a llamar a los siguientes dialogos
                FinalStepAsync, //El dialogo final
            }));

            // The initial child Dialog to run.
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> IntroStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.PromptAsync(nameof(ChoicePrompt),
                 new PromptOptions
                 {
                     Prompt = MessageFactory.Text("Por favor Elija su tipo de bebida"), //Frase inicial de la pregunta
                     RetryPrompt = MessageFactory.Text("No entendi eso.  Por favor elija una opción de la lista."), //en caso de elegir una pcion inexistente se encia este mensaje
                     Choices = GetChoices(), //opciones
                 }, cancellationToken);

        }

        private async Task<DialogTurnResult> ActStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var reply =MessageFactory.Text("Sin eleccion");

            if (((FoundChoice)stepContext.Result).Value == "Alcoholica")
            {
                return await stepContext.BeginDialogAsync(nameof(AlcoholDialog), null, cancellationToken);
            }
            else if (((FoundChoice)stepContext.Result).Value == "Normal")
            {
                reply = MessageFactory.Text("Normal");
            }
            else
            {
                
            }

            await stepContext.Context.SendActivityAsync(reply, cancellationToken);

            return await stepContext.NextAsync(reply, cancellationToken);
        }

        private async Task<DialogTurnResult> FinalStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //string status = "Gracias por usar Barman Bot, envia cualquier mensaje para comenzar de nuevo";
            //await stepContext.Context.SendActivityAsync(status);
            return await stepContext.EndDialogAsync(null, cancellationToken);
        }

        //las opciones a elegir, con sus sinonimos
        private IList<Choice> GetChoices()
        {
            var Options = new List<Choice>()
            {
                new Choice() { Value = "Alcoholica", Synonyms = new List<string>() { "Alcohol","Alcoholicas" } },
                new Choice() { Value = "Normal", Synonyms = new List<string>() { "Normales" } },
                new Choice() { Value = "Cancelar", Synonyms = new List<string>() { "Atras","Adios","Volver" } },
            };

            return Options;
        }
    }
}
