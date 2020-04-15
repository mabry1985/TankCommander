using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    private CoinManager coinManager;
    private StoreButton _storeButton;
    public bool _storeOpen = false;

    private void Start()
    {
        _storeButton = GameObject.FindObjectOfType<Canvas>().GetComponent<StoreButton>();
        _storeButton.gameObject.SetActive(_storeOpen);
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();

    }
    void Update()
    {
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        coinManager._coinCountText.text = "$ " + coinManager._coinCount;
    }
}
