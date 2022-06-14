using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private float spd = 5f;

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
