namespace UDV_WebApp.Core.Models
{
    public class CountResult : Model
    {
        public CountResult(Guid id, Dictionary<char, int> lettersCount) 
            : base(id)
        {
            LettersCount = lettersCount;
        }

        public Dictionary<char, int> LettersCount { get; set; }
    }
}
