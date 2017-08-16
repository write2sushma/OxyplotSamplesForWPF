using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TimeLogarithmicAxis
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            this.TimeNValues = new ObservableCollection<TimeNValue>();

            var random = new Random(31);
            var dateTime = DateTime.Today.Add(TimeSpan.FromHours(9));
            for (var pointIndex = 0; pointIndex < 50; pointIndex++)
            {
                this.TimeNValues.Add(new TimeNValue
                {
                    Time = dateTime,
                    Value = -200 + random.Next(1000),
                });
                dateTime = dateTime.AddYears(20);
            }
        }

        private ObservableCollection<TimeNValue> _timeNValues;

        public ObservableCollection<TimeNValue> TimeNValues
        {
            get
            {
                return this._timeNValues;
            }

            set
            {
                this._timeNValues = value;
                this.RaisePropertyChanged("Data");
            }
        }

        protected void RaisePropertyChanged(string property)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    public class TimeNValue
    {
        public DateTime Time { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0:HH:mm} {1:0.0}", this.Time, this.Value);
        }
    }
}