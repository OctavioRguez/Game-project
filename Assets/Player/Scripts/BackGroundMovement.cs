using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    public GameObject BackGround;
    public GameObject chest;
    private float position;
    private float position_time;
    private float time;

    void Start()
    {
        position = chest.transform.position.x - (-0.4808083f);
    }

    void Update()
    {
        position = chest.transform.position.x;

        time += Time.deltaTime;
        if (time > 1)
        {
            position_time = chest.transform.position.x;
            time = 0f;
        }

        if (position > position_time)
        {
            BackGround.transform.Translate(-position/200000, 0.0f, 0.0f);
        }
        else if (position < position_time)
        {
            BackGround.transform.Translate(position/200000, 0.0f, 0.0f);
        }
    }
}
