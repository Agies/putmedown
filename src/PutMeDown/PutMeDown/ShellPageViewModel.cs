using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace PutMeDown
{
    public class ShellPageViewModel : ViewModelBase
    {
        private const string WarningMessage = "Put Me Down";
        private const double YThreshold = .8;

        private readonly IWarning _warning;
        private readonly IAccelerometer _accelerometer;

        private double _x;

        public double X
        {
            get { return _x; }
            set
            {
                if (_x == value) return;
                _x = value;
                RaisePropertyChanged();
            }
        }

        private double _y;

        public double Y
        {
            get { return _y; }
            set
            {
                if (_y == value) return;
                _y = value;
                RaisePropertyChanged();
            }
        }

        private double _z;

        public double Z
        {
            get { return _z; }
            set
            {
                if (_z == value) return;
                _z = value;
                RaisePropertyChanged();
            }
        }

        public ShellPageViewModel(IAccelerometer accelerometer, IWarning warning)
        {
            _warning = warning;
            _accelerometer = accelerometer;
            _accelerometer.OnChange += OnSensorChange;
            _accelerometer.Start();
        }

        private void OnSensorChange(object sender, SensorChange sensorChange)
        {
            X = sensorChange.X;
            Y = sensorChange.Y;
            Z = sensorChange.Z;
            ProcessSensorChange();
        }

        private void ProcessSensorChange()
        {
            if (Y > YThreshold)
            {
                _warning.Play(WarningMessage);
            }
            else
            {
                _warning.Stop();
            }
        }

        public void RestoreState(IDictionary<string, object> properties)
        {
            
        }
    }
}