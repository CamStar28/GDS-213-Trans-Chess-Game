using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPawnScript : MonoBehaviour
{

    public Renderer pawnRenderer;

    public float pawnScrollSpeed;
    public GameObject speedController;

    public Rigidbody pawnBody;

    // Start is called before the first frame update
    void Start()
    {
        pawnScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        pawnBody.velocity = new Vector3(0, 0, pawnScrollSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().pawnPowerUps += 1;
            StartCoroutine(Fade());
            Debug.Log("absolutely pawned upon");
        }
    }

    IEnumerator Fade()
    {
        Color c = pawnRenderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            pawnRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
