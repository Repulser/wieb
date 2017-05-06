using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace Dictionary.Services
{
    public class CompatibilityChecker
    {
        #region CheckForSpeakers

        [DllImport("winmm.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern long GetNumDevs();

        public static bool CheckForSpeakers()
        {
            long i = GetNumDevs();
            bool hasSpeakers = (i > 0) ? true : false;

            return hasSpeakers;
        }

        #endregion

        #region CheckForMicrophone

        public static bool CheckForMicrophone()
        {
            bool hasMic = false;
            var recognizedText = new VoiceRecognizer().VoiceToString();

            if (recognizedText !=
                "Sorry, we could not detect your word." + " Please try again, or use a different text filling method.")
            {
                hasMic = true;
            }

            return hasMic;
        }

        #endregion

        #region CheckForInternet

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (Stream stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
    }
}