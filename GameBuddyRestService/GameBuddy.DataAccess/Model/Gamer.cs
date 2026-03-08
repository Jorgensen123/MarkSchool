namespace GameBuddy.DataAccess.Model
{
    public class Gamer
    {
        public Gamer() { }

        public Gamer(string inUserName, string? inNickName = null)
        {
            UserName = inUserName;
            NickName = inNickName;
        }


        public Gamer(int inId, string inUserName, string? inNickName = null) : this(inUserName, inNickName)
        {
            Id = inId;
        }


        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? NickName { get; set; } = null;

    }
}

