using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.Z),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.Q),
            Input.GetKey(KeyCode.D)
        };

        ClientSend.PlayerMovement(_inputs);
    }
}
