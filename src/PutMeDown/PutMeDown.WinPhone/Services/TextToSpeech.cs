using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Phone.Speech.Synthesis;

namespace PutMeDown.WinPhone
{
    public class TextToSpeech : IWarning
    {
        private SpeechSynthesizer _synth;
        private object syncObject = new object();
        private Task _currentSpeech;

        public TextToSpeech()
        {
            _synth = new SpeechSynthesizer();
        }

        public void Play(string message)
        {
            lock (syncObject)
            {
                if (_currentSpeech != null && !_currentSpeech.IsCompleted)
                {
                    return;
                }
                _currentSpeech = _synth.SpeakTextAsync(message).AsTask();
            }
        }

        public void Stop()
        {
            _synth.CancelAll();
        }
    }
}