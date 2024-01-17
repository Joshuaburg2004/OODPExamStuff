class Playlist
{
    private string[] _songs;
    public Playlist(int size) => _songs = new string[size];
    // custom Count Property
    public int Count { get => _songs.Length; }
    // return the appropriate song from _songs, or sets the appropriate song
    public string this[int i]
    {
        get => _songs[i];
        set
        {
            _songs[i] = value;
        }
    }
    // adds two playlists into a new Playlist, overloads the + operator
    public static Playlist operator +(Playlist pl1, Playlist pl2)
    {
        Playlist returnPlaylist = new(pl1.Count + pl2.Count);
        int i = 0;
        for(; i < pl1.Count + pl2.Count; i++)
        {
            if (i < pl1.Count)
                returnPlaylist[i] = pl1[i];
            else
                returnPlaylist[i] = pl2[i - pl1.Count];
        }
        return returnPlaylist;

    }
}
