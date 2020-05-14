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
    public float maxDamage = 50f;
    public float explosionRadius = 5f;

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
        print("I collided");
        ContactPoint contact = col.contacts[0];
        TankHealth targetHealth = col.gameObject.GetComponent<TankHealth>();

        if (targetHealth)
        {
            float damage = Random.Range(minDamage, maxDamage);
            CalculateDamage(col.transform.position);
            targetHealth.TakeDamage(damage);
        }

        Explosion();
    }

    private void OnDestroy() {
        Explosion();
    }

    private void Explosion()
    {
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

        return damage;
    }
}
