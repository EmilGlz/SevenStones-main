using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    //public float version;
    public string userId = "";
    public string nickName = "";
    public int level;
    public int xp;
    public int ssCoin;
    public int starCoin;

    public GeneralStats gs = new GeneralStats();

    public RunnerSkills rs = new RunnerSkills();

    public CatcherSkills cs = new CatcherSkills();

    public string characters = "10101020121111";
    public string vfxs = "101010201211110";
    public string arenas = "011";
    //Characters characters = new Characters();
}
