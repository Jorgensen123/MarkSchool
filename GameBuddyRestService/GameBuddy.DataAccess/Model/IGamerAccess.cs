namespace GameBuddy.DataAccess.Model
{
    public interface IGamerAccess
    {
        IEnumerable<Gamer>? GetGamerAll();
        Gamer? GetGamerById(int targetId);
        Gamer? GetGamerByUsername(string targetUsername);
        int CreateGamer(Gamer gamerToAdd);
        bool UpdateGamer(Gamer gamerToUpdate);
        bool DeleteGamerById(int id);

      }
}
