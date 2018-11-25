public class Song
{
    private const int ArtistMinLength = 3;
    private const int ArtistMaxLength = 20;
    private const int NameMinLength = 3;
    private const int NameMaxLength = 30;
    public const int maxMinutes = 14;
    public const int maxSeconds = 59;

    private string artist;
    private string name;
    private int minutes;
    private int seconds;

    public string Artist
    {
        get { return artist; }
        set
        {
            Validator.NameLength(value, ArtistMinLength, ArtistMaxLength, "Artist");
            artist = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            Validator.NameLength(value, NameMinLength, NameMaxLength, "Name");
            name = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            Validator.SongLengthArgs(value, maxMinutes, "Minutes");
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            Validator.SongLengthArgs(value, maxSeconds, "Seconds");
            seconds = value;
        }
    }

    public Song(string artist, string name)
    {
        Artist = artist;
        Name = name;
    }
}