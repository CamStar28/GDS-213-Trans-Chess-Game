using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement; 

public class creditsButtonScript : MonoBehaviour
{

    public Image buttonImage;
    public TextMeshProUGUI buttonText; 
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCredits()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1);
        
        Color c = buttonImage.color;
        Color c2 = buttonText.color;
        for (float alpha = 0; alpha <= 1; alpha += 0.01f)
        {
            c.a = alpha;
            c2.a = alpha;
            buttonImage.color = c;
            buttonText.color = c2;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
