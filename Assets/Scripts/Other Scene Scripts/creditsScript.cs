using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class creditsScript : MonoBehaviour
{

    public TextMeshProUGUI creditsText;
    public RectTransform textTransform;

    float amountMoved; 
    
    // Start is called before the first frame update
    void Start()
    {
        textTransform.transform.localPosition -= new Vector3 (0, 50, 0);
        amountMoved = 0;

        StartCoroutine(FadeIn()); 
    }

    // Update is called once per frame
    void Update()
    {
        if(amountMoved < 50)
        {
            textTransform.transform.localPosition += new Vector3 (0, 0.15f, 0);
            amountMoved += 0.15f;
        }
    }

    IEnumerator FadeIn()
    {
        Color c = creditsText.color;
        for (float alpha = 0; alpha <= 1; alpha += 0.01f)
        {
            c.a = alpha;
            creditsText.color = c;
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

}
