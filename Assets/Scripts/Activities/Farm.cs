using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Farm : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;

    public Farm()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }

    public int checkSuccess()
    {
        int success = Random.Range(1,100);

        

        return 1;
    }

    public void perform()
    {
        rText.text = "Did a good job at the farm.\n\n"+
            "Constitution: " + Manager.constitution + " + " + (Constants.statSmall*multiplier) + "\n" +
            "Physical Talent: " + Manager.physical + " + " + (Constants.statTiny*multiplier) + "\n" +
            "Gold: " + Manager.gold + " + 10\n" +
            "Stress: " + Manager.stress + " + " + (Constants.statMedium*multiplier);
        Manager.gold = Manager.gold + 10;
        Manager.constitution += Constants.statSmall*multiplier;
        Manager.physical += Constants.statTiny*multiplier;
        Manager.stress = Manager.stress + Constants.statMedium*multiplier;
    }
}
