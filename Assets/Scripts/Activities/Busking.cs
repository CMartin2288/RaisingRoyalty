using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Busking : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;
    
    public Busking()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }

    public int checkSuccess()
    {
        int success = Random.Range(1,101);

        if(success <= Manager.charm) return 1;
        else return 0;
    }

    public void perform()
    {
        switch(checkSuccess())
        {
            case 0:
                //Result Text
                rImage.sprite = Resources.Load<Sprite>("Busking_0");
                rText.text = "Couldn't gather an audience...\n\n"+
                    "Performing Talent: " + Manager.performing + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Fame: " + Manager.fame + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Gold: " + Manager.gold + " + 4\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statSmall*multiplier);
                
                //Stat Change
                Manager.performing += Constants.statTiny*multiplier*0.5f;
                Manager.fame += Constants.statTiny*multiplier*0.5f;
                Manager.gold += 4;
                Manager.stress += Constants.statSmall*multiplier;
                break;
            case 1:
                //Result Text
                rImage.sprite = Resources.Load<Sprite>("Busking_1");
                rText.text = "Received a good amount of tips.\n\n"+
                    "Performing Talent: " + Manager.performing + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Fame: " + Manager.fame + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Gold: " + Manager.gold + " + 8\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statSmall*multiplier);
                
                //Stat Change
                Manager.performing += Constants.statTiny*multiplier;
                Manager.fame += Constants.statTiny*multiplier;
                Manager.gold += 8;
                Manager.stress += Constants.statSmall*multiplier;
                break;
            default:
                Debug.Log("Activity Success Logic Error");
                break;
        }
    }
}
