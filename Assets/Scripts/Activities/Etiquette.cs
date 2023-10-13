using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Etiquette : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;
    
    public Etiquette()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }
    
    public void perform()
    {
        //Result Text
        rImage.sprite = Resources.Load<Sprite>("Etiquette");
        rText.text = "Learned proper Etiquette.\n\n"+
            "Charm: " + Manager.charm + " + " + (Constants.statTiny*multiplier) + "\n" +
            "Morals: " + Manager.morals + " + " + (Constants.statTiny*multiplier) + "\n" +
            /*"Gold: " + Manager.gold + " - 60\n" +*/
            "Stress: " + Manager.stress + " + " + (Constants.statTiny*multiplier);
                
        //Stat Change
        Manager.charm += Constants.statTiny*multiplier;
        Manager.morals += Constants.statTiny*multiplier;
        Manager.gold -= 12;
        Manager.stress += Constants.statTiny*multiplier;
    }
}
