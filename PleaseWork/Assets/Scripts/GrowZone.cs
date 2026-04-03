using UnityEngine;

public class GrowZone : MonoBehaviour
{
    public float growthAmount = 1.2f; // how much bigger each time

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // make sure your sphere has this tag
        {
            other.transform.localScale *= growthAmount;
        }
    }
}