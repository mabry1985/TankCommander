using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingText : MonoBehaviour
{

    public MeshRenderer sphere1;
    public MeshRenderer sphere2;
    public MeshRenderer sphere3;

    public float seconds = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        DisableElipsis();
        StartCoroutine(AnimateElipsis(seconds));
    }

    private IEnumerator AnimateElipsis(float sec)
    {
        while (true) {
            sphere1.enabled = true;
            yield return new WaitForSeconds(sec);
            sphere2.enabled = true;
            yield return new WaitForSeconds(sec);
            sphere3.enabled = true;
            yield return new WaitForSeconds(sec);
            DisableElipsis();
            yield return new WaitForSeconds(sec);
        }
    }

    private void DisableElipsis ()
    {
        sphere1.enabled = false;
        sphere2.enabled = false;
        sphere3.enabled = false;
    }
}
