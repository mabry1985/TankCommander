using UnityEngine;

public class PlayerTank : MonoBehaviour {

 	public float speed = 10.0F;
    public float rotationSpeed = 100.0f;
    public float pitchRange = 0.02f;

    private Joystick joystick;

    public AudioSource movementAudio;
    public AudioClip engineIdling;
    public AudioClip engineDriving;


    private Rigidbody m_Rigidbody;
    private float originalPitch;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        originalPitch = movementAudio.pitch;
        GameObject joystickObject = GameObject.Find("DriveJoystick");
        if (joystickObject == null)
        {
            Debug.LogError("No Joystick Found");
        }
        else
        {
            joystick = joystickObject.GetComponent<FixedJoystick>();
        }
        
        
    }

    private void OnEnable () 
    {
        m_Rigidbody.isKinematic = false;
    }

    void Update() {
        float translation = Input.GetAxis("Vertical");
        //float translation = joystick.Vertical * speed;
        
        
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //float rotation = joystick.Horizontal * rotationSpeed;
        
        transform.Translate(0, 0, translation * speed * Time.deltaTime);
        transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);

        /*if (Mathf.Abs(translation) < 0.2f)
        {
            if(movementAudio.clip == engineDriving) 
            {
                movementAudio.clip = engineIdling;
                movementAudio.pitch = Random.Range (originalPitch - pitchRange, originalPitch + pitchRange);
                movementAudio.Play();
            }
        }
        else
        {
            if (movementAudio.clip == engineIdling)
            {
                movementAudio.clip = engineDriving;
                movementAudio.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                movementAudio.Play();
            }
        }*/

    }

}

