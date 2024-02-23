using UnityEngine;
using System.Collections;
using UnityEditor;

public class FireBolt : MonoBehaviour
{
    [SerializeField] float f_destroyDelay;
    [SerializeField] float f_speed;

    [SerializeField] float f_damage = 5;
    
    [SerializeField] GameObject ProjectileParticule;

    public AudioSource as_start;
    public AudioSource as_impact;
    
    void Start()
    {
        as_start.Play(0);
        StartCoroutine(DestroyCoroutine());
    }

    void Update()
    {
        // Debug.Log(Time.deltaTime);
        transform.position = transform.position + (transform.forward * Time.deltaTime * f_speed);
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
        yield return new WaitForSeconds(f_destroyDelay);

        Instantiate(ProjectileParticule, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
