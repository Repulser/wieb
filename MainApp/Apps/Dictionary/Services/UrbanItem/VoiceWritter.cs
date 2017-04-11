using System.Speech.Recognition;
using System.Threading.Tasks;

namespace Dictionary.Services
{
    public class VoiceWritter
    {
        public string VoiceToString()
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();
            string recognizedWord = "";

            var words = new Choices();
            words.Add("Title", "Definition", "Word");

            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(words);

            var grammar = new Grammar(grammarBuilder);
            new Task(() => { recognizer.LoadGrammar(grammar); });

            recognizer.SpeechRecognized += (s, a) => { recognizedWord = a.Result.Text; };

            recognizer.SpeechRecognitionRejected += (sender, args) =>
            {
                recognizedWord =
                    "Sorry, we could not detect your word." +
                    " Please try again, or use a different text filling method.";
            };

            return recognizedWord;
        }
    }
}