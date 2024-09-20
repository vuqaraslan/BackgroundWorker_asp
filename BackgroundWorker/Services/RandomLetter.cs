using System.ComponentModel;

namespace BackgroundWorker.Services
{
    public class RandomLetter
    {
        static public string GiveRandomLetter()
        {
            string[] randomLetters = new string[] { "A", "B", "C", "D", "F" };
            return randomLetters[0];
        }
    }
}
