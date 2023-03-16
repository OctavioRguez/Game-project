using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public StickmanControl movement;

    private void Start()
    {
        movement = GameObject.FindObjectOfType<StickmanControl>().GetComponent<StickmanControl>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement.Ground = true;
    }

}
