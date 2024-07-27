using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using TMPro; 

public class dialogueManager : MonoBehaviour
{

    public string[] sentences;
    public int currentSentence; 

    public string speakerName;

    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI textBox;
    public GameObject textGroup; 

    public Image bgColour;

    public GameObject ashleyPortrait;
    public GameObject kingPortrait; 

    // Start is called before the first frame update
    void Start()
    {
        currentSentence = 0; 

        if (currentSentence == 0 || currentSentence == 2 || currentSentence == 6 || currentSentence == 9 || currentSentence == 14 || currentSentence == 20 || currentSentence == 14 || currentSentence == 26 || currentSentence == 28 || currentSentence == 32 || currentSentence == 34 || currentSentence == 36 || currentSentence == 38 || currentSentence == 40 || currentSentence == 42)
        {
            speakerName = "Ashley";
            ashleyPortrait.SetActive(true);
            kingPortrait.SetActive(false);
        }

        if (currentSentence == 1 || currentSentence == 4 || currentSentence == 8 || currentSentence == 11 || currentSentence == 15 || currentSentence == 21 || currentSentence == 27 || currentSentence == 29 || currentSentence == 33 || currentSentence == 35 || currentSentence == 37 || currentSentence == 39 || currentSentence == 41 || currentSentence == 43)
        {
            speakerName = "King";
            ashleyPortrait.SetActive(false);
            kingPortrait.SetActive(true);
        }

        UpdateTextBox();

        OpenDialogue();

        Debug.Log(Time.timeScale);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ProgressDialogue();
            //Debug.Log("LINE");
        }
    }

    public void ProgressDialogue()
    {
        currentSentence += 1;

        if (currentSentence == 0 || currentSentence == 2 || currentSentence == 6 || currentSentence == 9 || currentSentence == 14 || currentSentence == 20 || currentSentence == 14 || currentSentence == 26 || currentSentence == 28 || currentSentence == 32 || currentSentence == 34 || currentSentence == 36 || currentSentence == 38 || currentSentence == 40 || currentSentence == 42)
        {
            speakerName = "Ashley";
            ashleyPortrait.SetActive(true);
            kingPortrait.SetActive(false);
        }

        if (currentSentence == 1 || currentSentence == 4 || currentSentence == 8 || currentSentence == 11 || currentSentence == 15 || currentSentence == 21 || currentSentence == 27 || currentSentence == 29 || currentSentence == 33 || currentSentence == 35 || currentSentence == 37 || currentSentence == 39 || currentSentence == 41 || currentSentence == 43)
        {
            speakerName = "King";
            ashleyPortrait.SetActive(false);
            kingPortrait.SetActive(true);
        }

        UpdateTextBox();
    }

    public void UpdateTextBox()
    {

        StopAllCoroutines(); 
        
        if(currentSentence >= sentences.Length)
        {
            EndDialogue();
        }
        else
        {
            nameBox.text = speakerName;
            //textBox.text = sentences[currentSentence];
            StartCoroutine(TypeSentence(sentences[currentSentence]));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        textBox.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSecondsRealtime(0.01f); 
        }
    }

    public void OpenDialogue()
    {
        StartCoroutine(FadeInDialogue()); 
    }

    public void EndDialogue()
    {
        StartCoroutine(FadeOutDialogue());
    }

    IEnumerator FadeInDialogue()
    {
        //Time.timeScale = 0; 
        
        Color c = bgColour.color;
        for (float alpha = 0; alpha <= 0.75; alpha += 0.01f)
        {
            c.a = alpha;
            bgColour.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        textGroup.SetActive(true);
    }

    IEnumerator FadeOutDialogue()
    {
        textGroup.SetActive(false);

        Color c = bgColour.color;
        for (float alpha = 0.75f; alpha >= 0; alpha -= 0.01f)
        {
            c.a = alpha;
            bgColour.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }

        //Time.timeScale = 1;

        SceneManager.LoadScene("LevelScene");
    }

}
