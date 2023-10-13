using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class DialogueManager : MonoBehaviour{
    private Queue<string> sentences = new Queue<string>();
    public Text dialogueText;

    public void StartDialogue(Dialogue dialogue){   
        Debug.Log("The following dialogue is titled: " + dialogue.name);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        this.DisplayNextSentence();
    }

    public void randomGenericDialogue(Dialogue dialogue){   
        Debug.Log("The following dialogue is titled: " + dialogue.name);
        sentences.Clear();

        //// Generates a number between 1 to 3
        Random rnd = new Random();
        int random_number  = rnd.Next(1, 10); 

        //generic 1
        if (random_number == 1) {
            StartDialogue(dialogue);      
        }
        //generic 2
        else if (random_number == 2) {
            Debug.Log("The following dialogue is titled: " + dialogue.name);
            sentences.Clear();
            
            foreach (string sentence in dialogue.generic2){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();             
        }
        //generic 3
        else {
            Debug.Log("The following dialogue is titled: " + dialogue.name);
            sentences.Clear();
            
            foreach (string sentence in dialogue.generic3){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();             
        }
    }

    public void EventDialogue(Manager mgr, Dialogue dialogue){
        Scene scene = SceneManager.GetActiveScene();
        string currScene = scene.name;
        Debug.Log("Inside Event dialogue");
        // MAIN SCENE
        if (currScene=="Main") {
            GameObject End = GameObject.FindWithTag("EndTrigger");
            End.SetActive(false);
            if (Manager.thisMonth == 1 && Manager.thisYear == 1) { 
                foreach (string sentence in dialogue.welcome){
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();          
            }

            //ENDING DETECTION
            else if (Manager.thisYear> 1 || Manager.canLose) {
                // GameObject End = GameObject.FindWithTag("EndTrigger");
                End.SetActive(true);
            }

            //PROMPT
            else{
                GameObject ClickTo = GameObject.FindWithTag("ClickTo");
                ClickTo.SetActive(false);
                foreach (string sentence in dialogue.prompt){
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();                
            }
        }
        //END OF MAIN SCENE
        
        //SCHEDULING SCENE
        else if (currScene == "Schedule") {
            Debug.Log("Inside scheduling");
            if (Manager.thisMonth == 1 && Manager.thisYear == 1 ) {
                foreach (string sentence in dialogue.welcome){
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();   
            }
            else {
                foreach (string sentence in dialogue.prompt){
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence(); 
            }
        }
        //END OF SCHEDULING
        
        //TALK SCENE -- player hints and other events with requirements
        else if (currScene == "Talk") {
            if (Manager.thisMonth == 1 && Manager.thisYear == 1) {
                foreach (string sentence in dialogue.welcome){
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();     
            }

            //  poor
            else if (Manager.gold < 30) {
                foreach (string sentence in dialogue.poor){
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();
            }
            // sick
            else if (Manager.sick) {
                foreach (string sentence in dialogue.sick) {
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();
            }
            // constitution req
            else if (Manager.constitution > 80) {
                foreach (string sentence in dialogue.constreq) {
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();
            }

            // executes generic dialogues
            else {
                randomGenericDialogue(dialogue);
            }
        }
        //END TALK SCENE
    }

    public void DisplayNextSentence(){
        Debug.Log("DisplayNextSentence");
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        Debug.Log("End of Conversation");
    }
}
