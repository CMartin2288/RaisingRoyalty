using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class EndingManager : MonoBehaviour{
    private Queue<string> sentences = new Queue<string>();
    public Text dialogueText;
    public void EndingDialogue(Manager mgr, Dialogue dialogue){
        Debug.Log("Beginning an Ending Seqeunce");

        //hides ending
        GameObject princess = GameObject.FindWithTag("princess");
        princess.SetActive(false);

        GameObject spoiled = GameObject.FindWithTag("spoiled");
        spoiled.SetActive(false);

        GameObject helping = GameObject.FindWithTag("helping");
        helping.SetActive(false);

        GameObject warrior = GameObject.FindWithTag("warrior");
        warrior.SetActive(false);

        GameObject academic = GameObject.FindWithTag("academic");
        academic.SetActive(false);

        GameObject grace = GameObject.FindWithTag("grace");
        grace.SetActive(false);

        GameObject lovedbyall = GameObject.FindWithTag("lovedbyall");
        lovedbyall.SetActive(false);

        GameObject ordinary = GameObject.FindWithTag("ordinary");
        ordinary.SetActive(false);

        GameObject destitute = GameObject.FindWithTag("destitute");
        destitute.SetActive(false);
        // DONE HIDING
        

        
        //ENDINGS
        //Destitute
        if (Manager.canLose == 0) {
            destitute.SetActive(true);
            foreach (string sentence in dialogue.destitute){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }

        //Princess
        else if (Manager.grace > 75 && Manager.charm > 75 && Manager.morals > 75) {
            princess.SetActive(true);
            foreach (string sentence in dialogue.princess){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }

        //Spoiled
        else if (Manager.grace > 75 && Manager.charm > 75 && Manager.morals <= 75) {
            spoiled.SetActive(true);
            foreach (string sentence in dialogue.spoiled){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }


        //Warrior
        else if (Manager.strength > 75) {
            warrior.SetActive(true);
            foreach (string sentence in dialogue.warrior){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }
        
        //Helping Hand
        else if (Manager.constitution > 75) {
            helping.SetActive(true);
            foreach (string sentence in dialogue.helpingHand){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }       

        //Academic
        else if (Manager.intellect > 75) {
            academic.SetActive(true);
            foreach (string sentence in dialogue.academic){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }

        //Grace
        else if (Manager.grace > 75) {
            grace.SetActive(true);
            foreach (string sentence in dialogue.grace) {
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }

        //Loved By All
        else if (Manager.charm > 75) {
            lovedbyall.SetActive(true);
            foreach (string sentence in dialogue.lovedByAll){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }

        //Ordinary
        else {
            ordinary.SetActive(true);
            foreach (string sentence in dialogue.ordinary){
                sentences.Enqueue(sentence);
            }
            this.DisplayNextSentence();
        }      
    }
    //END OF ENDINGS

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
