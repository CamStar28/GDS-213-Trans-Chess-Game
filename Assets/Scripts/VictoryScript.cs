using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{

    public float levelTime;
    public Image whiteFade;
    public Slider progressionSlider;

    public GameObject musicManager; 

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LevelEnd());

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        levelTime += Time.deltaTime;
        progressionSlider.value = levelTime;

        if(levelTime >= 60)
        {
            levelTime = 0;
            StartCoroutine(LevelEnd());
            StartCoroutine(musicManager.GetComponent<musicMuteScrpt>().FadeOutMusic());
        }
    }

    public IEnumerator LevelEnd()
    {
        Color c = whiteFade.color;
        for (float alpha = 0; alpha <= 1; alpha += 0.01f)
        {
            c.a = alpha;
            whiteFade.color = c;

            if(Time.timeScale < 1)
            {
                Time.timeScale -= 0.01f;
            }

            yield return new WaitForSecondsRealtime(0.01f);
        }

        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("EndCutscene"); 
    }
}
