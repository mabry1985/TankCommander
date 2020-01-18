using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;          
    public Slider m_Slider;                        
    public Image m_FillImage;                      
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;    
    public GameObject m_ExplosionPrefab;
    

    private AudioSource m_ExplosionAudio;          
    private ParticleSystem m_ExplosionParticles;   
    public float currentHealth;  
    public bool dead;            


    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        currentHealth = m_StartingHealth;
        dead = false;

        SetHealthUI();
    }


    public void TakeDamage(float amount)
    {
      currentHealth -= amount;
      
      SetHealthUI();

      if(currentHealth <= 0f && !dead)
      {
          OnDeath();
      } 
    }


    private void SetHealthUI()
    {
        m_Slider.value = currentHealth / 100;

        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, currentHealth / m_StartingHealth);
    }


    private void OnDeath()
    {
        dead = true;
        
        if(gameObject.name.Contains("Player"))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

        if(!gameObject.name.Contains("Player")) 
        {
            gameObject.GetComponent<TankAI>().StopFiring();
        }

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();

        gameObject.SetActive(false);
    }
}