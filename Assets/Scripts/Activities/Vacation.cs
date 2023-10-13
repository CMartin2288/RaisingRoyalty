using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Vacation : Activity
{
    public float multiplier = 2;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;

    public Vacation()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }
    
    public void perform()
    {
        rImage.sprite = Resources.Load<Sprite>("Vacation");
        rText.text = "Went out on Vacation.\n\nStress: " + Manager.stress + " - " + (Constants.statMedium*multiplier);
        Manager.stress = Manager.stress - Constants.statMedium*multiplier;
        Manager.gold -= 10;
        
        if(Manager.sick) Manager.trust += Constants.statSmall;
    }
}
