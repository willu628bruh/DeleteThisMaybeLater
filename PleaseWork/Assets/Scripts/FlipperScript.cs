using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;

    public KeyCode inputKey; // ← use key instead of axis

    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    void Update()
    {
        JointSpring spring = hinge.spring;

        if (Input.GetKey(inputKey))
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
        }

        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        hinge.spring = spring;
    }
}