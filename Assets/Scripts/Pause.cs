using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseScreen;
    public bool paused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(pauseScreen);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        paused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        paused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
