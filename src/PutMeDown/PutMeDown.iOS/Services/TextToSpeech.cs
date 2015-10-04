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
            var speechUtterance = new AVSpeechUtterance(message)
                                  {
                                      Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
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