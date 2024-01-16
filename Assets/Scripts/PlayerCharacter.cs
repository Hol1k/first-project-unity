using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float health;

    void Start()
    {
        health = 5.0f;
    }

    public void Hurt(float damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }
}
