using System;

namespace PutMeDown
{
    public interface IAccelerometer
    {
        void Start();
        void Stop();
        event EventHandler<SensorChange> OnChange;
    }
}