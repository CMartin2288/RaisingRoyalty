using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Martial : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;

    public Martial()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }
    
    public void perform()
    {
        //Result Text
        rImage.sprite = Resources.Load<Sprite>("Martial_Arts");
        rText.text = "Practiced Martial Arts.\n\n"+
            "Strength: " + Manager.strength + " + " + (Constants.statTiny*multiplier) + "\n" +
            "Constitution: " + Manager.constitution + " + " + (Constants.statTiny*multiplier) + "\n" +
            /*"Gold: " + Manager.gold + " - 50\n" +*/
            "Stress: " + Manager.stress + " + " + (Constants.statTiny*multiplier);
                
        //Stat Change
        Manager.strength += Constants.statTiny*multiplier;
        Manager.constitution += Constants.statTiny*multiplier;
        Manager.gold -= 10;
        Manager.stress += Constants.statTiny*multiplier;
    }
}
