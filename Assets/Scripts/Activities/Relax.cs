using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relax : Activity
{
    public float multiplier = 1;

    public void perform()
    {
        Manager.stress = Manager.stress - Constants.statSmall*multiplier;
    }
}
