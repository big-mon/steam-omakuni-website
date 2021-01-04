namespace SteamOmakuni.Models.Data
{
    public class Genre
    {
        public int GenreID { get; }
        public string Name { get; }

        public Genre(string id, string name)
        {
            GenreID = int.Parse(id);
            Name = name;
        }
    }
}