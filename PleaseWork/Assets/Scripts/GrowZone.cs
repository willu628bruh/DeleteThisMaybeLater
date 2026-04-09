using UnityEngine;

public class GrowZone : MonoBehaviour
{
    public float growthAmount = 1.2f; // how much bigger each time
    public float cooldown = 5f; // 5 second delay

    private float lastTriggerTime = -Mathf.Infinity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= lastTriggerTime + cooldown)
        {
            other.transform.localScale *= growthAmount;
            lastTriggerTime = Time.time;
        }
    }
}