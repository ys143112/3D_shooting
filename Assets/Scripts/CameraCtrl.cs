using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [Header("ī�޶� �⺻ �Ӽ�")]
    //ī�޶� ��ġ ĳ�� �غ�
    private Transform camTransform = null;

    private bool camSwitch = false;



    //target
    public GameObject targetObj = null;

    //player transform ĳ��
    private Transform targetObjTrans = null;

    //ī�޶� 3����
    public enum CameraTypeState { First, Third }

    //ī�޶� �⺻ 3��Ī default
    public CameraTypeState cameraState = CameraTypeState.First;

    [Header("3��Ī ī�޶�")]
    //������ �Ÿ�
    public float distance = 6.0f;
    //�߰� ����
    public float height = 1.75f;

    //smooth time
    public float heightDamp = 20f;
    public float rotationDamp = 3f;

    [Header("1��Īī�޶�")]
    //���콺 ī�޶� ���� ������ ��ǥ
    public float detailX = 5f;
    public float detailY = 5f;

    //ĳ��
    public Transform posFirstTrans = null;

    /// <summary>
    /// 1��Ī ī�޶� ���� �Լ�
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

        //Ÿ���� �ֳ�?
        if (targetObj != null)
        {
            targetObjTrans = targetObj.transform;
        }

    }

    /// <summary>
    /// 3��Ī ī�޶� �⺻ ���� �Լ�
    /// </summary>
    void ThirdCamera()
    {
        //���� Ÿ�� Y�� ���� ��
        float targetObjRotationAngle = targetObjTrans.eulerAngles.y;

        //���� Ÿ�� ����+ī�޶� ��ġ�� ���� �߰� ����
        float objHeight = targetObjTrans.position.y + height;

        //���� ���� ����
        float nowRotationAngle = camTransform.eulerAngles.y;
        float nowHeight = camTransform.position.y;

        //���� ������ ���� Damp
        nowRotationAngle = Mathf.LerpAngle(nowRotationAngle, targetObjRotationAngle, rotationDamp * Time.deltaTime);

        //���� ���̿� ���� Damp
        nowHeight = Mathf.Lerp(nowHeight, objHeight, heightDamp * Time.deltaTime);

        //����Ƽ ������ ġȯ
        Quaternion nowRotation = Quaternion.Euler(0f, nowRotationAngle, 0f);

        //ī�޶� ��ġ ������ �̵�
        camTransform.position = targetObjTrans.position;
        camTransform.position -= nowRotation * Vector3.forward * distance;

        //���� �̵�
        camTransform.position = new Vector3(camTransform.position.x, nowHeight, camTransform.position.z);

        camTransform.LookAt(targetObjTrans);

    }
}
