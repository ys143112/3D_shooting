using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    bool setTrigger =false;

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
        transform.Translate(Vector3.left);
    }

    void Check()
    {
        if (transform.position.z <= 0)
        {
            SendMessageUpwards("PlusVoid", 1f, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }


    }

    //CharacterCtrl���� �Ѿ��� �� üũ ���Ѵٸ�
    void Damage()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = new Ray(transform.position, -transform.right);
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
