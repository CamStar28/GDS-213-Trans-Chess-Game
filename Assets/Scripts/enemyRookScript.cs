using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRookScript : MonoBehaviour
{
    public Renderer rookRenderer;

    public float rookScrollSpeed;
    public GameObject speedController;

    public Rigidbody rookBody;

    // Start is called before the first frame update
    void Start()
    {
        rookScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rookBody.velocity = new Vector3(0, 0, rookScrollSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().rookPowerUps += 1;
            StartCoroutine(Fade());
            Debug.Log("absolutely rooked upon");
        }
    }

    IEnumerator Fade()
    {
        Color c = rookRenderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            rookRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
