using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource coinSound;

    [SerializeField]
    private float _rotateSpeed = 200f;

    [SerializeField]
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            _gameManager.CollectCoin();
            MeshRenderer render =this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            Destroy(transform.parent.gameObject, .5f);
       }
    }
    
}
