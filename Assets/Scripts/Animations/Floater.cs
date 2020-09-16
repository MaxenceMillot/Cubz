using UnityEngine;

public class Floater : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    private void Update()
    {
        // Float up and down
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
