using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEvent : MonoBehaviour {
    public Vector3 rotation;
    public void RotationTrigger()
    {
        GameObject.FindGameObjectWithTag("box").GetComponent<RotationController>().Rotate(rotation);
    }
}
