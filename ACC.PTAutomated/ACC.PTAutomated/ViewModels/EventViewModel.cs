using ACC.PTAutomated.DataTypes.Enums;
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
    public class EventViewModel: BaseViewModel
    {

        private readonly SequenceViewModel parentModel;



        private Event model;
        public EventViewModel(SequenceViewModel parentModel)
        {
            this.parentModel = parentModel;
            model = new Event();
            btnCmdDelete = new DeleteEventButtonCommand(this);
            cmdLeftClickEvent = new EventLeftClickEvent(this);
            Id = model.Id.ToString();
            Types = new ObservableCollection<EventType>() { 
                new EventType() { Id= 1, Code = "MouseMove", Description = "Mouse move" },
                new EventType() { Id= 2, Code = "RightClick", Description = "Right click" },
                new EventType() { Id= 3, Code = "LeftClick", Description = "Left click" },
                new EventType() { Id= 4, Code = "KeyPress", Description = "Key press" }
            };

            IsSelected = false;
        }

        public ObservableCollection<EventType> Types { get; set; }

        
        public EventType SelectedEventType { 
            get {
                return Types.Where(t => t.Id == (int)model.Type).FirstOrDefault();
            }
            set {
                
                try
                {
                    model.Type = (EventsType)Enum.ToObject(typeof(EventsType), value.Id);
                }
                catch
                {
                   
                }
                NotifyPropertyChanged();
            }
        }


        public String Title
        {
            get { return model.Title; }

            set
            {
                model.Title = value;
                NotifyPropertyChanged();
                //NotifyPropertyChangedExplicit("Title");
            }
        }

        public String DelayAfter
        {
            get { return model.DelayAfter.ToString(); }
            set
            {
                double val;
                if (Double.TryParse(value, out val))
                {
                    model.DelayAfter = val;
                }
                
                NotifyPropertyChanged();
                //NotifyPropertyChangedExplicit("DelayAfter");
            }
        }

        public String DelayBefore
        {
            get { return model.DelayBefore.ToString(); }
            set
            {
                double val;
                if (Double.TryParse(value, out val))
                {
                    model.DelayBefore = val;
                }
                
                NotifyPropertyChanged();
            }
        }

        public String X
        {
            get { return model.Data.X.ToString(); }
            set
            {
                uint val;
                if (UInt32.TryParse(value, out val))
                {
                    model.Data.X = val;
                }
                
                NotifyPropertyChanged();
            }
        }

        public String Y
        {
            get { return model.Data.Y.ToString(); }
            set
            {
                uint val;
                if (UInt32.TryParse(value, out val))
                {
                    model.Data.Y = val;
                }
                
                NotifyPropertyChanged();
            }
        }
        
        public TimeSpan DelayBeforeMiliseconds { get { return TimeSpan.FromSeconds(model.DelayBefore); } }

        #region ICommand Section


        private EventLeftClickEvent cmdLeftClickEvent;
        public ICommand OnEventSelect
        {
            get
            {
                return cmdLeftClickEvent;
            }
        }

        private DeleteEventButtonCommand btnCmdDelete;
        public ICommand btnDelete
        {
            get
            {
                return btnCmdDelete;
            }
        }


        #endregion


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
                NotifyPropertyChanged();
                //NotifyPropertyChangedExplicit("IsSelected");
                Background = _isSelected ? SelectedAlternativeColor : BackgroundAlternativeColor;
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
                NotifyPropertyChanged();
                //NotifyPropertyChangedExplicit("Background");
            }
        }


        internal void Delete()
        {
            parentModel.DeleteEvent(Id);
        }

        internal void Select()
        {
            parentModel.SelectEvent(this.Id);
        }

        public EventsType Type
        {
            get { return model.Type; }
        }


    }
}
