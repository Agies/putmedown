using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Speech.Tts;
using Object = Java.Lang.Object;

namespace PutMeDown.Droid
{
    public class TextToSpeech : Object, Android.Speech.Tts.TextToSpeech.IOnInitListener, IWarning
    {
        private readonly Android.Speech.Tts.TextToSpeech _speaker;
        private string _message;
        private bool _isInit;

        public TextToSpeech(Context context)
        {
            _speaker = new Android.Speech.Tts.TextToSpeech(context, this);
        }

        public void Play(string message)
        {
            if (!_isInit)
            {
                _message = message;
                return;
            }
            if (_speaker.IsSpeaking) return;
            _speaker.Speak(message, QueueMode.Flush, null);
        }

        public void Stop()
        {
            _speaker.Stop();
        }

        public void OnInit(OperationResult status)
        {
            _isInit = true;
            Play(_message);
        }
    }
}