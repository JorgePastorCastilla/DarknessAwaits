using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 10.0f;
    float cameraSpeed = 200.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * cameraSpeed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
    }
}
