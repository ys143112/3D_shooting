using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private float spd = 1.1f;

    void Start()
    {
        
    }

    void Update()
    {
        Damage();
        Check();
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.back*spd);
        
    }

    void Check()
    {
        if (transform.position.z <= 0)
        {
            SendMessageUpwards("PlusVoid", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }


    }

    //CharacterCtrl에서 총알을 잘 체크 못한다면
    void Damage()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = new Ray(transform.position, -transform.forward);
        //Debug.DrawRay(transform.position, ray.direction * 100, Color.white);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject.CompareTag("Player"))
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
