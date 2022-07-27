using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D shipRB;
    [SerializeField] private float thrustAmount;
    [SerializeField] private bool thrusting;
    [SerializeField] private float thrustDirection, rotSpeed;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Vector2 respawnPoint;
    [SerializeField] private SpriteRenderer shipSprite;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private float timeBetweenFlashes;
    [SerializeField] private float moveDelay;
    [Header("Projectile Info")]
    [SerializeField] private bool firing;
    [SerializeField] private float fireRate;
    [SerializeField] private bool allowFire = true;
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform gun;
    private float rot;
    private bool invincibleFrames = false;
    private bool canMove = true;

    public event EventHandler OnShipDestroyed;    

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
        if (canMove)
        {
            shipRB.AddTorque(-rot * rotSpeed, ForceMode2D.Force);

            if (thrusting)
            {
                shipRB.AddForce((gameObject.transform.up * thrustAmount) * thrustDirection, ForceMode2D.Force);
                if (thrustDirection != -1 && !invincibleFrames)
                {
                    particles.gameObject.SetActive(true);

                    if(!audioSource.isPlaying)
                        audioSource.Play();


                }
            }
            else
            {
                shipRB.velocity = new Vector2(shipRB.velocity.x, shipRB.velocity.y);
                particles.gameObject.SetActive(false);
                audioSource.Stop();
            }
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
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.shoot);

            yield return new WaitForSeconds(fireRate);
            allowFire = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Asteroid") && !invincibleFrames)
        {
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.death);

            OnShipDestroyed?.Invoke(this, EventArgs.Empty);
            GameManager.Instance.lives--;
            gameObject.transform.position = respawnPoint;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            StartCoroutine(Flashing());
            StartCoroutine(CanMove());
        }
    }

    public IEnumerator Flashing()
    {
        invincibleFrames = true;
        shipSprite.enabled = false;
        particles.gameObject.SetActive(false);
        yield return new WaitForSeconds(timeBetweenFlashes);
        shipSprite.enabled = true;
        particles.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeBetweenFlashes);
        shipSprite.enabled = false;
        particles.gameObject.SetActive(false);
        yield return new WaitForSeconds(timeBetweenFlashes);
        shipSprite.enabled = true;
        particles.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeBetweenFlashes);
        shipSprite.enabled = false;
        particles.gameObject.SetActive(false);
        yield return new WaitForSeconds(timeBetweenFlashes);
        shipSprite.enabled = true;
        particles.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeBetweenFlashes);
        shipSprite.enabled = false;
        particles.gameObject.SetActive(false);
        yield return new WaitForSeconds(timeBetweenFlashes);
        shipSprite.enabled = true;
        particles.gameObject.SetActive(true);
        invincibleFrames = false;
    }
    IEnumerator CanMove()
    {
        canMove = false;
        yield return new WaitForSeconds(moveDelay);
        canMove = true;
    }

}
