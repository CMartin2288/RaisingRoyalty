using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dance : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;

    public Dance()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }
    
    public void perform()
    {
        //Result Text
        rText.text = "Studied Dance.\n\n"+
            "Grace: " + Manager.grace + " + " + (Constants.statTiny*multiplier) + "\n" +
            "Intellect: " + Manager.intellect + " - " + (Constants.statTiny*multiplier) + "\n" +
            "Gold: " + Manager.gold + " - 40\n" +
            "Stress: " + Manager.stress + " + " + (Constants.statTiny*multiplier);
                
        //Stat Change
        Manager.grace += Constants.statTiny*multiplier;
        Manager.intellect -= Constants.statTiny*multiplier;
        Manager.gold -= 40;
        Manager.stress += Constants.statTiny*multiplier;
    }
}
