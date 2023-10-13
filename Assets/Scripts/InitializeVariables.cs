using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeVariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Manager.thisYear = 1;
        Manager.thisMonth = 1;

        Manager.canLose = false;

        Manager.gold = 500;

        Manager.constitution = Random.Range(5,16);
        Manager.strength = Random.Range(5,16);
        Manager.intellect = Random.Range(5,16);
        Manager.grace = Random.Range(5,16);
        Manager.charm = Random.Range(5,16);

        Manager.trust = 0;
        Manager.morals = 0;
        Manager.fame = 0;

        Manager.stress = 0;
        Manager.sick = false;
        Manager.physical = 0;
        Manager.handiness = 0;
        Manager.creative = 0;
        Manager.performing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
