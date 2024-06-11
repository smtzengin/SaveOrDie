using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(100);
        }
    }
}
