using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource coinSound;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);

    }

    private void OnTriggerEnter(Collider other) 
    {
       if (other.name.Contains("Player"))
       {
            coinSound.Play();
            GameObject gameManagerObject = GameObject.Find("GameManager");
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>(); 
            gameManager.CollectCoin();
            MeshRenderer render =this.gameObject.GetComponent<MeshRenderer>();
            render.enabled = false;
            Destroy(this.gameObject, .5f);
       }
    }
    
}
