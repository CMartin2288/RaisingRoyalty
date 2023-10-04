using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public TMP_Text dateGold;
    public TMP_Text stats;

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
    public static float performance = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dateGold.text = months[thisMonth] + ", Year " + thisYear.ToString() + "\n" + gold.ToString() + " G";
        
    }

    public void AdvanceTime()
    {
        thisMonth = (thisMonth+1) % 13;
        if(thisMonth == 0)
        {
            thisMonth = 1;
            thisYear = thisYear+1;
        }
    }
}
