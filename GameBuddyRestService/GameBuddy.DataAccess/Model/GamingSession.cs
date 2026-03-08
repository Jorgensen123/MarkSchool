using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GameBuddy.DataAccess.Model
{
    public class GamingSession
    {
        public GamingSession() { }


        public GamingSession(int inId, string inGameDescription, DateTime inStartsAtTime, int inMaxPlayers, int inCurrentNumberPlayer = 0)
        {
            Id = inId;
            GameDescription = inGameDescription;
            StartsAtTime = inStartsAtTime;
            MaxPlayers = inMaxPlayers;
            CurrentNumberPlayers = inCurrentNumberPlayer; 
        }
            public int Id { get; set; }
        public string? GameDescription { get; set; } = string.Empty;
        public DateTime StartsAtTime { get; set; }
        public int CurrentNumberPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public List<Gamer>? Gamers { get; set; }





    }
}
