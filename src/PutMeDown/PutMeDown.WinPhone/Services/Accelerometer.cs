using System;
using Microsoft.Devices.Sensors;

namespace PutMeDown.WinPhone
{
    public class Accelerometer : IAccelerometer
    {
        private readonly Microsoft.Devices.Sensors.Accelerometer _meter;

        public Accelerometer()
        {
            _meter = new Microsoft.Devices.Sensors.Accelerometer
                     {
                         TimeBetweenUpdates = TimeSpan.FromMilliseconds(100)
                     };
            _meter.CurrentValueChanged += CurrentValueChanged;
        }

        public void Start()
        {
            _meter.Start();
        }

        private void CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            var data = new SensorChange(Math.Abs(e.SensorReading.Acceleration.X * 10), Math.Abs(e.SensorReading.Acceleration.Y * 10), Math.Abs(e.SensorReading.Acceleration.Z * 10));
            RaiseChange(data);
        }

        public void Stop()
        {
            _meter.Stop();
        }

        public event EventHandler<SensorChange> OnChange;

        protected virtual void RaiseChange(SensorChange e)
        {
            EventHandler<SensorChange> handler = OnChange;
            if (handler != null) handler(this, e);
        }

    }
}