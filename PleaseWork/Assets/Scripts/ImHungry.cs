using UnityEngine;

public class ImHungry : MonoBehaviour
{
    public Material newMaterial; // assign in Inspector
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            rend.material = newMaterial;
        }
    }
}