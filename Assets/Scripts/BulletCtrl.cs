using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletCtrl : MonoBehaviour
{
    private float spd = 5f;
    private float rotateTime = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        Check();
        
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if(gameObject!=null)
        {
            spd += Time.fixedDeltaTime;
            transform.Translate(Vector3.back * spd, Space.World);

            float rotationVal = 180f;
            Vector3 rotateVec = new Vector3(transform.rotation.x + rotationVal,
                transform.rotation.y + rotationVal, transform.rotation.z + rotationVal);
            transform.DORotate(rotateVec, rotateTime);
        }
       
    }

    void Check()
    {
        if (transform.position.z <= 0)
        {
            SendMessageUpwards("PlusVoid", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }

    

}
