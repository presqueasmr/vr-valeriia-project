using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;
using UnityEngine.Playables;
// using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    
    public PlayableDirector currentTimeline;
    
    public string levelToLoad;
    private float timer = 2f;
    //private Text timerSeconds;

    private bool changeScene = false;
    

    
    private double timelineTime;

    void Start()
    {
        //timerSeconds = GetComponent<Text>();
        
    }

    void Update()
    {
        
        timelineTime = currentTimeline.time;

        Debug.Log(timelineTime);
        Debug.Log(currentTimeline.duration);
        
        if (timelineTime >= currentTimeline.duration - 0.5f)
        {
            changeScene = true;
            
        }

        if(changeScene == true)
        {
            timer -= Time.deltaTime;
            //timerSeconds.text = timer.ToString("f2");
            Debug.Log(timer);
            if (timer <= fadeScreen.fadeDuration && timer > 0)
            {
                Debug.Log("fadout");
                fadeScreen.FadeOut();
            }
            else if (timer <= 0)
            {
                Debug.Log("transition");
                SceneManager.LoadScene(levelToLoad);
            }
        }

    }
    // public void GoToScene(int sceneIndex)
    // {
    //     StartCoroutine(GoToSceneRoutine(sceneIndex));
    // }

    // IEnumerator GoToSceneRoutine(int sceneIndex)
    // {
    //     fadeScreen.FadeOut();
    //     yield return new WaitForSeconds(fadeScreen.fadeDuration);

    //     //Launch the scene
    //     SceneManager.LoadScene(sceneIndex);
        
    // }
}
