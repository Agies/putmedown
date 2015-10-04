using System;
using Android.Content;
using Android.Hardware;
using PutMeDown.Droid;
using Xamarin.Forms;
using Object = Java.Lang.Object;

[assembly: Dependency(typeof(Accelerometer))]

namespace PutMeDown.Droid
{
    public class Accelerometer : Object, IAccelerometer, ISensorEventListener
    {
        private readonly SensorManager _sensorManager;
        private readonly Sensor _sensor;

        public Accelerometer(Context context)
        {
            _sensorManager = (SensorManager) context.GetSystemService(Context.SensorService);
            _sensor = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);
        }

        public void Start()
        {
            _sensorManager.RegisterListener(this, _sensor, SensorDelay.Ui);
        }

        public event EventHandler<SensorChange> OnChange;

        protected virtual void RaiseChange(SensorChange e)
        {
            EventHandler<SensorChange> handler = OnChange;
            if (handler != null) handler(this, e);
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            
        }

        public void OnSensorChanged(SensorEvent e)
        {
            RaiseChange(new SensorChange(e.Values[0], e.Values[1], e.Values[2]));
        }

        public void Stop()
        {
            _sensorManager.UnregisterListener(this);
        }
    }
}