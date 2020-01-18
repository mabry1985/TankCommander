using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform target;

  public float smoothSpeed = 0.125f;
  public Vector3 mainCamOffset;
  public Quaternion mainCamRotation;
  public Vector3 menuCamOffset; 
  public Quaternion menuCamRotation;

  private bool mainMenu = false;
  

  void LateUpdate() 
  {

      if(mainMenu)
      {
          transform.position = target.position + menuCamOffset;

      }
      else
      {
          transform.position = target.position + mainCamOffset;  
          transform.rotation = mainCamRotation;
      }

  }

}
