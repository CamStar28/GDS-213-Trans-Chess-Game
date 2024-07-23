using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class dialogueManager : MonoBehaviour
{

    public string[] sentences;
    public int currentSentence; 

    public string speakerName;

    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI textBox; 

    // Start is called before the first frame update
    void Start()
    {
        currentSentence = 0; 

        UpdateTextBox();

        if (currentSentence == 0 || currentSentence == 5)
        {
            speakerName = "Ashley";
        }

        if (currentSentence == 3)
        {
            speakerName = "King";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void ProgressDialogue()
    {
        currentSentence += 1;

        if (currentSentence == 0 || currentSentence == 5)
        {
            speakerName = "Ashley";
        }

        if (currentSentence == 3)
        {
            speakerName = "King";
        }

        UpdateTextBox();
    }

    public void UpdateTextBox()
    {
        nameBox.text = speakerName;
        textBox.text = sentences[currentSentence];
    }

}
