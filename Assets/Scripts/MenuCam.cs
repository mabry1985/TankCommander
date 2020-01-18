using UnityEngine;

public class MenuCam : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    void Awake()
    {
        transform.position = target.position + offset;
    }

}
