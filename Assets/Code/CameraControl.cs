using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform player;
    [SerializeField][Range(0.5f, 2f)] float sens = 1;
    [SerializeField][Range(-20, 0f)] float minAngle = -8;
    [SerializeField][Range(0f, 20f)] float maxAngle = 8;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * sens;
        float MoyseY = Input.GetAxis("Mouse Y") * sens;
        Vector3 cameraRotation = transform.rotation.eulerAngles;
        Vector3 playerRotation = player.rotation.eulerAngles;

        cameraRotation.x = (cameraRotation.x > 180) ? cameraRotation.x - 360 : cameraRotation.x;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, minAngle, maxAngle);
        cameraRotation.x -= MoyseY;

        cameraRotation.z = 0;
        playerRotation.y += MouseX;

        transform.rotation = Quaternion.Euler(cameraRotation);
        player.rotation = Quaternion.Euler(playerRotation);
    }
}
