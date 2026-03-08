using GameBuddy.DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GameBuddy.DataAccess.DatabaseAccess
{
    public class GamerAccess : IGamerAccess
    {
        private readonly string? _connectionString;

        public GamerAccess(IConfiguration inConfig)
        {
            _connectionString = inConfig.GetConnectionString("GameBuddyConnection");
        }

        public int CreateGamer(Gamer gamerToAdd)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGamerById(int id)
        {
            throw new NotImplementedException();
        }

        /* Three possible returns:
        * A Gamer collection with content (normal case)
        * A Gamer collection  with no content (no rows found in table)
        * Null - Some error occurred
        */

        public IEnumerable<Gamer>? GetGamerAll()
        {
            List<Gamer>? foundGamers = null;
            Gamer readGamer;
            // 
            string queryString = "SELECT id, username, nickname FROM Gamer";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                con.Open();
                // Execute read 
                SqlDataReader gamerReader = readCommand.ExecuteReader();
                // Collect data
                foundGamers = new List<Gamer>();
                while (gamerReader.Read())
                {
                    readGamer = GetGamerFromReader(gamerReader);
                    foundGamers.Add(readGamer);
                }
            }
            return foundGamers;
        }


        /* Three possible returns:
        * A Gamer object (normal case)
        * An empty Gamer object (no match on id)
        * Null - Some error occurred
        */

        public Gamer? GetGamerById(int targetId)
        {
            Gamer foundGamer;
            //
            string queryString = "SELECT id, username, nickname FROM Gamer where id = @id";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand readCommand = new SqlCommand(queryString, con))
            {
                // Prepace SQL
                SqlParameter idParam = new SqlParameter("@Id", targetId);
                readCommand.Parameters.Add(idParam);
                //
                con.Open();
                // Execute read
                SqlDataReader gamerReader = readCommand.ExecuteReader();
                foundGamer = new Gamer();
                if (gamerReader.Read())
                {
                    foundGamer = GetGamerFromReader(gamerReader);
                }
            }
            return foundGamer;
        }

        public Gamer GetGamerByUsername(string targetUsername)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGamer(Gamer gamerToUpdate)
        {
            throw new NotImplementedException();
        }

        private Gamer GetGamerFromReader(SqlDataReader gamerReader)
        {
            Gamer foundGamer;
            bool differsFromNull; // Test for null Value in NickName
            int tempId;
            string tempUsername;
            string? tempNickname;
            // Fetch values from reader
            tempId = gamerReader.GetInt32(gamerReader.GetOrdinal("id"));
            tempUsername = gamerReader.GetString(gamerReader.GetOrdinal(" username"));
            differsFromNull =
            !gamerReader.IsDBNull(gamerReader.GetOrdinal("nickname"));
            tempNickname = differsFromNull ?
                gamerReader.GetString(gamerReader.GetOrdinal("nickname")) : null;
            //Create object
            foundGamer = new Gamer(tempId, tempUsername, tempNickname);
            return foundGamer;
        }

    }
}
