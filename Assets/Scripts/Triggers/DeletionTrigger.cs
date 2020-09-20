using UnityEngine;

public class DeletionTrigger : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        if (!FindObjectOfType<GameManager>().isGameOver)
            transform.position = player.position + offset;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
