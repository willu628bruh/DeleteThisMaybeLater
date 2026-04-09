using UnityEngine;

public class HoldToMoveBack : MonoBehaviour
{
    [Header("Plunger Settings")]
    public float maxPullDistance = 3f; // How far it can go back
    public float pullSpeed = 5f;        // How fast it pulls back
    public float returnSpeed = 15f;     // How fast it returns
    public KeyCode pullKey = KeyCode.Space;

    private Vector3 startPosition;
    private float currentPullDistance = 0f;
    private bool isHolding = false;

    void Start()
    {
        // Store the original position
        startPosition = transform.position;
    }

    void Update()
    {
        // Detect input
        if (Input.GetKey(pullKey))
        {
            isHolding = true;
            // Increase hold duration, capping at max
            currentPullDistance = Mathf.MoveTowards(currentPullDistance, maxPullDistance, pullSpeed * Time.deltaTime);
        }
        else
        {
            isHolding = false;
            // Decrease hold duration back to 0
            currentPullDistance = Mathf.MoveTowards(currentPullDistance, 0f, returnSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        // Move the plunger backward relative to its transform (assuming forward is into the table)
        Vector3 targetPos = startPosition - (transform.forward * currentPullDistance);
        
        // Use Rigidbody MovePosition for smoother interaction with balls
        GetComponent<Rigidbody>().MovePosition(targetPos);
    }
}