using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    float speed = 2.0f;
    Vector3 direction = Vector3.down;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO MEDIANTE ACTUALIZAR EL TRANSFORM
        //transform.position += Vector3.up * Time.deltaTime * speed;
        //MOVIMIENTO MEDIANTE FUERZAS
        // transform.Translate(Vector3.up * speed * Time.deltaTime);
        // transform.Translate(new Vector3(speed * Time.deltaTime,0,0) );
        if (transform.position.y < 1.25 || transform.position.y > 6.25)
        {
            direction = (direction == Vector3.down) ? Vector3.up : Vector3.down;
        }

        // transform.position += direction * Time.deltaTime * speed;
        transform.Translate( direction * speed * Time.deltaTime );
    }
}
