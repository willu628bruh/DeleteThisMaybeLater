using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    float power;
    public float maxPower = 100f;
    public Slider powerSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;

    }

    // Update is called once per frame
    void Update()
    {
        powerSlider.value = power;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) ;
    }

}
