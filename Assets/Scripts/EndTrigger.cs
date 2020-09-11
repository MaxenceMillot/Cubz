using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
            gameManager.GameWin();     
    }
}
