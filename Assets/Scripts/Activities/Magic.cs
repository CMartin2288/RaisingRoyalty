using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Magic : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;

    public Magic()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }

    public void perform()
    {
        //Result Text
        rImage.sprite = Resources.Load<Sprite>("Magic");
        rText.text = "Experimented with Magic.\n\n"+
            "Intellect: " + Manager.intellect + " + " + (Constants.statTiny*multiplier) + "\n" +
            "Morals: " + Manager.morals + " - " + (Constants.statTiny*multiplier*0.5f) + "\n" +
            /*"Gold: " + Manager.gold + " - 30\n" +*/
            "Stress: " + Manager.stress + " + " + (Constants.statTiny*multiplier);
                
        //Stat Change
        Manager.intellect += Constants.statTiny*multiplier;
        Manager.morals -= Constants.statTiny*multiplier*0.5f;
        Manager.gold -= 6;
        Manager.stress += Constants.statTiny*multiplier;
    }
}
