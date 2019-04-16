using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private Camera cam;

    public float reach = 4f;

    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray aimRay = new Ray(transform.TransformPoint(cam.transform.localPosition), cam.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(aimRay, out hit, reach))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    Door door = hit.transform.GetComponent<Door>();
                    door.Open();
                }
            }
        }
    }
}
