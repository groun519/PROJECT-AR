using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;  // AR 카메라 Transform (보통 Camera.main.transform)

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;  // 수직 방향 제거, 수평 평면에서만 회전하도록

        if (cameraForward.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            gameObject.transform.rotation = targetRotation;
        }
    }
}
