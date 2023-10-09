using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Relax : Activity
{
    public float multiplier = 1;
    public ScheduleManager manager;
    public Image rImage;
    public TMP_Text rText;

    public Relax()
    {
        manager = GameObject.Find("ScheduleButton").GetComponent<ScheduleManager>();
        rImage = manager.getRImage();
        rText = manager.getRText();
    }
    
    public void perform()
    {
        rText.text = "Stayed at home to rest.\n\nStress: " + Manager.stress + " -> " + (Manager.stress - Constants.statSmall*multiplier);
        Manager.stress = Manager.stress - Constants.statSmall*multiplier;
    }
}
