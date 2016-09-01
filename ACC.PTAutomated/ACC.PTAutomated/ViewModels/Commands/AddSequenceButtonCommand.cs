using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACC.PTAutomated.ViewModels.Commands
{
    public class AddSequenceButtonCommand: BaseCommand
    {
        private AutomatizationViewModel viewModel;
        public AddSequenceButtonCommand(AutomatizationViewModel automatizationViewModel)
        {
            this.viewModel = automatizationViewModel;
        }
        
        public override void Execute(object parameter)
        {
            viewModel.AddSequence();
        }
    }
}
