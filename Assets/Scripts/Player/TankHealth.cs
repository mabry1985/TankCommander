using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 100f;
    public float m_StartingArmor = 100f;
    public Slider m_HealthSlider;
    public Slider m_ArmorSlider;
    public Image m_HealthFillImage;
    public Image m_ArmorFillImage;
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;
    public Color m_FullArmorColor = Color.blue;
    public Color m_ZeroArmorColor = Color.white;
    public GameObject m_ExplosionPrefab;
    public GameObject coinPrefab;
    

    private AudioSource m_ExplosionAudio;          
    private ParticleSystem m_ExplosionParticles;   

    [SerializeField]
    public float currentHealth;
    [SerializeField]
    private float _playerArmor = 100f;

    [SerializeField]
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
        _playerArmor = m_StartingArmor;
        dead = false;

        SetHealthUI();
        SetArmorUI();
    }


    public void TakeDamage(float amount)
    {

        if (_playerArmor <= 0f && !dead)
        {
            currentHealth -= amount;
        }
        else
        {
            _playerArmor -= amount;
            
        }

        SetArmorUI();
        SetHealthUI();

      if(currentHealth <= 0f && !dead)
      {
          OnDeath();
      } 
    }


    private void SetHealthUI()
    {
        
        if (m_HealthSlider != null) m_HealthSlider.value = currentHealth / 100;
        
        if (m_HealthFillImage != null) m_HealthFillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, currentHealth / m_StartingHealth);
    }

    private void SetArmorUI()
    {
        if (m_ArmorSlider != null) m_ArmorSlider.value = _playerArmor / 100;

        if (m_ArmorFillImage != null) m_ArmorFillImage.color = Color.Lerp(m_ZeroArmorColor, m_FullArmorColor, _playerArmor / m_StartingArmor);
    }


    private void OnDeath()
    {
        dead = true;

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        
        if(gameObject.name.Contains("Player"))
        {
            GameObject playerSpawnerObj = GameObject.Find("PlayerSpawner");
            PlayerSpawner playerSpawner = playerSpawnerObj.GetComponent<PlayerSpawner>();
            gameObject.SetActive(false);
            GameObject coinManagerObject = GameObject.Find("CoinManager");
            CoinManager coinManager = coinManagerObject.GetComponent<CoinManager>();
            /*
            if (coinManager._coinCount >= 5 )
            {
                coinManager._coinCount -= 5;
            }
            */
            playerSpawner.SpawnPlayer();
        }

        if(!gameObject.name.Contains("Player")) 
        {
            gameObject.GetComponent<TankAI>().StopFiring();
            Instantiate(coinPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            gameObject.SetActive(false);
        }

    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        SetHealthUI();
    }

    public void AddArmor(float amount)
    {
        _playerArmor += amount;
        SetArmorUI();
    }
}