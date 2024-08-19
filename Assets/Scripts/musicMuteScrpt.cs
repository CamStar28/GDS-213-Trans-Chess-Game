using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicMuteScrpt : MonoBehaviour
{

    public AudioSource musicSource; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeOutMusic()
    {
        for (float volume = musicSource.volume; volume >= 0; volume -= (musicSource.volume/25))
        {
            musicSource.volume = volume;
            yield return new WaitForSeconds(0.005f);
        }

        MuteMusic();
        yield return null;
    }

    public void MuteMusic()
    {
        musicSource.volume = 0; 
        Debug.Log(musicSource.volume);
    }
}
