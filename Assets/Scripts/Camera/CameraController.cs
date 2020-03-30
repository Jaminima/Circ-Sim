using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float EdgeSize = 10, MoveSpeed = 0.02f;

    public void FixedUpdate()
    {
        Vector3 mPos = Input.mousePosition;
        if (0 <= mPos.x && mPos.x < EdgeSize) transform.Translate(-MoveSpeed, 0, 0);
        else if (Screen.width >= mPos.x && Input.mousePosition.x > Screen.width - EdgeSize) transform.Translate(MoveSpeed, 0, 0);

        if (0 <= mPos.y && Input.mousePosition.y < EdgeSize) transform.Translate(0, -MoveSpeed, 0);
        else if (Screen.height >= mPos.y && Input.mousePosition.y > Screen.height - EdgeSize) transform.Translate(0, MoveSpeed, 0);
    }

    public void ZoomIn()
    {
        Camera.main.orthographicSize -= 0.5f;
    }

    public void ZoomOut()
    {
        Camera.main.orthographicSize += 0.5f;
    }
}
