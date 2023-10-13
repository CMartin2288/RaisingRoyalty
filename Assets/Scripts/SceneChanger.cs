using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DelayedStart(float wait)
    {
        StartCoroutine(CoDelayedStart(wait));
    }

    public IEnumerator CoDelayedStart(float wait)
    {
        MusicManager.Instance.TitleStart();
        yield return new WaitForSeconds(wait);
        SceneManager.LoadSceneAsync("Main");
    }
}
