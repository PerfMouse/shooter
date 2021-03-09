using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public static PlayerEvents instance;

    private void Start()
    {
        if (instance != null)
        {
            Debug.Log("instance already exists, destroying...");
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    public void Die(Player p)
    {
        transform.position = new Vector3(0, 0.5f, 0);
        Debug.Log($"[PLAYER EVENT]: {p.username} died");

        ServerSend.PlayerPosition(p);
    }

    public void Damage(Player p, int _dmg)
    {
        p.hp -= _dmg;
    }
}
