using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{

    private bool isFirstUpdate = true;

    private void Update()
    {
        StartCoroutine(LoadingScreenDelay());
        
    }

    private IEnumerator LoadingScreenDelay()
    {
        yield return new WaitForSeconds(2);

        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            LoadingStateManager.LoaderCallback();
        }
    }

} 
