using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKnightScript : MonoBehaviour
{
    public Renderer knightRenderer;

    public float knightScrollSpeed;
    public GameObject speedController;

    public Rigidbody knightBody;

    // Start is called before the first frame update
    void Start()
    {
        knightScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        knightBody.velocity = new Vector3(0, 0, knightScrollSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().knightPowerUps += 1;
            StartCoroutine(Fade());
            Debug.Log("absolutely knighted upon");
        }
    }

    IEnumerator Fade()
    {
        Color c = knightRenderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            knightRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
