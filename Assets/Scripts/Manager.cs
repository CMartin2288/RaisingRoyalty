using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    //References to Game Objects
    public TMP_Text dateGold;
    public TMP_Text stats;

    public SceneChanger sceneChanger;

    public static string[] months = {"Error",
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"};
    public static int thisMonth = 1;
    public static int thisYear = 1;
    public static int canLose = 2;

    public static int gold = 500;
    public static float constitution = 0;
    public static float strength = 0;
    public static float intellect = 0;
    public static float grace = 0;
    public static float charm = 0;
    public static float trust = 0;
    public static float morals = 0;
    public static float fame = 0;
    public static float stress = 0;
    public static bool sick = false;
    public static float physical = 0;
    public static float handiness = 0;
    public static float creative = 0;
    public static float performing = 0;

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        dateGold.text = months[thisMonth] + ", Year " + thisYear.ToString() + "\n" + gold.ToString() + " G";
        if(sick)
        {
            dateGold.text += "\nSick!";
        }
        
        stats.text = "<size=+20><b>Personality</b></size>\n"+
            "Constitution\t\t" + constitution + "\n"+
            "Strength\t\t" + strength + "\n"+
            "Intellect\t\t" + intellect + "\n"+
            "Grace \t\t" + grace + "\n"+
            "Charm \t\t" + charm + "\n\n"+
            "<size=+20><b>Relationships</b></size>\n"+
            "Trust\t\t\t" + trust + "\n"+
            "Morals\t\t" + morals + "\n"+
            "Fame \t\t" + fame + "\n\n"+
            "<size=+20><b>Work</b></size>\n"+
            "Stress\t\t" + stress + "\n"+
            "Physical Talent\t" + physical + "\n"+
            "Handiness Talent\t" + handiness + "\n"+
            "Creative Talent\t" + creative + "\n"+
            "Performing Talent\t" + performing;
    }

    public void AdvanceTime()
    {
        thisMonth = (thisMonth+1) % 13;
        if(thisMonth == 0)
        {
            thisMonth = 1;
            thisYear = thisYear+1;
        }

        StartMonth();

        sceneChanger.ChangeScene("Main");
    }

    public void StartMonth()
    {
        //Game Over Check
        if(gold < 0)
        {
            canLose--;
        }
        else canLose = 2;

        //Ending Check
        if(thisYear == Constants.goalYear && thisMonth == Constants.goalMonth)
        {
            Debug.Log("The Game Should End Here");
        }

        //Sick Check
        if(stress >= constitution && Random.Range(1,3) == 1) sick = true;
        else sick = false;
    }

    public void VerifyStats()
    {
        if(constitution < 0) constitution = 0;
        else if(constitution > 100) constitution = 100;
        
        if(strength < 0) strength = 0;
        else if(strength > 100) strength = 100;

        if(intellect < 0) intellect = 0;
        else if(intellect > 100) intellect = 100;

        if(grace < 0) grace = 0;
        else if(grace > 100) grace = 100;

        if(charm < 0) charm = 0;
        else if(charm > 100) charm = 100;

        if(trust < -100) trust = -100;
        else if(trust > 100) trust = 100;

        if(morals < -100) morals = -100;
        else if(morals > 100) morals = 100;

        if(fame < -100) fame = -100;
        else if(fame > 100) fame = 100;

        if(stress < 0) stress = 0;

        if(physical > 100) physical = 100;
        
        if(handiness > 100) handiness = 100;

        if(creative > 100) creative = 100;

        if(performing > 100) performing = 100;
    }
}
