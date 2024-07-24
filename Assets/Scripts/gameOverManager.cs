using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameOverManager : MonoBehaviour
{

    public Image bgColour;

    public GameObject gameOverGroup;

    public string[] topLineMessages;
    public string[] bottomLineMessages;
    public int currentMessage; 
    public TextMeshProUGUI topTextBox; 
    public TextMeshProUGUI bottomTextBox;
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FadeInGameOver());

        currentMessage = Random.Range(0, topLineMessages.Length);

        topTextBox.text = "";
        bottomTextBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeInGameOver()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        Time.timeScale = 0; 
        
        Color c = bgColour.color;
        for (float alpha = 0; alpha <= 1; alpha += 0.01f)
        {
            c.a = alpha;
            bgColour.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        gameOverGroup.SetActive(true);

        StartCoroutine(TopTypewriter(topLineMessages[currentMessage]));
    }

    IEnumerator TopTypewriter(string encouragement)
    {
        topTextBox.text = "";

        yield return new WaitForSecondsRealtime(1); 

        foreach (char letter in encouragement.ToCharArray())
        {
            topTextBox.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        StartCoroutine(BottomTypewriter(bottomLineMessages[currentMessage]));
    }
    IEnumerator BottomTypewriter(string encouragement)
    {
        bottomTextBox.text = "";

        yield return new WaitForSecondsRealtime(1);

        foreach (char letter in encouragement.ToCharArray())
        {
            bottomTextBox.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    public void ChooseContinue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChooseQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
