using UnityEngine;
using System.Collections;
using UnityEditor;

public class S_ForwadBullet : MonoBehaviour
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

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<EnemyManager>())
        {
            // Debug.Log(collision.gameObject.GetComponent<EnemyManager>());
            collision.gameObject.GetComponent<EnemyManager>().GettingHit(f_damage);
            
            Instantiate(ProjectileParticule, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        // Debug.Log(collision);
        // Instantiate(ProjectileParticule, transform.position, transform.rotation);
        // Destroy(gameObject);
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(f_destroyDelay);

        Instantiate(ProjectileParticule, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
