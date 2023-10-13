using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea (3,10)]
    
    //instructions
    public string[] welcome;
    public string[] prompt;
    
    //generic
    public string[] sentences;
    public string[] generic2;
    public string[] generic3;

     //endings
     public string[] destitute;
    public string[] princess;
    public string[] spoiled;
    public string[] helpingHand;
    public string[] warrior;
    public string[] academic;
    public string[] grace;
    public string[] lovedByAll;
    public string[] ordinary;

    //situational
    public string[] poor;
    public string[] sick;
    public string[] constreq;
    
}


