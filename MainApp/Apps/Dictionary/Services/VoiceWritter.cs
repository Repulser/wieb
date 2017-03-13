using System.Speech.Recognition;
using System.Threading.Tasks;
using Dictionary.ViewModels;

namespace Dictionary.Services
{
    public class VoiceWritter
    {
        public string VoiceToString()
        {
            SpeechRecognizer recognizer = new SpeechRecognizer();
            string recognizedWord = "";

            Choices words = new Choices();
            words.Add(new string[]
            {
                "Title",
                "Definition",
                "Word"
            });

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(words);

            Grammar grammar = new Grammar(grammarBuilder);
            Task task = new Task(() =>
            {
                recognizer.LoadGrammar(grammar);
            });

            recognizer.SpeechRecognized += (s, a) =>
            {
                recognizedWord = a.Result.Text;
            };

            recognizer.SpeechRecognitionRejected += (sender, args) =>
            {
                recognizedWord =
                    "Sorry, we could not detect your word." + " Please try again, or use a different text filling method.";
            };

            return recognizedWord;
        }
    }
}