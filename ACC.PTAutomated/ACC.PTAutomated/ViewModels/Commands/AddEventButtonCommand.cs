using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACC.PTAutomated.ViewModels.Commands
{
    public class AddEventButtonCommand: BaseCommand
    {
        private SequenceViewModel viewModel;
        public AddEventButtonCommand(SequenceViewModel sequenceViewModel)
        {
            this.viewModel = sequenceViewModel;
        }

        
        public override void Execute(object parameter)
        {
            viewModel.AddEvent();
        }
    }
}
