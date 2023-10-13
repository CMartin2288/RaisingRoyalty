using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Relax : Activity
{
    public float multiplier = 1;
    public ScheduleManager sMan;
    public Image rImage;
    public TMP_Text rText;

    public Relax()
    {
        sMan = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = sMan.getRImage();
        rText = sMan.getRText();
    }
    
    public void perform()
    {
        rImage.sprite = Resources.Load<Sprite>("Rest");
        rText.text = "Stayed at home to rest.\n\nStress: " + Manager.stress + " - " + (Constants.statMedium*multiplier);
        Manager.stress = Manager.stress - Constants.statMedium*multiplier;
        
        if(Manager.sick) Manager.trust += Constants.statSmall;
    }
}
