using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Damage();

    }

    void Move()
    {
        transform.Translate(Vector3.left);
    }


    void Damage()
    {
        RaycastHit hit = new RaycastHit();

        Ray ray = new Ray(transform.position, -transform.right);
        Debug.DrawRay(transform.position, ray.direction * 100, Color.white);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            float distance = (transform.position - hit.transform.position).magnitude;
            if (distance <= 10)
            {
                hit.transform.GetComponent<CharacterCtrl>().hp -= 1;

                Destroy(gameObject);
            }

        }
    }
    
}
