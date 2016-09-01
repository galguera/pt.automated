using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACC.PTAutomated.ViewModels.Commands
{
    public class DeleteSequenceButtonCommand: BaseCommand
    {
        private SequenceViewModel viewModel;

        public DeleteSequenceButtonCommand(SequenceViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.Delete();
        }
    }
}
