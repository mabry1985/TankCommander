using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineLight : MonoBehaviour
{
    public float blinkTime = 2f;

    Color lerpedColor = Color.white;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        lerpedColor = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1));
        renderer.material.color = lerpedColor;

    }

    IEnumerator Blink()
    {
        while (true)
        {
            renderer.material.color = Color.black;
            yield return new WaitForSeconds(blinkTime);
            renderer.material.color = Color.red;
            yield return new WaitForSeconds(blinkTime);
        }

    }
}