using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRB;
    [SerializeField] private int speed;
    [SerializeField] private float timeToLive;
    [SerializeField] private int smallScore, medScore, largeScore;
    private void Awake()
    {
        projectileRB = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        projectileRB.AddForce(gameObject.transform.up * speed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if(timeToLive <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Asteroid_Small")
        {
            DestroyAsteroid(other.gameObject, smallScore);
        }
        if (other.tag == "Asteroid_Medium")
        {
            DestroyAsteroid(other.gameObject, medScore);
        }
        if (other.tag == "Asteroid_Large")
        {
            DestroyAsteroid(other.gameObject, largeScore);
        }

    }

    void DestroyAsteroid(GameObject asteroid, int scoreValue)
    {
        Vector2 center = asteroid.transform.position;
        Vector2 offset = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f,0.5f));

        Destroy(asteroid.gameObject);
        if(asteroid.tag == "Asteroid_Large")
        {
            Instantiate(asteroid.GetComponentInParent<AsteroidSpawner>().Asteroid_Medium,
                center - offset, Quaternion.identity, asteroid.GetComponentInParent<AsteroidSpawner>().transform);
            Instantiate(asteroid.GetComponentInParent<AsteroidSpawner>().Asteroid_Medium, 
                center + offset, Quaternion.identity, asteroid.GetComponentInParent<AsteroidSpawner>().transform);
        }
        if(asteroid.tag == "Asteroid_Medium")
        {
            Instantiate(asteroid.GetComponentInParent<AsteroidSpawner>().Asteroid_Small,
                center - offset, Quaternion.identity, asteroid.GetComponentInParent<AsteroidSpawner>().transform);
            Instantiate(asteroid.GetComponentInParent<AsteroidSpawner>().Asteroid_Small,
                center + offset, Quaternion.identity, asteroid.GetComponentInParent<AsteroidSpawner>().transform);
        }
        Destroy(gameObject);
        GameManager.Instance.score += scoreValue;
    }

}
