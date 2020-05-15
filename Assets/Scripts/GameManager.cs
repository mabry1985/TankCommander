using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Manage Coin Count and Updating Coin Text
//Manage Store Open/Close Feature


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int _coinCount = 0;
    [SerializeField]
    public Text _coinCountText;

    [Header("Store Open Close Functions")]
    [SerializeField]
    private Canvas _storePanel;

    private bool _isStoreOpen;

    private void Awake()
    {
        _storePanel = GameObject.Find("Store_Canvas").GetComponent<Canvas>();
    }


    void Start()
    {
       _coinCountText.text = "$ " + _coinCount.ToString();
        _isStoreOpen = false;
        _storePanel.gameObject.SetActive(_isStoreOpen);

    }

    public void CollectCoin()
    {
        _coinCount += 1;
        _coinCountText.text = "$ " + _coinCount.ToString();
    }

    public void RemoveCoin(int cost)
    {
        _coinCount -= cost;
        _coinCountText.text = "$ " + _coinCount.ToString();

    }

    public void OpenStore()
    {

        _storePanel.gameObject.SetActive(true);
        _isStoreOpen = true;


    }

    public void CloseStore()
    {
        _storePanel.gameObject.SetActive(false);
        _isStoreOpen = false;
    }
}
