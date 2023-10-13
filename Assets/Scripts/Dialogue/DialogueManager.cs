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
        
        // MAIN SCENE
        if (currScene=="Main") {
            if (Manager.thisMonth == 1 && Manager.thisYear == 1) { 
                foreach (string sentence in dialogue.welcome){
                    sentences.Enqueue(sentence);
                }
                this.DisplayNextSentence();          
            }

            // //ENDING DETECTION
            // else if (Manager.thisYear > 1) {

            //     // Debug.Log("Beginning an Ending Seqeunce");
            
            //     //endings

            //     // List<string> endingList = List<string>();
            //     // endingList.Insert(0,"Princess");
            //     // endingList.Insert(1,"Spoiled");
            //     // endingList.Insert(2,"Helping Hand");
            //     // endingList.Insert(3,"Warrior");
            //     // endingList.Insert(4,"Academic");
            //     // endingList.Insert(5,"Grace");
            //     // endingList.Insert(6,"LovedByAll");
            //     // endingList.Insert(6,"Ordinary");
                
            //     // //Debugging
            //     // Debug.Log ("Princess, Spoiled, Helping Hand, Warrior, Academic, Grace, LovedByAll, Ordinary,");
            //     // endingList.Shuffle();
            //     // string ShuffledList = "";
            //     // foreach (string type in endingList) {
            //     //     ShuffledList += type + ",";
            //     // }
            //     // Debug.Log(ShuffledList);

            //     //Destitute
            //     if (Manager.canLose) {
            //         foreach (string sentence in dialogue.destitute){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }

            //     //Princess
            //     else if (Manager.grace > 80 && Manager.charm > 80 && Manager.morals > 80) {
            //         foreach (string sentence in dialogue.princess){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }

            //     //Spoiled
            //     else if (Manager.grace > 80 && Manager.charm > 80 && Manager.morals <= 80) {
            //         foreach (string sentence in dialogue.spoiled){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }


            //     //Helping Hand
            //     else if (Manager.constitution > 80) {
            //         foreach (string sentence in dialogue.helpingHand){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }       

            //     //Warrior
            //     else if (Manager.strength > 80 && Manager.morals > 80) {
            //         foreach (string sentence in dialogue.warrior){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }

            //     //Academic
            //     else if (Manager.intellect > 80) {
            //         foreach (string sentence in dialogue.academic){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }

            //     //Grace
            //     else if (Manager.grace > 80 && Manager.charm > 80 && Manager.morals > 80) {
            //         foreach (string sentence in dialogue.grace) {
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }

            //     //Loved By All
            //     else if (Manager.charm > 80) {
            //         foreach (string sentence in dialogue.lovedByAll){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }

            //     //Ordinary
            //     else {
            //         foreach (string sentence in dialogue.ordinary){
            //             sentences.Enqueue(sentence);
            //         }
            //         this.DisplayNextSentence();
            //     }            

            // }
            // //END OF ENDINGS

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
        else if (currScene == "Scheduling") {
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
        
        // //TALK SCENE -- player hints and other events with requirements
        // else if (currScene == "Talk") {
        //     if (Manager.thisMonth == 1 && Manager.thisYear == 1) {
        //         foreach (string sentence in dialogue.welcome){
        //             sentences.Enqueue(sentence);
        //         }
        //         this.DisplayNextSentence();     
        //     }
        //     // sick
        //     else if (Manager.sick) {
        //         foreach (string sentence in dialogue.sick) {
        //             sentences.Enqueue(sentence);
        //         }
        //         this.DisplayNextSentence();
        //     }
        //     //  poor
        //     else if (Manager.gold < 30) {
        //         foreach (string sentence in dialogue.poor){
        //             sentences.Enqueue(sentence);
        //         }
        //         this.DisplayNextSentence();
        //     }
            
        //     // constitution req
        //     else if (Manager.constitution > 80) {
        //         foreach (string sentence in dialogue.constreq) {
        //             sentences.Enqueue(sentence);
        //         }
        //         this.DisplayNextSentence();
        //     }
        //     }
        //     // executes generic dialogues
        //     else {
        //         randomGenericDialogue(dialogue);
        //     }
        //}
        // //TALK SCENE
    }

    public void DisplayNextSentence(){
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


    // //Taken from https://stackoverflow.com/questions/49570175/simple-way-to-randomly-shuffle-list
    // public static void Shuffle<string>(this List<string> list)  
    // {  
    //     Random random = new Random();  
    //     int n = list.Count;  

    //     for(int i= list.Count - 1; i > 1; i--)
    //     {
    //         int rnd = random.Next(i + 1);  

    //         T value = list[rnd];  
    //         list[rnd] = list[i];  
    //         list[i] = value;
    //     }
    // }
}
