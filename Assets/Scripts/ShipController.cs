using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D shipRB;
    [SerializeField] private float thrustAmount;
    [SerializeField] private bool thrusting;

    [SerializeField] private float thrustDirection, rotSpeed;

    [SerializeField] private ParticleSystem particles;

    [Space]
    [Header("Projectile Info")]
    [Space]

    [Tooltip("Is currently firing")]
    [SerializeField] private bool firing;
    [SerializeField] private float fireRate;
    [SerializeField] private bool allowFire = true;


    [SerializeField] private Projectile projectile;

    [SerializeField] private Transform gun;
    private float rot;
    

    public void Thrust(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            thrusting = true;
        }
        if (context.canceled)
        {
            thrusting = false;
        }
    }

    public void MoveShip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            thrustDirection = context.ReadValue<Vector2>().y;
            Debug.Log(thrustDirection);
            thrusting = true;
        }
        if (context.canceled)
        {
            thrustDirection = 0;
            thrusting = false;

        }
    }


    public void RotateShip(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rot = context.ReadValue<Vector2>().x;
        }
        if (context.canceled)
        {
            rot = 0;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            firing = true;
        }
        if (context.canceled)
        {
            firing = false;
        }

    }

    public void Update()
    {

        ShootGun();
        
    }
    public void FixedUpdate()
    {

        shipRB.AddTorque(-rot * rotSpeed,ForceMode2D.Force);

        if (thrusting)
        {
            shipRB.AddForce((gameObject.transform.up * thrustAmount)* thrustDirection, ForceMode2D.Force);
            if (thrustDirection != -1)
            {
                particles.gameObject.SetActive(true);

            }
        }
        else
        {
            shipRB.velocity = new Vector2(shipRB.velocity.x, shipRB.velocity.y);
            particles.gameObject.SetActive(false);
        }
    }

    public void ShootGun()
    {
        if(allowFire && firing)
        {
            StartCoroutine(FireRate());
        }

        IEnumerator FireRate()
        {
            allowFire = false;
            
            Instantiate(projectile, gun.transform.position, gun.transform.rotation);
            yield return new WaitForSeconds(fireRate);
            allowFire = true;
        }
    }
}
