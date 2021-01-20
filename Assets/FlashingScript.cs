using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class FlashingScript : MonoBehaviour
{
    bool t = false;
    TMPro.TextMeshProUGUI colr;
    Color32 startColor = new Color32(255, 255, 255, 0);
    Color32 endColor = new Color32(255, 255, 255, 255);
    float speed;
    Color src;
    void Awake()
    {
        colr = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        //Debug.Log(colr);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(colr);
        speed = 0.8f * Time.deltaTime;
        src = colr.color;
        if (!t)
        {
            src.a = src.a - speed;
            colr.color = (Color32) src;
            //  Debug.Log(colr.color);
            if(src.a <= 0.005f)
                t = true;
        }
        else
        {
            src.a = src.a + speed;
            colr.color = (Color32) src;
            if (src.a >= 0.995f)
                t = false;
        }
    }
}
