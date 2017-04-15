using System.Speech.Synthesis;
using System.Threading.Tasks;
using UrbanDictionnet;

namespace Dictionary.Services
{
    internal class TextToSpeech
    {
        public TextToSpeech(DefinitionData definition, out SpeechSynthesizer synthesizer)
        {
            synthesizer = new SpeechSynthesizer();

            SpeechSynthesizer speechSynthesizer = synthesizer;
            Task.Factory.StartNew(
                () =>
                {
                    speechSynthesizer.Speak(
                        $"{definition.Word} . " +
                        $"by {definition.Author} , " +
                        $"means {definition.Definition} . " +
                        $"for example {definition.Example} . " +
                        $"{definition.ThumbsDown} dislikes, " +
                        $"{definition.ThumbsUp} likes");
                });
        }
    }
}