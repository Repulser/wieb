using System.Speech.Synthesis;
using System.Threading.Tasks;

namespace Dictionary.Services
{
    public class TextPronouncer
    {
        SpeechSynthesizer Reader = new SpeechSynthesizer();

        public void Speak(string title, string definition, bool isChecked, int delayBetweenTitleToDefinition)
        {
            Task task = new Task(() =>
            {
                Reader.Speak(title);
                Task.Delay(delayBetweenTitleToDefinition);
                Reader.Speak(definition);

            });

            while (isChecked == false)
            {
                Reader.SpeakAsyncCancelAll();
                break;
            }
        }
    }
}