using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACC.PTAutomated.ViewModels.Commands
{
    public class ExecuteButtonCommand: BaseCommand
    {
        private AutomatizationViewModel viewModel;
        public ExecuteButtonCommand(AutomatizationViewModel vm)
        {
            this.viewModel = vm;
        }
        
        public override void Execute(object parameter)
        {
            viewModel.Execute();
        }
    }
}
