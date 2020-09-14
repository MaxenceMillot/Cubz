using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private int collisionCount = 0;

    void OnCollisionEnter(Collision collision)
    {
        collisionCount++;

        // Collision with ground = normal speed
        if (collision.collider.tag == "Ground")
        {
            playerMovement.forwardSpeedMultiplicator = 1f;
        }

        // Collision with ramp = speedboost
        if (collision.collider.tag == "Ramp")
        {
            playerMovement.forwardSpeedMultiplicator = 1.3f;
        }

        // Collision with Obstacle = loose
        if (collision.collider.tag == "Obstacle")
        {
            GetComponent<AudioSource>().Play();
            if (playerMovement.isUnstopable)
                return;
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        collisionCount--;
        // When player is not colliding (flying) slow movement
        if(collisionCount == 0)
            playerMovement.forwardSpeedMultiplicator = 0.7f;
    }
}
