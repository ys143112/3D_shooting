using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Transform cameraTrans = null;

    private float detailX = 5f;
    private float detailY = 5f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    public Transform FirstCamTrans = null;

    void Start()
    {
        cameraTrans = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        FirstCamera();
    }

    void FirstCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX = mouseX * detailX  + cameraTrans.localEulerAngles.y;
        rotationX = (rotationX > 180.0f) ? rotationX - 360.0f : rotationX;
        rotationY = mouseY * detailY + rotationY;
        rotationY = (rotationY > 180.0f) ? rotationY - 360.0f : rotationY;

        cameraTrans.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);
        cameraTrans.position = FirstCamTrans.position;
    }


}
