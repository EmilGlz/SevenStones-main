using System;

[Serializable]
public class RemotePlayer
{
    private readonly byte teamID;
    public byte TeamID { get => teamID;}

    private readonly byte place;
    public byte Place { get => place;}

    public byte actorNumber;
    public int score = 0;
    public byte stones = 0;
    public byte shoot = 0;
    public bool isDead;
    public byte lvl = 1;

    public RemotePlayer(byte teamid, byte pplace, byte actorNumber)
    {
        teamID = teamid;
        place = pplace;
        this.actorNumber = actorNumber;
    }

    public Pair<byte, byte> GetIdPlace()
    {
        return new Pair<byte, byte>(teamID, place);
    }
}