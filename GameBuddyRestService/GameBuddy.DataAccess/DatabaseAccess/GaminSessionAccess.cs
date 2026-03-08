using GameBuddy.DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameBuddy.DataAccess.DatabaseAccess
{
    public class GamingSessionAccess : IGamingSessionAccess
    {
        private readonly string? _connectionString;

        public GamingSessionAccess(IConfiguration inConfig) {
        _connectionString = inConfig.GetConnectionString("gameBuddyConnection");
        }


        public int CreateGamingSession(GamingSession gSessionToAdd)
        {
            throw new NotImplementedException();
        }

        public int CreateRegistration(Gamer gamerToReg, GamingSession toSession)
        {
            throw new NotImplementedException();
        }

        public int DeleteGamingSessionById(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteRegistration(Gamer gamerDel, GamingSession gSessionDel)
        {
            throw new NotImplementedException();
        }

        public bool GamerIsRegisteredGamingSession(Gamer gamerCheck, GamingSession gSessionCheck)
        {
            throw new NotImplementedException();
        }


        /* Three possible returns:
         * A Gamer collection with content (normal case)
         * A Gamer collection  with no content (no rows found in table)
         * Null - Some error occurred
         */

        public IEnumerable<GamingSession>? GetGamingSessionAll()
        {
            List<GamingSession>? foundGamingSessions = null;
            GamingSession readGamingSession;
            // 
            string queryString = "SELECT id, game_description, starts_at_time[curent_number_players], [max_players] FROM GamingSession";
            using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand readCommand = new SqlCommand(queryString))
            {
                con.Open();
                //Execute read 
                SqlDataReader gSessionReader = readCommand.ExecuteReader();
                //Collect data
                foundGamingSessions = new List<GamingSession>();
                while ( gSessionReader.Read())
                {
                    readGamingSession = GetGamingSessionFromReader(gSessionReader);
                    foundGamingSessions.Add(readGamingSession);
                }

            }
            return foundGamingSessions;
        }

        public GamingSession? GetGamingSessionById(int targetId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGamingSession(GamingSession gSessionToUpdate)
        {
            throw new NotImplementedException();
        }

        public int UpdateGamingSessionNumbPlayers(GamingSession gSessionToUpdate, int newCurrNumPlayers)
        {
            throw new NotImplementedException();
        }


        private GamingSession GetGamingSessionFromReader(SqlDataReader gamingSessionReader) {
            GamingSession foundGamer;
            int tempId, tempCurrNumPlayers, tempMaxPlayers;
            string tempGameDescription;
            DateTime tempStartTime;
            // fetch values
            tempId = gamingSessionReader.GetInt32(gamingSessionReader.GetOrdinal("id"));
            tempGameDescription = gamingSessionReader.GetString(gamingSessionReader.GetOrdinal("game_description"));
            tempStartTime = gamingSessionReader.GetDateTime(gamingSessionReader.GetOrdinal("starts_at_time"));
            tempCurrNumPlayers = gamingSessionReader.GetInt32(gamingSessionReader.GetOrdinal("current_number:players"));
            tempMaxPlayers = gamingSessionReader.GetInt32(gamingSessionReader.GetOrdinal("max_players"));
            //Create object
            foundGamer = new GamingSession(tempId, tempGameDescription, tempStartTime, tempCurrNumPlayers, tempMaxPlayers);
            return foundGamer;

        }
    }
}
