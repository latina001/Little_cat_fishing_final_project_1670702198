using UnityEngine;

public class BoundaryRemover : MonoBehaviour
{
    
    public MiniGame miniGameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Fish"))
        {
            if (miniGameManager != null)
            {
               

                Destroy(other.gameObject);

               
                miniGameManager.LoseMiniGame();
            }
        }
    }
}