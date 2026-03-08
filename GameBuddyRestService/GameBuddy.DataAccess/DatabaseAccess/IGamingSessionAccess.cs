using GameBuddy.DataAccess.Model;

namespace GameBuddy.DataAccess.DatabaseAccess
{
    public interface IGamingSessionAccess
    {
        IEnumerable<GamingSession>? GetGamingSessionAll();
        GamingSession? GetGamingSessionById(int targetId);
        int CreateGamingSession(GamingSession gSessionToAdd);
        bool UpdateGamingSession(GamingSession gSessionToUpdate);
        int UpdateGamingSessionNumbPlayers(GamingSession gSessionToUpdate, int newCurrNumPlayers);
        int DeleteGamingSessionById(int id);
        int CreateRegistration(Gamer gamerToReg, GamingSession toSession);
        int DeleteRegistration(Gamer gamerDel, GamingSession gSessionDel);
        bool GamerIsRegisteredGamingSession(Gamer gamerCheck, GamingSession gSessionCheck);

    }
}
