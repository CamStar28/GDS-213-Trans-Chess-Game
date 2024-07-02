using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBishopScript : MonoBehaviour
{
    public Renderer bishopRenderer;

    public float bishopScrollSpeed;
    public GameObject speedController;

    public Rigidbody bishopBody;

    // Start is called before the first frame update
    void Start()
    {
        bishopScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        bishopBody.velocity = new Vector3(0, 0, bishopScrollSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().bishopPowerUps += 1;
            StartCoroutine(Fade());
            Debug.Log("absolutely bishoped upon");
        }
    }

    IEnumerator Fade()
    {
        Color c = bishopRenderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            bishopRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
