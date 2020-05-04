using UnityEngine;
using System.Collections;

public class PowerUpMovement : MonoBehaviour
{
    public Transform target;
    public float relPosX = 0f;
    public float relPosY = 0.1f;
    public float relPosZ = 0f;
    public float transPosX = 0f;
    public float transPosY = 0f;
    public float transPosZ = 1f;


    void Update()
    {
        relPosZ = Random.Range(-.01f, .01f);
        Vector3 relativePos = (target.position + new Vector3(relPosX, relPosY, relPosZ)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
        transform.Translate(transPosX, transPosY, transPosZ * Time.deltaTime);
    }
}