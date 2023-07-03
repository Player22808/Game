using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float sens;
    float angelX, angelY;
    public static bool Locked = false;

    void Start()
    {
        angelX = transform.eulerAngles.y;
        angelY = player.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!Locked)
        {
            Cursor.visible = false;
            float MouseX = Input.GetAxis("Mouse Y") * sens * -1;
            float MouseY = Input.GetAxis("Mouse X") * sens;
            angelX += MouseX;
            angelX = Mathf.Clamp(angelX, -60, 43);
            transform.rotation = Quaternion.Euler(angelX, angelY, 0);
            angelY += MouseY;
            player.transform.rotation = Quaternion.Euler(0, angelY, 0);
        }
    }
}
