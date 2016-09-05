using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ACC.PTAutomated.ViewModels.Commands;
using System.Windows.Input;
using System.Runtime.CompilerServices;


namespace ACC.PTAutomated.ViewModels
{
    

    public class BaseViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        internal void NotifyPropertyChangedExplicit(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /// <summary>
        /// Raises this object's PropertyChanged event using the name's property.
        /// </summary>
        /// <param name="caller">Do not pass the parameter value</param>
        private void OnPropertyChanged<T>([CallerMemberName]string caller = null)
        {
            NotifyPropertyChangedExplicit(caller);            
        }

        internal void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        internal string SelectedColor = "#2F8ED2";
        internal string SelectedAlternativeColor = "#0076C8";
        internal string BackgroundColor = "#3E3E42";
        internal string BackgroundAlternativeColor = "#4A6276";

        public string Id
        {
            set;
            get;
        }


    }
}
