using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muscles : MonoBehaviour
{
    public _Muscles[] muscles;

    void Update()
    {
        foreach (_Muscles muscle in muscles)
        {
            muscle.ActivateMuscle();
        }
    }
}

[System.Serializable]

public class _Muscles
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;

    public void ActivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
    }
}
