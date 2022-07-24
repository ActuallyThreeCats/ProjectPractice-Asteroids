using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRB;
    [SerializeField] private int speed;
    [SerializeField] private float timeToLive;
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
}
