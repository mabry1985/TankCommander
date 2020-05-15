using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Animator transition;

    public void OnClickStart()
    {
        StartCoroutine(FadeOut());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator FadeOut()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        LoadingStateManager.Load(LoadingStateManager.Scene.Tanks);
    }
}
