

namespace KOL2_grB.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int IdAlbum { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}