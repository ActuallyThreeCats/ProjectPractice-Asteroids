using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float direction;

    // Start is called before the first frame update
    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-direction, direction), Random.Range(-direction, direction));

        switch (gameObject.tag)
        {

            case "Asteroid_Large":
                direction = direction * 1;
                break;
            case "Asteroid_Medium":
                direction = direction * 2;
                break;
            case "Asteroid_Small":
                direction = direction * 3;
                break;
            default:
                direction = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
