using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && Time.timeScale < 1.0f)
        {
            Time.timeScale += 0.25f * Time.unscaledDeltaTime;
        }
        if (Input.GetKey(KeyCode.S) && Time.timeScale > 0)
        {
            Time.timeScale -= 0.25f * Time.unscaledDeltaTime;
        }
       
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0.01f, 1.0f);
    }
}
