using System;
using _Core.Scripts.Interfaces;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<IDamageble>() != null)
        {
            other.gameObject.GetComponent<IDamageble>().TakeDamage();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
