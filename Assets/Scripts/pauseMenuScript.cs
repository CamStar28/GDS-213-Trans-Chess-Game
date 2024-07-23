using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class pauseMenuScript : MonoBehaviour
{

    public Image menuColour;
    public GameObject buttonGroup;

    public GameObject playerController; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator OpenPauseMenu()
    {
        Color c = menuColour.color;
        for (float alpha = 0; alpha <= 0.5; alpha += 0.01f)
        {
            c.a = alpha;
            menuColour.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        buttonGroup.SetActive(true);
    }

    public IEnumerator ClosePauseMenu()
    {
        buttonGroup.SetActive(false);

        Color c = menuColour.color;
        for (float alpha = 0.5f; alpha >= 0; alpha -= 0.01f)
        {
            c.a = alpha;
            menuColour.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        Time.timeScale = 1;
        playerController.GetComponent<playerController>().gameIsPaused = false;
    }

    public void ResumeButton()
    {
        StartCoroutine(ClosePauseMenu());
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
