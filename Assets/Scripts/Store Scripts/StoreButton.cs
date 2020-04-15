using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour
{
    [SerializeField]
    Canvas storeCanvas;
    private bool _isStoreOpen;
    

    public void OpenStore()
    {
        
        storeCanvas.gameObject.SetActive(true);
        _isStoreOpen = true;
        if (_isStoreOpen == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);

        }
        
       
    }

    public void CloseStore()
    {
        storeCanvas.gameObject.SetActive(false);
        _isStoreOpen = false;
        if (_isStoreOpen == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            

        }
    }
}
