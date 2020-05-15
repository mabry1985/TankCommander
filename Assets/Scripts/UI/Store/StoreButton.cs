using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    [SerializeField]
    Canvas storeCanvas;
    private bool _isStoreOpen;

    public void Start()
    {
        storeCanvas = GameObject.Find("Store_Canvas").GetComponent<Canvas>();
        if (storeCanvas == null)
        {
            Debug.LogError("Store Canvas is NULL");
        }
    }
    public void OpenStore()
    {
        
        storeCanvas.gameObject.SetActive(true);
        _isStoreOpen = true;
      
       
    }

    public void CloseStore()
    {
        storeCanvas.gameObject.SetActive(false);
        _isStoreOpen = false;
    }
}
