using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    [SerializeField]
    private GameObject _storeOpenButton;
    [SerializeField]
    public bool _storeClosed = false;

    private void Start()
    {
        //_storeOpenButton = GameObject.Find("Store_Open_Button").GetComponent<>();
        //_storeOpenButton.gameObject.SetActive(_storeClosed);
        

        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
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
        
    }
}
