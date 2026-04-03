using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlungerScript : MonoBehaviour
{
    float power;
    float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    public List<Rigidbody> ballsList;
    bool ballReady;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballsList = new List<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }
        powerSlider.value = power;
        if (ballsList.Count > 0)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (power <= maxPower)
                {
                    foreach (Rigidbody r in ballsList)
                    {
                        r.AddForce(power * Vector3.forward);
                    }
                }
            }
            else
            {
                ballReady = false;
                power = 0f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ballsList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ballsList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }

}
