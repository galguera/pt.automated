using ACC.PTAutomated.Model;
using ACC.PTAutomated.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACC.PTAutomated.ViewModels
{
    public class SequenceViewModel: BaseViewModel
    {

        private AutomatizationViewModel parentModel;

        private Sequence model;
        

        public ObservableCollection<EventViewModel> Events { get; set; }

        

        public SequenceViewModel(AutomatizationViewModel parentModel)
        {
            this.parentModel = parentModel;
            model = new Sequence();
            btnCmdAddEvent = new AddEventButtonCommand(this);
            btnCmdDelete = new DeleteSequenceButtonCommand(this);
            cmdLeftClickSequence = new SequenceLeftClickEvent(this);
            Events = new ObservableCollection<EventViewModel>();
            Events.Add(new EventViewModel(this));
            IsSelected = false;
            Id = model.Id.ToString(); 
        }

        public String Title
        {
            get { return model.Title; }

            set {
                model.Title = value;
                NotifyPropertyChanged("Title");
            }
        }

        public String Repeat
        {
            get { return model.Repeat.ToString(); }
            set
            {
                ushort val;
                if (!UInt16.TryParse(value, out val))
                {
                    return;
                }
                model.Repeat = val;
                NotifyPropertyChanged("Repeat");
            }
        }


        public String DelayAfter
        {
            get { return model.DelayAfter.ToString(); }
            set
            {
                double val;
                if (!Double.TryParse(value, out val))
                {
                    return;
                }
                model.DelayAfter = val;
                NotifyPropertyChanged("DelayAfter");
            }
        }

        public String DelayBefore
        {
            get { return model.DelayBefore.ToString(); }
            set
            {
                double val;
                if (!Double.TryParse(value, out val))
                {
                    return;
                }
                model.DelayBefore = val;
                NotifyPropertyChanged("DelayBefore");
            }
        }

        public TimeSpan DelayBeforeMiliseconds
        {
            get { return TimeSpan.FromSeconds( model.DelayBefore); }

        }




        private AddEventButtonCommand btnCmdAddEvent;
        public ICommand btnAddEvent
        {
            get
            {
                return btnCmdAddEvent;
            }
        }

        private DeleteSequenceButtonCommand btnCmdDelete;
        public ICommand btnDelete
        {
            get
            {
                return btnCmdDelete;
            }
        }

        private SequenceLeftClickEvent cmdLeftClickSequence;
        public ICommand OnSequenceSelect
        {
            get
            {
                return cmdLeftClickSequence;
            }
        }
        private bool _isSelected;
        public Boolean IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
                Background = _isSelected ? SelectedColor : BackgroundColor;
            }
        }

        private string _background;
        public String Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                NotifyPropertyChanged("Background");
            }
        }

       
        public void AddEvent()
        {
            Select();
            Events.Add(new EventViewModel(this));
        }


        public void Delete()
        {
            parentModel.DeleteSequence(Id);
        }

        internal void DeleteEvent(string id)
        {
            Events.Remove(Events.First(i => i.Id == id));
        }

        internal void Select()
        {
            
            parentModel.SelectSequence(this.Id);
        }

        internal void SelectEvent(string eventId)
        {
            if (!this.IsSelected)
            {
                parentModel.SelectSequence(this.Id);
            }

            DeselectAllEvents();
            var evnt = Events.First(i => i.Id == eventId);
            evnt.IsSelected = true;
            parentModel.IsEventSelected = true;
            parentModel.SelectedEvent = evnt;            
        }

        public void DeselectAllEvents()
        {
            Events.ToList().FindAll(c => c.IsSelected).ForEach(c => { c.IsSelected = false; });
            parentModel.IsEventSelected = false;
            parentModel.SelectedEvent = null; 
        }
    }
}
