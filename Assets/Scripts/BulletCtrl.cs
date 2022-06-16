using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BulletCtrl : MonoBehaviour
{
    private float spd = 5f;
    private float rotateTime = 5f;
    void Start()
    {
        
    }

    void Update()
    {
        Damage();
        Check();
        
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        spd += Time.fixedDeltaTime;
        transform.Translate(Vector3.back*spd);

        float rotationVal = 30f;
        Vector3 rotateVec = new Vector3(transform.rotation.x + rotationVal,
            transform.rotation.y + rotationVal, transform.rotation.z + rotationVal);

        transform.DORotate(rotateVec,rotateTime,RotateMode.WorldAxisAdd);
    }

    void Check()
    {
        if (transform.position.z <= 0)
        {
            SendMessageUpwards("PlusVoid", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }

    void Damage()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = new Ray(transform.position, -transform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                float distance = (transform.position - hit.transform.position).magnitude;
                if (distance <= 8)
                {
                    hit.transform.GetComponent<CharacterCtrl>().hp -= 1;
                    Destroy(gameObject);
                }
            }
        }
    }

}
