using UnityEngine;
using System.Collections;

public class DisappearingPlatform : MonoBehaviour
{
    public float delayBeforeDisappear = 1f; // NEW delay
    public float respawnTime = 5f;

    private Renderer rend;
    private Collider col;
    private bool isTriggered = false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isTriggered && collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(DisappearAndRespawn());
        }
    }

    IEnumerator DisappearAndRespawn()
    {
        // Wait before disappearing
        yield return new WaitForSeconds(delayBeforeDisappear);

        // Disable platform
        rend.enabled = false;
        col.enabled = false;

        // Wait before coming back
        yield return new WaitForSeconds(respawnTime);

        // Re-enable platform
        rend.enabled = true;
        col.enabled = true;

        isTriggered = false; // allow reuse
    }
}