using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
           
    public Rigidbody shell;            
    public Transform fireTransform;    
    public Slider aimSlider;           
    public AudioSource shootingAudio;  
    public AudioClip chargingClip;     
    public AudioClip fireClip;         
    public float minLaunchForce = 8f; 
    public float maxLaunchForce = 30f; 
    public float maxChargeTime = 1f;
    public float timeBetweenShots = 0.35f;


    private string fireButton;         
    private float currentLaunchForce;  
    private float chargeSpeed;         
    private bool fired;
    private bool holdingFire;
    private float timestamp;

    public void OnPress()
    {
        holdingFire = true;
    }

    public void OnRelease()
    {
        if(holdingFire && Time.time >= timestamp )
        {
            Fire();
            timestamp = Time.time + timeBetweenShots;
        }
        holdingFire = false;
    }


    private void OnEnable()
    {
        currentLaunchForce = minLaunchForce;
        aimSlider.value = minLaunchForce;
    }


    private void Start()
    {
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }
   
    private void Update()
    {
        aimSlider.value = minLaunchForce;

        if(Time.time >= timestamp && holdingFire && currentLaunchForce >= maxLaunchForce && !fired)
        {
          currentLaunchForce = maxLaunchForce;
          Fire();
          timestamp = Time.time + timeBetweenShots;
        }
        else if(holdingFire && !fired)
        {
          currentLaunchForce += chargeSpeed * Time.deltaTime;
          aimSlider.value = currentLaunchForce;
        }
        
        else if(holdingFire)
        {
          fired = false;
          currentLaunchForce = minLaunchForce;
          shootingAudio.clip = chargingClip;
          shootingAudio.Play();
        }
    }


    private void Fire()
    {
        fired = true;

        Rigidbody shellInstance = Instantiate(shell, fireTransform.position, fireTransform.rotation) as Rigidbody;

        shellInstance.velocity = currentLaunchForce * fireTransform.forward;

        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        currentLaunchForce = minLaunchForce;
    }
}