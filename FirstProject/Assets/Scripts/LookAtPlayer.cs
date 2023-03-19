using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    protected Transform pCam;
    void LateUpdate()
    {
        transform.LookAt(pCam);
    }
}
