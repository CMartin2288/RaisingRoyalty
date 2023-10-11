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
        int success = Random.Range(1,101);

        if(success <= Manager.constitution) return 1;
        else return 0;
    }

    public void perform()
    {
        switch(checkSuccess())
        {
            case 0:
                rText.text = "Did a poor job at the farm...\n\n"+
                    "Constitution: " + Manager.constitution + " + " + (Constants.statSmall*multiplier*0.5f) + "\n" +
                    "Physical Talent: " + Manager.physical + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Gold: " + Manager.gold + " + 5\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statMedium*multiplier*1.5f);
                Manager.gold = Manager.gold + 5;
                Manager.constitution += Constants.statSmall*multiplier*0.5f;
                Manager.physical += Constants.statTiny*multiplier*0.5f;
                Manager.stress = Manager.stress + Constants.statMedium*multiplier*1.5f;
                break;
            case 1:
                rText.text = "Did a good job at the farm.\n\n"+
                    "Constitution: " + Manager.constitution + " + " + (Constants.statSmall*multiplier) + "\n" +
                    "Physical Talent: " + Manager.physical + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Gold: " + Manager.gold + " + 10\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statMedium*multiplier);
                Manager.gold = Manager.gold + 10;
                Manager.constitution += Constants.statSmall*multiplier;
                Manager.physical += Constants.statTiny*multiplier;
                Manager.stress = Manager.stress + Constants.statMedium*multiplier;
                break;
            default:
                Debug.Log("Activity Success Logic Error");
                break;
        }
    }
}
