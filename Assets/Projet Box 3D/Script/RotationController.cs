using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {
    public float damping = 10;
    public Vector3 nextRot;
    public float angleDif;
    public bool inRotation;
    // Update is called once per frame
    void Update ()
    {
        var desiredRotQ = Quaternion.Euler(nextRot.x, nextRot.y, nextRot.z);
        if (Quaternion.Angle(transform.rotation, desiredRotQ) >= 1f)
        {
            if(!inRotation)
                inRotation = true;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
            angleDif = Quaternion.Angle(transform.rotation, desiredRotQ);
        }
        else
        {
            transform.rotation = Quaternion.Euler(nextRot);
            angleDif = 0f;
            inRotation = false;
        }
	}

    public void Rotate(Vector3 Rotation)
    {
        nextRot = transform.rotation.eulerAngles + Rotation;
    }
}
