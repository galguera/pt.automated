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
            IsSelected = false;
        }


        public String Title
        {
            get { return model.Title; }

            set
            {
                model.Title = value;
                NotifyPropertyChanged("Title");
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
                NotifyPropertyChanged("Background");
            }
        }


        public void Delete()
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

        public String X
        {
            get { return model.Data.X.ToString(); }
            set
            {
                uint val;
                if (!UInt32.TryParse(value, out val))
                {
                    return;
                }
                model.Data.X = val;
                NotifyPropertyChanged("X");
            }
        }

        public String Y
        {
            get { return model.Data.Y.ToString(); }
            set
            {
                uint val;
                if (!UInt32.TryParse(value, out val))
                {
                    return;
                }
                model.Data.Y = val;
                NotifyPropertyChanged("Y");
            }
        }

        

        public TimeSpan DelayBeforeMiliseconds { get { return TimeSpan.FromSeconds(model.DelayBefore); } }
    }
}
