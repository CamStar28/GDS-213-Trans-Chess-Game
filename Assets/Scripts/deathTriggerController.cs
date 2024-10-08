using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTriggerController : MonoBehaviour
{

    public GameObject gameOverManager; 
    public GameObject musicManager;
    
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
            other.gameObject.GetComponent<playerController>().isStunned = true;
            
            gameOverManager.SetActive(true);

            StartCoroutine(musicManager.GetComponent<musicMuteScrpt>().FadeOutMusic());

            StartCoroutine(gameOverManager.GetComponent<gameOverManager>().FadeInGameOver());
        } 
    }
}
