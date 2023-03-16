using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{
    public Transform targetLimb;
    Transform trans;
    public bool mirror;
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        if (!mirror)
        {
            trans.rotation = targetLimb.rotation;
        }
        else 
        {
            trans.rotation = Quaternion.Inverse(targetLimb.rotation);
        }
    }
}
