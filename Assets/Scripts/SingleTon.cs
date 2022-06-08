using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T:MonoBehaviour
{
    //클래스 타입의 인스턴스를 스태틱으로 생성
    static T _instance=null;
    
    //인스턴스 생성
    public static T Instance
    {
        //get
        get
        {
            //검색
            _instance = (T)FindObjectOfType(typeof(T));
            //없네
            if (_instance==null)
            {
                var _newObject = new GameObject(typeof(T).ToString());
                _instance = _newObject.AddComponent<T>();
            }

            //인스턴스 돌려주기
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
