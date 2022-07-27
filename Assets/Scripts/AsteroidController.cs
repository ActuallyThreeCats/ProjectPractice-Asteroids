using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private int score;
    [SerializeField] private float direction;
    private int[] asteroidSize = new int[] {0,1,2};
    [SerializeField] private GameObject smallerAsteroid;
    [SerializeField] private int offset;
    [SerializeField] private bool isSmall;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-direction, direction), Random.Range(-direction, direction));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            DestroyAsteroid(isSmall, score);
            //Debug.Log("OnTriggerEnter");
            
        }
    }

    private void DestroyAsteroid(bool isSmall, int score)
    {
       switch (isSmall)
        {
            case true:
                DestroyAsteroid(score);
                break;
            case false:
                Debug.Log("fucking why");
                Instantiate(smallerAsteroid, gameObject.transform.position + rVec() , Quaternion.identity, gameObject.GetComponentInParent<AsteroidSpawner>().transform);
                Instantiate(smallerAsteroid, gameObject.transform.position + rVec(), Quaternion.identity, gameObject.GetComponentInParent<AsteroidSpawner>().transform);
                DestroyAsteroid(score);
                break;

        }
    }
    public Vector3 rVec()
    {
        return new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f));
    }

    private void DestroyAsteroid(int score)
    {
        Destroy(gameObject);
        AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.asteroid);

        GameManager.Instance.score += score;
    }

}
