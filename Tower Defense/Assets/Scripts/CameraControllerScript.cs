using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    private float panSpeed = 30f;
    private float panBorderThickness = 10f;
    private float scrollSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float upAndDown = Input.GetAxis("Vertical");
        float leftAndRight = Input.GetAxis("Horizontal");
        if(upAndDown != 0 )
        {
            transform.Translate(Vector3.forward * upAndDown * panSpeed * Time.deltaTime, Space.World);
        }
       
        if (leftAndRight != 0)
        {
            transform.Translate(Vector3.right * leftAndRight * panSpeed * Time.deltaTime, Space.World);
        }

    }
}
