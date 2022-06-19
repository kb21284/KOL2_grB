namespace KOL2_grB.Models
{
    public class MusicianTrack
    {
        public int IdTrack { get; set; }
        public int IdMusician { get; set; }
        public virtual Musician Musician { get; set; }
        public virtual Track Track { get; set; }
    }
}
