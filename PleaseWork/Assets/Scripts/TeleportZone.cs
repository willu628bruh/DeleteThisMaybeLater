using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    public Transform targetLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetLocation.position;
        }
    }
}