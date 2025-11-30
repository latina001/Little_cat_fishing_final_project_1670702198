using UnityEngine;

public class RemoveOb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       
        Destroy(other.gameObject);
    }
}