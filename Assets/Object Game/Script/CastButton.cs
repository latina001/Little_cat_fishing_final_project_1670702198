using UnityEngine;

public class CastButton : MonoBehaviour
{
    public GameManager gameManager; // Reference GameManager

    // เมื่อต้องการโยนเบ็ด ให้เรียกฟังก์ชันนี้
    public void OnCastButtonClicked()
    {
        gameManager.StartFishing();
        Debug.Log("Cast button clicked!");
    }
}
