using UnityEngine;

public class GrowZone : MonoBehaviour
{
    public float growthAmount = 1.2f;

    [Range(0f, 1f)]
    public float transparentAlpha = 0.3f;

    private bool hasGrown = false;
    private Renderer rend;
    private Color originalColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        if (rend != null)
        {
            originalColor = rend.material.color; // store original color
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasGrown && other.CompareTag("Player"))
        {
            // Grow player
            other.transform.localScale *= growthAmount;

            // Make transparent
            if (rend != null)
            {
                Color color = rend.material.color;
                color.a = transparentAlpha;
                rend.material.color = color;

                SetMaterialTransparent(rend.material);
            }

            hasGrown = true;
        }
    }

    // 👇 Called by ResetSizeZone
    public void ResetGrowZone()
    {
        hasGrown = false;

        // Restore original look
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }

    void SetMaterialTransparent(Material mat)
    {
        mat.SetFloat("_Mode", 3);

        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);

        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");

        mat.renderQueue = 3000;
    }
}