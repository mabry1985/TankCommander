using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rocket;
    public float speed = 3f;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rocket.transform.Translate(0, 5 * Time.deltaTime * speed, 0);
        rocket.transform.Rotate(0f, .05f, 0f, Space.Self);
    }
}
