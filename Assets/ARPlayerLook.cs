using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlayerLook : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;  // AR ī�޶� Transform (���� Camera.main.transform)

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;  // ���� ���� ����, ���� ��鿡���� ȸ���ϵ���

        if (cameraForward.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            gameObject.transform.rotation = targetRotation;
        }
    }
}
