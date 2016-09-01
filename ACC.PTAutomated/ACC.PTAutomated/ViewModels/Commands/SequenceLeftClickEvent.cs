using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACC.PTAutomated.ViewModels.Commands
{
    public class SequenceLeftClickEvent: BaseCommand
    {
        private SequenceViewModel viewModel;
        public SequenceLeftClickEvent(SequenceViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        
        public override void Execute(object parameter)
        {
            viewModel.Select();
        }
    }
}
