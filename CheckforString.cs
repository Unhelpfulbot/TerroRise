using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckforString : MonoBehaviour
{
    public string desired;
    public Text texts;
    public Health health;
    private float KilledCd = 10f;
    private float KillTime;
    private void Start()
    {
        KillTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if(texts.text == desired)
        {
            if (KillTime < Time.time)
            {
                health.Killself();
                KillTime = Time.time + KilledCd;
            }
        }
    }
}
