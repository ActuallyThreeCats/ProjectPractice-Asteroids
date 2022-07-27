using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedClamp : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }
}
