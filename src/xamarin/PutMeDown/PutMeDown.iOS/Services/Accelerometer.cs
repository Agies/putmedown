using System;
using CoreMotion;
using Foundation;

namespace PutMeDown.iOS
{
    public class Accelerometer : IAccelerometer
    {
        private readonly CMMotionManager _motionManager;

        public Accelerometer()
        {
            _motionManager = new CMMotionManager();
        }

        public void Start()
        {
            _motionManager.StartAccelerometerUpdates(NSOperationQueue.CurrentQueue, OnSensorChanged);
        }

        private void OnSensorChanged(CMAccelerometerData data, NSError error)
        {
			var change = new SensorChange(Math.Abs(data.Acceleration.X * 10), Math.Abs(data.Acceleration.Y * 10), Math.Abs(data.Acceleration.Z * 10));;
            RaiseChange(change);
        }

        public event EventHandler<SensorChange> OnChange;

        protected virtual void RaiseChange(SensorChange e)
        {
            EventHandler<SensorChange> handler = OnChange;
            if (handler != null) handler(this, e);
        }

        public void Stop()
        {
            _motionManager.StopAccelerometerUpdates();
        }
    }
}