using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rocket;
    public GameObject explosion;

    public AudioSource explosionAudio;
    public LayerMask tankMask;

    public float speed = 3f;
    public float maxLifeTime = 30f;

    public float minDamage = 30f;
    public float maxDamage = 100f;
    public float explosionRadius = 20f;


    private void Awake()
    {
        Destroy(this.gameObject, maxLifeTime);
        Physics.IgnoreLayerCollision(9, 9);
    }

    private void Update()
    {
        rocket.transform.Translate(0, 5 * Time.deltaTime * speed, 0);
        rocket.transform.Rotate(0f, .05f, 0f, Space.Self);
    }

    void OnCollisionEnter(Collision col)
    {
        Explosion();
    }

    private void OnDestroy() {
        Explosion();
    }

    private void Explosion()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach (Collider nearbyObject in colliders)
        {
            TankHealth targetHealth = nearbyObject.GetComponent<TankHealth>();

            if (targetHealth)
            {
                float damage = CalculateDamage(nearbyObject.transform.position);
                targetHealth.TakeDamage(damage);
            }
            print(nearbyObject.name);
        }

        GameObject e = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        ParticleSystem particle = e.GetComponent<ParticleSystem>(); 
        explosionAudio.Play();
        particle.Play();
        e.SetActive(true);
        Destroy(e, 1.5f);
        Destroy(this.gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (explosionRadius - explosionDistance) / explosionRadius;
        float damage = relativeDistance * maxDamage;
        damage = Mathf.Max(0f, damage);
        print(damage);

        return damage;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
