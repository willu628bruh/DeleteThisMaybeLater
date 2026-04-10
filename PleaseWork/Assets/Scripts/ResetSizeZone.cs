using UnityEngine;

public class ResetSizeZone : MonoBehaviour
{
    private GrowZone[] growZones;

    private void Start()
    {
        growZones = FindObjectsOfType<GrowZone>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset player size
            PlayerScale ps = other.GetComponent<PlayerScale>();
            if (ps != null)
            {
                other.transform.localScale = ps.originalScale;
            }

            // 👇 Reactivate all grow zones
            foreach (GrowZone zone in growZones)
            {
                zone.ResetGrowZone();
            }
        }
    }
}