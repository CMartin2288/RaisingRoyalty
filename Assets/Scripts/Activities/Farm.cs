using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Activity
{
    public float multiplier = 1;

    public void perform()
    {
        Manager.gold = Manager.gold + 50;
        Manager.constitution += Constants.statSmall*multiplier;
        Manager.strength += Constants.statTiny*multiplier;
        Manager.stress = Manager.stress + Constants.statMedium*multiplier;
    }
}
