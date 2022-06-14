using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [Header("카메라 기본 속성")]
    private Transform camTransform = null;

    private bool camSwitch = false;



    public GameObject targetObj = null;

    private Transform targetObjTrans = null;

    public enum CameraTypeState { First, Third }

    public CameraTypeState cameraState = CameraTypeState.First;

    [Header("3인칭 카메라")]
    public float distance = 6.0f;
    public float height = 1.75f;

    public float heightDamp = 20f;
    public float rotationDamp = 3f;

    [Header("1인칭카메라")]
    public float detailX = 5f;
    public float detailY = 5f;

    public Transform posFirstTrans = null;

    void FirstCamera()
    {
        camTransform.position = posFirstTrans.position;
    }


    private void LateUpdate()
    {
        if (targetObj == null) return;

        if (targetObjTrans == null)
        {
            targetObjTrans = targetObj.transform;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(camSwitch==true)
            {
                camSwitch = false;
            }
            else
            {
                camSwitch = true;
            }
            
        }
        switch (camSwitch)
        {
            case true:
                ThirdCamera();
                break;
            case false:
                FirstCamera();
                break;
        }
    }
    void Start()
    {
        camTransform = GetComponent<Transform>();

        if (targetObj != null)
        {
            targetObjTrans = targetObj.transform;
        }

    }

    void ThirdCamera()
    {
        float targetObjRotationAngle = targetObjTrans.eulerAngles.y;

        float objHeight = targetObjTrans.position.y + height;

        float nowRotationAngle = camTransform.eulerAngles.y;
        float nowHeight = camTransform.position.y;

        nowRotationAngle = Mathf.LerpAngle(nowRotationAngle, targetObjRotationAngle, rotationDamp * Time.deltaTime);

        nowHeight = Mathf.Lerp(nowHeight, objHeight, heightDamp * Time.deltaTime);

        Quaternion nowRotation = Quaternion.Euler(0f, nowRotationAngle, 0f);

        camTransform.position = targetObjTrans.position;
        camTransform.position -= nowRotation * Vector3.forward * distance;

        camTransform.position = new Vector3(camTransform.position.x, nowHeight, camTransform.position.z);

        camTransform.LookAt(targetObjTrans);

    }
}
