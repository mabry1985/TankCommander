using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private Coin _coin;

    [SerializeField]
    public int _cointCount = 0;

    [SerializeField]
    public Text _coinCountText;

    void Start()
    {
        _cointCount = 0;
        _coin = GameObject.FindObjectOfType<Coin>();
        if (_coin == null)
        {
            Debug.LogError("Coin Reference is NULL");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectCoin()
    {
        _cointCount += 1;
    }



}
