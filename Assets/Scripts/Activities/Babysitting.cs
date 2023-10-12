using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Babysitting : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;
    
    public Babysitting()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }

    public int checkSuccess()
    {
        int success = Random.Range(1,101);

        if(success <= Manager.constitution) return 1;
        else return 0;
    }

    public void perform()
    {
        switch(checkSuccess())
        {
            case 0:
                //Result Text
                rText.text = "Had to deal with babies crying...\n\n"+
                    "Constitution: " + Manager.constitution + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Handiness Talent: " + Manager.handiness + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Charm: " + Manager.charm + " - " + (Constants.statTiny*multiplier) + "\n" +
                    "Gold: " + Manager.gold + " + 3\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statSmall*multiplier);
                
                //Stat Change
                Manager.constitution += Constants.statTiny*multiplier*0.5f;
                Manager.handiness += Constants.statTiny*multiplier*0.5f;
                Manager.charm -= Constants.statTiny*multiplier;
                Manager.gold += 3;
                Manager.stress += Constants.statSmall*multiplier;
                break;
            case 1:
                //Result Text
                rText.text = "Cared for the children.\n\n"+
                    "Constitution: " + Manager.constitution + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Handiness Talent: " + Manager.handiness + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Charm: " + Manager.charm + " - " + (Constants.statTiny*multiplier) + "\n" +
                    "Gold: " + Manager.gold + " + 6\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statSmall*multiplier);
                
                //Stat Change
                Manager.constitution += Constants.statTiny*multiplier;
                Manager.handiness += Constants.statTiny*multiplier;
                Manager.charm -= Constants.statTiny*multiplier;
                Manager.gold += 6;
                Manager.stress += Constants.statSmall*multiplier;
                break;
            default:
                Debug.Log("Activity Success Logic Error");
                break;
        }
    }
}
