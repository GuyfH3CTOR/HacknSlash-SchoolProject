using UnityEngine;
using System.Collections;
using UnityEditor;

public class FireBolt : MonoBehaviour
{
    [Header("#### Spell Settings ####")]
    // public
    public float destroyDelay;
    public float shootForce;
    public float f_damage = 5;
    // private
    private bool isDestroying;
    
    [Header("#### Particules Settings ####")]
    public GameObject ImpactParticule;

    [Header("#### Audio Settings ####")]
    public AudioClip useAudio;
    public AudioClip impactAudio;
    
    [Header("#### References ####")]
    public GameObject spellBody;
    private Rigidbody rb;
    public AudioSource audioSource;
    
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
        //addForce to projectile
        rb.AddForce(transform.forward * shootForce);
        // Play shooting sound
        audioSource.clip = useAudio;
        audioSource.Play(0);
        // Start Destroy Countdown
        StartCoroutine(SpellLifeLength());
    }

    void OnCollisionEnter(Collision _collider)
    {
        if(_collider.gameObject.GetComponentInChildren<Entity_Damagable>() && !isDestroying) // Is Entity Damagable
        {
            // stop a second collider to activate 
            isDestroying = true;
            // Damage Entity
            _collider.gameObject.GetComponentInChildren<Entity_Damagable>().UpdateLife(-f_damage);
            // Create Effect
            Instantiate(ImpactParticule, transform.position, transform.rotation); 
            // play impact sound
            audioSource.clip = impactAudio;
            audioSource.Play(0);

            StopCoroutine(SpellLifeLength());
            StartCoroutine(WaitToDestroy());
        }
        else if(!isDestroying)
        {
            // stop a second collider to activate 
            isDestroying = true;
            // Create Effect
            Instantiate(ImpactParticule, transform.position, transform.rotation);
            // play impact sound
            audioSource.clip = impactAudio;
            audioSource.Play(0);

            StopCoroutine(SpellLifeLength());
            StartCoroutine(WaitToDestroy());
        }
    }

    IEnumerator SpellLifeLength()
    {
        yield return new WaitForSeconds(destroyDelay);
        StartCoroutine(WaitToDestroy());
    }
    
    IEnumerator WaitToDestroy()
    {
        // Hide Body
        spellBody.SetActive(false);
        // stop mouvement
        rb.velocity = Vector3.zero;
        // Get Impact audio Length
        float soundLength = impactAudio.length;
        yield return new WaitForSeconds(soundLength);
        Destroy(gameObject);
    }
}
