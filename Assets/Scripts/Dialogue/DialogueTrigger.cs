using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public Dialogue dialogue;
    void Awake(){
        // TriggerNormalDialogue();
        TriggerEventDialogue();
    }

    public void TriggerNormalDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    public void TriggerEventDialogue(){
        FindObjectOfType<DialogueManager>().EventDialogue(FindObjectOfType<Manager>(),
                                                          dialogue);
    }

}
