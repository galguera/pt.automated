using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACC.PTAutomated.ViewModels.Commands
{
    public class DeleteEventButtonCommand: BaseCommand
    {
        private EventViewModel viewModel;

        public DeleteEventButtonCommand(EventViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.Delete();
        }
    }
}
