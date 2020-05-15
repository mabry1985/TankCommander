using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Camera firstPersonCamera;
    public Camera overheadCamera;
    public Vector3 mainCamOffset;

    private bool selected= false;
    

    void LateUpdate() 
    {
        transform.position = target.position + mainCamOffset;        
    }

    public void ShowOverheadView()
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }

    public void OnClickCamButton(){
        selected = !selected;

        if (selected)
        {
            ShowOverheadView();
        }
        else
        {
            ShowFirstPersonView();
        }

    }
}
