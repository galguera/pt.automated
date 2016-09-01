using ACC.PTAutomated.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ACC.PTAutomated.ViewModels.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;
using UserControls = ACC.PTAutomated.UserControls;
using System.Windows;
using System.Threading;
using ACC.PTAutomated.Helpers;

namespace ACC.PTAutomated.ViewModels
{
    public class AutomatizationViewModel: BaseViewModel
    {
        
        
        private Automatization model = new Automatization();
        public ObservableCollection<SequenceViewModel> Sequences { get; set; }
       

        /// <summary>
        /// Constructor
        /// </summary>
        public AutomatizationViewModel()
        {
            btnCmdAddSequence = new AddSequenceButtonCommand(this);
            btnCmdExecute = new ExecuteButtonCommand(this);
            Sequences = new ObservableCollection<SequenceViewModel>();
            IsEventSelected = false;
            IsSequenceSelected = false;
        }

        

        public string TxtTitle
        {
            set {  model.Title = value; }
            get { return model.Title; }
        }

        public string TxtStopAt
        {
            set { model.StopAt = Convert.ToUInt32(value); }
            get { return model.StopAt.ToString(); }
        }


        private EventViewModel _selectedEvent;
        public EventViewModel SelectedEvent
        {
            set
            {
                _selectedEvent = value;
                NotifyPropertyChanged("SelectedEvent");
            }
            get
            {
                return _selectedEvent;
            }
        }


        private SequenceViewModel _selectedSequence;
        public SequenceViewModel SelectedSequence
        {
            set
            {
                _selectedSequence = value;
                NotifyPropertyChanged("SelectedSequence");
            }
            get
            {
                return _selectedSequence;
            }
        }

        private ExecuteButtonCommand btnCmdExecute;
        public ICommand btnExecute
        {
            get { return btnCmdExecute; }

        }

        private AddSequenceButtonCommand btnCmdAddSequence;
        public ICommand btnAddSequence
        {
            get
            {
                return btnCmdAddSequence;
            }
        }

        private bool _isEventSelected;
        public bool IsEventSelected
        {
            set {
                _isEventSelected = value;
                EventVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                NotifyPropertyChanged("IsEventSelected");
            }
            get
            {
                return _isEventSelected;
            }
        }

        private Visibility _eventVisibility;
        public Visibility EventVisibility
        {
            get
            {
                return _eventVisibility;
            }
            set
            {
                _eventVisibility = value;
                NotifyPropertyChanged("EventVisibility");
            }
        }

        private bool _isSequenceSelected;
        public bool IsSequenceSelected
        {
            get
            {
                return _isSequenceSelected;
            }
            set
            {
                _isSequenceSelected = value;
                SequenceVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                NotifyPropertyChanged("IsSequenceSelected");
            }
        }

        private Visibility _sequenceVisibility;
        public Visibility SequenceVisibility
        {
            get
            {
                return _sequenceVisibility;
            }
            set
            {
                _sequenceVisibility = value;
                NotifyPropertyChanged("SequenceVisibility");
            }
        }

        /// <summary>
        /// Adds a new sequence to the list
        /// </summary>
        public void AddSequence()
        {
            Sequences.Add(new SequenceViewModel(this));
        }


        public void SelectSequence(string sequenceId)
        {
            DeselectAllSequences();
            var sequence = Sequences.First(i => i.Id == sequenceId);
            sequence.IsSelected = true;
            IsSequenceSelected = true;     
            SelectedSequence = sequence;
        }

        public void DeselectAllSequences()
        {


            Sequences.ToList().FindAll(c => c.IsSelected).ForEach(c => { c.DeselectAllEvents();  c.IsSelected = false; });
            IsSequenceSelected = false;
            IsEventSelected = false;
            SelectedSequence = null;
            SelectedEvent = null;
        }


        public void DeleteSequence(string id)
        {
            var sequence = Sequences.First(i => i.Id == id);
            if (sequence.IsSelected)
            {
                IsSequenceSelected = false;
                IsEventSelected = false;
            }
            Sequences.Remove(sequence);
        }

        internal void Execute()
        {
            //
            ///
            Core core = new Core();
            foreach (var sequence in Sequences)
            {
                Thread.Sleep(sequence.DelayBeforeMiliseconds);
                
                foreach(var evnt in sequence.Events){
                     Thread.Sleep(evnt.DelayBeforeMiliseconds);
                     switch (evnt.Type) {                        
                         case DataTypes.Enums.EventsType.MouseMove:
                             core.MoveMouse(uint.Parse( evnt.X), uint.Parse( evnt.Y));
                             break;
                         case DataTypes.Enums.EventsType.LeftClick:
                             core.DoLeftClick(uint.Parse( evnt.X), uint.Parse( evnt.Y));
                             break;                        
                         case DataTypes.Enums.EventsType.RightClick:
                             core.DoRightClick(uint.Parse( evnt.X), uint.Parse( evnt.Y));
                             break;
                         case DataTypes.Enums.EventsType.KeyPress:
                             break;
                         default:
                             throw new ApplicationException(String.Format("The event's type '{0}' is not configured.", evnt.Type.ToString()));
                     }
                }
                
            }
        }
    }
}
