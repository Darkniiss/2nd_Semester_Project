using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private PlayerController playerCon;
    [SerializeField] private Vector3 posOffset;

    private void LateUpdate()
    {
        transform.position = playerCon.transform.position + posOffset;
    }
}
