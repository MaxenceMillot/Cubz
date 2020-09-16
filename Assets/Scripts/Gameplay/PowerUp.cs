using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public float duration = 8f;
    public float sizeMultiplier = 0.5f;
    public float speedMultiplier = 0.75f;
    public TextMeshProUGUI infoUI;   

    public float reducedObstacleMass = 0.2f;
    public float originalObstacleMass = -1f;

    public PowerUps powerUpType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        GetComponent<AudioSource>().Play();

        switch (powerUpType)
        {
            case PowerUps.Unstopable:
                // Remove GameOver on Obstacle Collision
                playerMovement.isUnstoppable = true;

                // lighten Obstacles
                GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach (GameObject obstacle in obstacles)
                {
                    // Ceck that obstacle has a RigidBody
                    if (obstacle.GetComponent<Rigidbody>())
                    {
                        // Store original mass
                        if (originalObstacleMass < 0f)
                            originalObstacleMass = obstacle.GetComponent<Rigidbody>().mass;
                        // Reduce mass of Obstacle
                        obstacle.GetComponent<Rigidbody>().mass = reducedObstacleMass;
                    }
                }

                // PowerUp UI notification
                infoUI.text = "Unstoppable";

                // Hide PowerUp from scene
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;

                // Duration wait (coroutine)
                yield return new WaitForSeconds(duration);

                // PowerUp Reverse 
                playerMovement.isUnstoppable = false;

                // reset Obstacles mass
                foreach (GameObject obstacle in obstacles)
                {
                    if (obstacle.GetComponent<Rigidbody>())
                        obstacle.GetComponent<Rigidbody>().mass =originalObstacleMass;
                }

                // PowerUp UI notification
                infoUI.text = "";
                break;
            case PowerUps.SlowMode:
                // PowerUp change
                playerMovement.forwardSpeedMultiplicator = speedMultiplier;
                // PowerUp UI notification
                infoUI.text = "Slower";
                // Hide PowerUp from scene
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                // Duration wait (coroutine)
                yield return new WaitForSeconds(duration);
                // PowerUp Reverse 
                playerMovement.forwardSpeedMultiplicator = playerMovement.defaultForwardSpeedMultiplicator;
                // PowerUp UI notification
                infoUI.text = "";
                break;
            case PowerUps.SizeDown:
                // PowerUp change
                player.transform.localScale *= sizeMultiplier;
                // PowerUp UI notification
                infoUI.text = "Smaller";
                // Hide PowerUp from scene
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
                // Duration wait (coroutine)
                yield return new WaitForSeconds(duration);
                // PowerUp Reverse 
                player.transform.localScale /= sizeMultiplier;
                // PowerUp UI notification
                infoUI.text = "";
                break;
            default:
                Debug.LogError("Couldn't find PowerUp - Switch default");
                break;
        }

        // Destroy current PowerUp
        Destroy(gameObject);
    }

    int PowerUpLottery()
    {
        return UnityEngine.Random.Range(1, Enum.GetNames(typeof(PowerUps)).Length+1);
    }
}
