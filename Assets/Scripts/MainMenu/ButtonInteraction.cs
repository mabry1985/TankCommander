using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{

    public Button button;
    public Text text;

    public void ButtonAnimate()
    {
        text.fontSize = 25;
        StartCoroutine(ResetFontSize(0.25f));
    }

    IEnumerator ResetFontSize(float sec)
    {
        yield return new WaitForSeconds(sec);
        text.fontSize = 30;
    }
    
}
