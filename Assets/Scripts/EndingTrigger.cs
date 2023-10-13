using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    void Awake(){
        TriggerEndingDialogue();
    }

    public void TriggerEndingDialogue(){
        FindObjectOfType<EndingManager>().EndingDialogue(FindObjectOfType<Manager>(),
                                                          dialogue);
    }
}
