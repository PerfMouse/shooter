using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerManager player;
    public float sens = 100f;
    public float clampAngle = 80f;

    private float verticalRotation;
    private float horizontalRotation;

    private void Start()
    {
        verticalRotation = transform.eulerAngles.x;
        horizontalRotation = transform.eulerAngles.y;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        float _mouseVertical = Input.GetAxisRaw("Mouse Y");
        float _mouseHorizontal = Input.GetAxisRaw("Mouse X");

        verticalRotation += _mouseVertical * sens * Time.deltaTime;
        horizontalRotation += _mouseHorizontal * sens * Time.deltaTime;

        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(-verticalRotation, 0f, 0f);
        player.transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);
    }
}