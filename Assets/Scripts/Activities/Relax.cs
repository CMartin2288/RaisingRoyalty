using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relax : MonoBehaviour, Activity
{
    public float multiplier = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void perform()
    {
        Manager.stress = Manager.stress - Constants.statSmall*multiplier;
    }
}
