using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScheduleManager : MonoBehaviour
{
    //Scene Object References
    public Image week1;
    public Image week2;
    public Image week3;
    public Image week4;
    public GameObject resultPanel;
    public GameObject goButton;
    public Image rImage;
    public TMP_Text rText;
    public Manager genManager;
    
    public Activity[] schedule;
    public int numScheduled;
    public string queuedType;
    public Sprite queuedImage;
    public Sprite scheduleDefault;
    
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

    public Image getRImage()
    {
        return rImage;
    }

    public TMP_Text getRText()
    {
        return rText;
    }

    //Method to set the new image from a button
    public void setQueuedImage(Sprite sprite)
    {
        queuedImage = sprite;
    }

    //Method to set the activity type from a button
    public void setQueuedType(string type)
    {
        queuedType = type;
    }

    //Add a task to the schedule
    public void add()
    {
        Activity newActivity;

        //The queuedActivity should be set by the buttons under the _Opt panels in the scene
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

        //If the schedule is full
        if(numScheduled == 4)
        {
            //Replace the last activity with the new one
            schedule[3] = newActivity;
            //Set the week's sprite accordingly
            week4.sprite = queuedImage;
            return;
        }

        //Add the activity
        schedule[numScheduled] = newActivity;
        //Track the number
        numScheduled++;
        //Put the image in the right place
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
                goButton.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void remove()
    {
        if(numScheduled == 0)
        {
            SceneChanger sc = GetComponent<SceneChanger>();
            sc.ChangeScene("Main");
            return;
        }
        
        goButton.SetActive(false);
        //Track the number
        numScheduled--;
        schedule[numScheduled] = null;
        //Put the image in the right place
        switch(numScheduled)
        {
            case 0:
                week1.sprite = scheduleDefault;
                break;
            case 1:
                week2.sprite = scheduleDefault;
                break;
            case 2:
                week3.sprite = scheduleDefault;
                break;
            case 3:
                week4.sprite = scheduleDefault;
                break;
            default:
                break;
        }
    }

    //The public method of execute, made this way so it can be called from a UI button
    public void execute()
    {
        StartCoroutine(CoExecute());
    }

    //IEnumerator method of execute
    public IEnumerator CoExecute()
    {
        //Show the results
        resultPanel.SetActive(true);
        //For each activity in the schedule
        for(int i=0; i<4; i++)
        {
            //Do that activity 5 times (Mon-Fri)
            for(int j=0; j<5; j++)
            {
                schedule[i].perform();
                
                //Sickness penalty
                if(Manager.sick)
                {
                    rText.text += "\n\n<color=red>Sick:\n";
                    switch(Random.Range(1,6))
                    {
                        case 2:
                            rText.text += "Strength -1</color>";
                            Manager.strength -= Constants.statTiny;
                            break;
                        case 3:
                            rText.text += "Intellect -1</color>";
                            Manager.intellect -= Constants.statTiny;
                            break;
                        case 4:
                            rText.text += "Grace -1</color>";
                            Manager.grace -= Constants.statTiny;
                            break;
                        case 5:
                            rText.text += "Charm -1</color>";
                            Manager.charm -= Constants.statTiny;
                            break;
                        default:
                            rText.text += "Constitution -1</color>";
                            Manager.constitution -= Constants.statTiny;
                            break;
                    }
                }

                //Pause to show the player the results
                yield return new WaitForSeconds(1);
            }
        }

        genManager.AdvanceTime();
    }
}
