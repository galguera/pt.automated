using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACC.PTAutomated.ViewModels.Commands
{
    public class EventLeftClickEvent: BaseCommand
    {
        private EventViewModel viewModel;
        public EventLeftClickEvent(EventViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        
        public override void Execute(object parameter)
        {
            viewModel.Select();
        }
    }
}
