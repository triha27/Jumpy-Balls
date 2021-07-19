using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private int randomLoc = 4;
    private int randomTor = 10;
    private int maxSpeed = 18;
    private int minSpeed = 14;
    private int yPos = -2;
    public int pointValue;
    private GameManager gameManager;
    public ParticleSystem particleEffect;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(particleEffect, transform.position, transform.rotation);
            gameManager.ScoreUpdate(pointValue);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad"))
        {
            gameManager.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 RandomForce()
    {
        return Vector3.up * (Random.Range(minSpeed, maxSpeed));
    }
    float RandomTorque()
    {
        return Random.Range(-randomTor, randomTor);
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-randomLoc, randomLoc), yPos);
    }
}
