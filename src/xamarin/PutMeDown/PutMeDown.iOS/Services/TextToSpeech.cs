using AVFoundation;

namespace PutMeDown.iOS
{
    public class TextToSpeech : IWarning
    {
        private readonly AVSpeechSynthesizer _speaker;

        public TextToSpeech()
        {
            _speaker = new AVSpeechSynthesizer();
        }

        public void Play(string message)
        {
			if (_speaker.Speaking)
				return;
            var speechUtterance = new AVSpeechUtterance(message)
                                  {
                                      Rate = AVSpeechUtterance.MaximumSpeechRate / 5,
                                      Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                                      Volume = 1f,
                                      PitchMultiplier = 1.0f
                                  };

            _speaker.SpeakUtterance(speechUtterance);
        }

        public void Stop()
        {
            _speaker.StopSpeaking(AVSpeechBoundary.Word);
        }
    }
}