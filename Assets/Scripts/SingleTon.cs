using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T:MonoBehaviour
{
    //Ŭ���� Ÿ���� �ν��Ͻ��� ����ƽ���� ����
    static T _instance=null;
    
    //�ν��Ͻ� ����
    public static T Instance
    {
        //get
        get
        {
            //�˻�
            _instance = (T)FindObjectOfType(typeof(T));
            //����
            if (_instance==null)
            {
                var _newObject = new GameObject(typeof(T).ToString());
                _instance = _newObject.AddComponent<T>();
            }

            //�ν��Ͻ� �����ֱ�
            return _instance;
        }
        
    }
    protected virtual void Awake()
    {
        if(_instance==null)
        {
            _instance = this as T;
        }
        DontDestroyOnLoad(gameObject);
    }

    

}
