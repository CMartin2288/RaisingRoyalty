using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDissapear : MonoBehaviour
{
    public Text buttonText;

    public void EraseText()
    {
        buttonText.text = "";
        Debug.Log("Text is now:" + buttonText);
    }
}
