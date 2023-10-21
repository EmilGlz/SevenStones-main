using UnityEngine;

public static class Settings
{
    private static User user;
    public static User User
    {
        get => user;
        set => user = value;
    }

    public static User ResettedUser()
    {
        var res = new User()
        {
            userId = "",
            nickName = "Player" + Random.Range(0, 100),
            xp = 0,
            starCoin = 0,
            level = 1,
            ssCoin = 500,
            gs = new GeneralStats
            {
                generalWin = 0,
                generalLose = 0,
                generalMVP = 0,
                generalStone = 0,
                generalKill = 0,
                generalShot = 0,
                generalEndurance = 0,
            },
            rs = new RunnerSkills
            {
                rSpeedLevel = 1,
                rShieldLevel = 1,
                rInvisibilityLevel = 1,
                rAddHealth = 1,
                rTrapLevel = 1,
                rSDTLevel = 1,
                rTopViewLevel = 1,
                rWallLevel = 0,
                rHookLevel = 0,
                rBCLevel = 0
            },
            cs = new CatcherSkills
            {
                cSpeedLevel = 1,
                cInvisibilityLevel = 1,
                cBallLevel = 0,
                cSDTlevel = 1,
                cBCLevel = 0,
                cTopViewLevel = 1,
                cWallLevel = 0,
                cHookLevel = 0,
                cDHLevel = 1
            },
            characters = "11000000000000",
            arenas = "111",
            vfxs = "110000000000000"
        };
        return res;
    }

    public const string profilePicIndex = "ppi";
    public const string characterIndex = "ci";
    public const string vfxIndex = "vfxi";
    public const string mapIndex = "mi";
}
