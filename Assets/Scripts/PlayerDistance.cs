using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDistance : MonoBehaviour
{
    public Text distanceText = null;
    private string distance;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distance = GameManager.Instance.NowDistance.ToString();
        CheckDistance();
    }

    void CheckDistance()
    {
        distanceText.text = distance+"km";
    }
}
