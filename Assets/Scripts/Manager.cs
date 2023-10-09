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

    public static int gold = 500;
    public static float constitution = 50;
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
        
        stats.text = "<size=+20><b>Personality</b></size>\n";
        stats.text += "Constitution\t\t" + constitution + "\n";
        stats.text += "Strength\t\t" + strength + "\n";
        stats.text += "Intellect\t\t" + intellect + "\n";
        stats.text += "Grace \t\t" + grace + "\n";
        stats.text += "Charm \t\t" + charm + "\n\n";
        stats.text += "<size=+20><b>Relationships</b></size>\n";
        stats.text += "Trust\t\t\t" + trust + "\n";
        stats.text += "Morals\t\t" + morals + "\n";
        stats.text += "Fame \t\t" + fame + "\n\n";
        stats.text += "<size=+20><b>Work</b></size>\n";
        stats.text += "Stress\t\t" + stress + "\n";
        stats.text += "Physical Talent\t" + physical + "\n";
        stats.text += "Handiness Talent\t" + handiness + "\n";
        stats.text += "Creative Talent\t" + creative + "\n";
        stats.text += "Performing Talent\t" + performing;
    }

    public void AdvanceTime()
    {
        thisMonth = (thisMonth+1) % 13;
        if(thisMonth == 0)
        {
            thisMonth = 1;
            thisYear = thisYear+1;
        }

        sceneChanger.ChangeScene("Main");
    }
}
