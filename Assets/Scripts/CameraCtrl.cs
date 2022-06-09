using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [Header("카메라 기본 속성")]
    //카메라 위치 캐싱 준비
    private Transform camTransform = null;

    private bool camSwitch = false;



    //target
    public GameObject targetObj = null;

    //player transform 캐싱
    private Transform targetObjTrans = null;

    //카메라가 3가지
    public enum CameraTypeState { First, Third }

    //카메라 기본 3인칭 default
    public CameraTypeState cameraState = CameraTypeState.First;

    [Header("3인칭 카메라")]
    //떨어진 거리
    public float distance = 6.0f;
    //추가 높이
    public float height = 1.75f;

    //smooth time
    public float heightDamp = 20f;
    public float rotationDamp = 3f;

    [Header("1인칭카메라")]
    //마우스 카메라 조절 디테일 좌표
    public float detailX = 5f;
    public float detailY = 5f;

    //캐싱
    public Transform posFirstTrans = null;

    /// <summary>
    /// 1인칭 카메라 조작 함수
    /// </summary>
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

        //타켓이 있나?
        if (targetObj != null)
        {
            targetObjTrans = targetObj.transform;
        }

    }

    /// <summary>
    /// 3인칭 카메라 기본 동작 함수
    /// </summary>
    void ThirdCamera()
    {
        //현재 타겟 Y축 각도 값
        float targetObjRotationAngle = targetObjTrans.eulerAngles.y;

        //현재 타겟 높이+카메라가 위치한 높이 추가 높이
        float objHeight = targetObjTrans.position.y + height;

        //현재 각도 높이
        float nowRotationAngle = camTransform.eulerAngles.y;
        float nowHeight = camTransform.position.y;

        //현재 각도에 대한 Damp
        nowRotationAngle = Mathf.LerpAngle(nowRotationAngle, targetObjRotationAngle, rotationDamp * Time.deltaTime);

        //현재 높이에 대한 Damp
        nowHeight = Mathf.Lerp(nowHeight, objHeight, heightDamp * Time.deltaTime);

        //유니티 각도로 치환
        Quaternion nowRotation = Quaternion.Euler(0f, nowRotationAngle, 0f);

        //카메라 위치 포지션 이동
        camTransform.position = targetObjTrans.position;
        camTransform.position -= nowRotation * Vector3.forward * distance;

        //최종 이동
        camTransform.position = new Vector3(camTransform.position.x, nowHeight, camTransform.position.z);

        camTransform.LookAt(targetObjTrans);

    }
}
