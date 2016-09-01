using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ACC.PTAutomated.ViewModels
{
    public class DesignMockupMainWindowViewModel: BaseViewModel
    {
        public DesignMockupMainWindowViewModel()
        {

        }

        public ObservableCollection<SequenceViewModel> Sequences
        {
            get
            {
                return new ObservableCollection<SequenceViewModel>()
                {
                    new SequenceViewModel(null) { Title = "Nueva secuencia..." }
                };
            }
        }


        public ObservableCollection<EventViewModel> Events
        {
            get
            {
                return new ObservableCollection<EventViewModel>()
                {
                    new EventViewModel(null)
                };
            }
        }

        
        public Visibility SequenceVisibility
        {
            get
            {
                return Visibility.Visible;
            }
            
        }

        public Visibility EventVisibility
        {
            get
            {
                return Visibility.Visible;
            }

        }

    }
}
