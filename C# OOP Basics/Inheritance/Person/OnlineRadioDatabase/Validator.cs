using System;

public class Validator
{
    public static void Song(string[] song)
    {
        if (song.Length != 3)
        {
            throw new InvalidSongException();
        }
    }

    public static void SongLength(string[] length)
    {
        if (length.Length != 2)
        {
            throw new InvalidSongLengthException();
        }

        try
        {
            int.Parse(length[0]);
            int.Parse(length[1]);
        }
        catch (Exception)
        {
            throw new InvalidSongLengthException();
        }
    }

    public static void NameLength(string name, int minLength, int maxLength, string field)
    {
        if (name.Length < minLength || name.Length > maxLength)
        {
            switch (field)
            {
                case "Artist":
                    throw new InvalidArtistNameException();
                case "Name":
                    throw new InvalidSongNameException();
            }
        }
    }

    public static void SongLengthArgs(int length, int maxLength, string field)
    {
        if (length < 0 || length > maxLength)
        {
            switch (field)
            {
                case "Minutes":
                    throw new InvalidSongMinutesException();
                case "Seconds":
                    throw new InvalidSongSecondsException();
            }
        }
    }
}