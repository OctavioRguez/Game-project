using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDirection : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    Vector2 mousepos;
    Vector2 look_direction;
    
    void Start()
    {
        rb.mass = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void Update()
    {
        Mouse();
    }

    void FixedUpdate()
    {
        look_direction = mousepos - rb.position;
        float angle = Mathf.Atan2(look_direction.y, look_direction.x) * Mathf.Rad2Deg +90f;
        rb.rotation = angle;
    }

    private void Mouse()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
