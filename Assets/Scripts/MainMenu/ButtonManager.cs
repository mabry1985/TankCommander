using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnClickStart()
    {
        LoadingStateManager.Load(LoadingStateManager.Scene.Tanks);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
