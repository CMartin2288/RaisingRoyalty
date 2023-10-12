using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeVariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Manager.constitution = Random.Range(5,16);
        Manager.strength = Random.Range(5,16);
        Manager.intellect = Random.Range(5,16);
        Manager.grace = Random.Range(5,16);
        Manager.charm = Random.Range(5,16);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
