using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private StoreButton _storeButton;
    [SerializeField]
    public bool _storeOpen = false;

    private void Start()
    {
        _storeButton = GameObject.FindObjectOfType<Canvas>().GetComponent<StoreButton>();
        if (_storeButton == null)
        {
            Debug.LogError("Store Button is NULL");
        }
        else
        {
            _storeButton.gameObject.SetActive(_storeOpen);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("CoinManager is NULL");
        }

    }
    void Update()
    {
        
    }

    public void UpdateCoinText()
    {
        _gameManager._coinCountText.text = "$ " + _gameManager._coinCount;
        Debug.LogError("UpdateCoinText Running");
    }
}
