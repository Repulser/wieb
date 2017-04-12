using System.Speech.Recognition;
using System.Threading.Tasks;

namespace Dictionary.Services
{
    internal class VoiceRecognizer
    {
        public string VoiceToString()
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();

            BuildGrammar(recognizer);

            string recognizedWord = HandleRecognizer(recognizer);

            return recognizedWord;
        }

        private static string HandleRecognizer(SpeechRecognizer recognizer)
        {
            string recognizedWord = "";
            recognizer.SpeechRecognized += (s, a) => { recognizedWord = a.Result.Text; };

            recognizer.SpeechRecognitionRejected += (sender, args) =>
            {
                recognizedWord =
                    "Sorry, we could not detect your word." +
                    " Please try again, or use a different text typing method.";
            };
            return recognizedWord;
        }

        private static void BuildGrammar(SpeechRecognizer recognizer)
        {
            var words = new Choices();
            words.Add("Title", "Definition", "Word");

            var grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(words);

            var grammar = new Grammar(grammarBuilder);
            new Task(() => { recognizer.LoadGrammar(grammar); });
        }
    }
}