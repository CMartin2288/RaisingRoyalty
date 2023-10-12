using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Craft : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;
    
    public Craft()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }

    public int checkSuccess()
    {
        int success = Random.Range(1,101);

        if(success <= Manager.intellect) return 1;
        else return 0;
    }

    public void perform()
    {
        switch(checkSuccess())
        {
            case 0:
                //Result Text
                rText.text = "Couldn't find many buyers...\n\n"+
                    "Creative Talent: " + Manager.creative + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Intellect: " + Manager.intellect + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Gold: " + Manager.gold + " + 4\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statSmall*multiplier);
                
                //Stat Change
                Manager.creative += Constants.statTiny*multiplier*0.5f;
                Manager.intellect += Constants.statTiny*multiplier*0.5f;
                Manager.gold += 4;
                Manager.stress += Constants.statSmall*multiplier;
                break;
            case 1:
                //Result Text
                rText.text = "Sold all of the art.\n\n"+
                    "Creative Talent: " + Manager.creative + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Intellect: " + Manager.intellect + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Gold: " + Manager.gold + " + 8\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statSmall*multiplier);
                
                //Stat Change
                Manager.creative += Constants.statTiny*multiplier;
                Manager.intellect += Constants.statTiny*multiplier;
                Manager.gold += 8;
                Manager.stress += Constants.statSmall*multiplier;
                break;
            default:
                Debug.Log("Activity Success Logic Error");
                break;
        }
    }
}
