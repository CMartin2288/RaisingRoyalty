using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Church : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;
    
    public Church()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }

    public int checkSuccess()
    {
        int success = Random.Range(1,101);

        if(success <= Manager.grace) return 1;
        else return 0;
    }

    public void perform()
    {
        switch(checkSuccess())
        {
            case 0:
                //Result Text
                rImage.sprite = Resources.Load<Sprite>("Church_0");
                rText.text = "Kicked up dust at church...\n\n"+
                    "Morals: " + Manager.morals + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Charm: " + Manager.charm + " + " + (Constants.statTiny*multiplier*0.5f) + "\n" +
                    "Gold: " + Manager.gold + " + 3\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statTiny*multiplier);
                
                //Stat Change
                Manager.morals += Constants.statTiny*multiplier*0.5f;
                Manager.charm += Constants.statTiny*multiplier*0.5f;
                Manager.gold += 3;
                Manager.stress += Constants.statTiny*multiplier;
                break;
            case 1:
                //Result Text
                rImage.sprite = Resources.Load<Sprite>("Church_1");
                rText.text = "Tidied up around the church.\n\n"+
                    "Morals: " + Manager.morals + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Charm: " + Manager.charm + " + " + (Constants.statTiny*multiplier) + "\n" +
                    "Gold: " + Manager.gold + " + 6\n" +
                    "Stress: " + Manager.stress + " + " + (Constants.statTiny*multiplier);
                
                //Stat Change
                Manager.morals += Constants.statTiny*multiplier;
                Manager.charm += Constants.statTiny*multiplier;
                Manager.gold += 6;
                Manager.stress += Constants.statTiny*multiplier;
                break;
            default:
                Debug.Log("Activity Success Logic Error");
                break;
        }
    }
}
