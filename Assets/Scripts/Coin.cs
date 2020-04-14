using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource coinSound;

    [SerializeField]
    private float _rotateSpeed = 200f;

    [SerializeField]
    private CoinManager coinManager;

    private void Start()
    {
        CoinManager coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other) 
    {
       if (other.tag == "Player")
       {
            coinSound.Play();
            coinManager.CollectCoin();
            MeshRenderer render =this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            Destroy(transform.parent.gameObject, .5f);
       }
    }
    
}
