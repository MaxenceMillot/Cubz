using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            GetComponent<AudioSource>().Play();
            if (playerMovement.isUnstopable)
                return;
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
