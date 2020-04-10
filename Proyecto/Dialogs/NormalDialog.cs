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
                //ChoiceCardStepAsync,
                //ShowCardStepAsync,
            }));

            InitialDialogId = nameof(WaterfallDialog);
        }

        /*private async Task<DialogTurnResult> ChoiceCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

        }

        private async Task<DialogTurnResult> ChoiceCardStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

        }*/
    }
}
