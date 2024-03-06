using UnityEngine;
using System.Collections;
using UnityEditor;

public class FireBolt : MonoBehaviour
{
    [Header("========== Spell ==========")]
    [Header("#### Settings ####")]
    public float destroyDelay;
    public float shootForce;
    public float f_damage = 5;
    
    public GameObject ProjectileParticule;

    public AudioSource as_start;
    public AudioSource as_impact;
    
    [Header("#### References ####")]
    private Rigidbody rb;
    public AudioSource audioSource;
    
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
        //addForce to projectile
        rb.AddForce(transform.forward * shootForce);
        // Play shooting sound
        as_start.Play(0);
        // Start Destroy Countdown
        StartCoroutine(DestroyCoroutine());
    }

    void OnCollisionEnter(Collision _collider)
    {
        if(_collider.gameObject.GetComponentInChildren<Entity_Damagable>()) // Is Entity Damagable
        {
            _collider.gameObject.GetComponentInChildren<Entity_Damagable>().UpdateLife(-f_damage); // Damage Entity
            Instantiate(ProjectileParticule, transform.position, transform.rotation); // Create Effect
            Destroy(gameObject);
        }
        else
        {
            Instantiate(ProjectileParticule, transform.position, transform.rotation); // Create Effect
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(destroyDelay);

        Instantiate(ProjectileParticule, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
