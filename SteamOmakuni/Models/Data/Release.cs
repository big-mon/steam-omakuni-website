namespace SteamOmakuni.Models.Data
{
    public class Release
    {
        public bool IsCommingSonn { get; }
        public string Date { get; }

        public Release(bool isCommingSoon, string date)
        {
            IsCommingSonn = isCommingSoon;
            Date = date;
        }
    }
}