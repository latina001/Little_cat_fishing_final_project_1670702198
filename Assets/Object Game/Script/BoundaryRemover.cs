using UnityEngine;

public class BoundaryRemover : MonoBehaviour
{
    // ต้องลาก GameObject ที่มี MiniGame.cs มาใส่ใน Inspector
    public MiniGame miniGameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบ Tag ว่าเป็น "Fish" 
        if (other.CompareTag("Fish"))
        {
            if (miniGameManager != null)
            {
               

                // 2. ทำลายปลา
                Destroy(other.gameObject);

                // 3. เรียกฟังก์ชันปิดเกม
                miniGameManager.LoseMiniGame();
            }
        }
    }
}