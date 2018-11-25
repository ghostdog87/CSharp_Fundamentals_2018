using System;
using System.Collections.Generic;

class StartUp
{
    static void Main(string[] args)
    {
        int songsCount = int.Parse(Console.ReadLine());
        List<Song> playlist = new List<Song>();

        for (int counter = 0; counter < songsCount; counter++)
        {
            string[] songInfo = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Validator.Song(songInfo);
                string artist = songInfo[0];
                string name = songInfo[1];
                string length = songInfo[2];
                Song song = new Song(artist, name);
                string[] lengthArgs = length.Split(':', StringSplitOptions.RemoveEmptyEntries);
                Validator.SongLength(lengthArgs);
                int minutes = int.Parse(lengthArgs[0]);
                int seconds = int.Parse(lengthArgs[1]);
                song.Minutes = minutes;
                song.Seconds = seconds;
                playlist.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine(GetPlaylistLength(playlist));
    }

    public static string GetPlaylistLength(List<Song> playlist)
    {
        int totalSeconds = 0;
        int totalMinutes = 0;

        foreach (var song in playlist)
        {
            totalSeconds += song.Seconds;
            totalMinutes += song.Minutes;
        }

        int seconds = totalSeconds % 60;
        totalMinutes += totalSeconds / 60;
        int minutes = totalMinutes % 60;
        int hours = totalMinutes / 60;

        string result = $"Playlist length: {hours}h {minutes}m {seconds}s";
        return result;
    }
}