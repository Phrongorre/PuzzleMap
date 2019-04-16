using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool state;

    public float closedAngle = 0f;
    public float openAngle = 115f;

    // Start is called before the first frame update
    void Start()
    {
        state = false;
    }
    
    void FixedUpdate()
    {
        if (state)
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(0f, 0f, openAngle), 0.5f);
        }
        else
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(0f, 0f, closedAngle), 0.5f);
        }
    }

    public void Open()
    {
        state = true;
    }

    public void Close()
    {
        state = false;
    }
}
