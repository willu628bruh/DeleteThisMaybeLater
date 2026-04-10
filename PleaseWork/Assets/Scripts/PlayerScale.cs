using UnityEngine;

public class PlayerScale : MonoBehaviour
{
    public Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }
}