using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    public AIController aiController;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            aiController.SetTarget(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            aiController.SetTarget(other.transform); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            aiController.ClearTarget();
        }
    }
}
