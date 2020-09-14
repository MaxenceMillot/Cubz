using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider collider)
    {
        // Level win if player hit end zone AND game is not over
        if(collider.gameObject.name == "Player" && !gameManager.isGameOver)
            gameManager.GameWin();     
    }
}
