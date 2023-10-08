using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleManager : MonoBehaviour
{
    public Image week1;
    public Image week2;
    public Image week3;
    public Image week4;
    
    public Activity[] schedule;
    public int numScheduled;
    public string queuedType;
    public Sprite queuedImage;
    
    // Start is called before the first frame update
    void Start()
    {
        schedule = new Activity[4];
        numScheduled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void setQueuedImage(Sprite sprite)
    {
        queuedImage = sprite;
    }

    public void setQueuedType(string type)
    {
        queuedType = type;
    }

    public void add()
    {
        Activity newActivity;

        switch(queuedType)
        {
            case "Farm":
                newActivity = new Farm();
                break;
            case "Relax":
                newActivity = new Relax();
                break;
            default:
                return;
        }

        if(numScheduled == 4)
        {
            schedule[3] = newActivity;
            week4.sprite = queuedImage;
            return;
        }

        schedule[numScheduled] = newActivity;
        numScheduled++;
        switch(numScheduled)
        {
            case 1:
                week1.sprite = queuedImage;
                break;
            case 2:
                week2.sprite = queuedImage;
                break;
            case 3:
                week3.sprite = queuedImage;
                break;
            case 4:
                week4.sprite = queuedImage;
                break;
            default:
                break;
        }
    }

    public void execute()
    {
        
    }
}
