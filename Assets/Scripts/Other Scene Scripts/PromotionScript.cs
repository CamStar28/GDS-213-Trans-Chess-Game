using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PromotionScript : MonoBehaviour
{

    public Image whiteFade;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().PromoteToQueen();
            StartCoroutine(LevelEnd());
        }
    }

    public IEnumerator LevelEnd()
    {
        Color c = whiteFade.color;
        for (float alpha = 0; alpha <= 1; alpha += 0.01f)
        {
            c.a = alpha;
            whiteFade.color = c;

            if (Time.timeScale < 1)
            {
                Time.timeScale -= 0.01f;
            }

            yield return new WaitForSecondsRealtime(0.01f);
        }

        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("MainMenu");
    }

}
