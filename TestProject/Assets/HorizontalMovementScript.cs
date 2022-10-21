using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovementScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D Rigidbody2D;
    private GameObject GameObject;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); 
        GameObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Rigidbody2D.position.x > -9)
        {
            Rigidbody2D.velocity = new Vector2(-1 * speed, 0);

        }
        else
        {
            Rigidbody2D.velocity = new Vector2(0, 0);
            Rigidbody2D.Destroy(gameObject, 5);

        }

    }
}
