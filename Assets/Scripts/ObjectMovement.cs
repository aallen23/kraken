using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    //movement script tied to ship objects


    public float speed = 3.0f;
    private float xRange = 10;
    private float yRange = 5;

    private int healthHits;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthHits = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            Destroy(gameObject);
            gameManager.UpdateHealth();
        }

        if (transform.position.y < -yRange || transform.position.y > yRange)
        {
            Destroy(gameObject);
            gameManager.UpdateHealth();
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("SquidInk") && healthHits == 0)
        {
            speed -= 5;
            healthHits += 1;
        }

        else if (other.gameObject.CompareTag("SquidInk") && healthHits == 1)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(10);
        }

    }
}
