using UnityEngine;

public class Cat : MonoBehaviour
{
    public int score;
    [Tooltip("ลาก UI ที่ต้องการให้เปิดตอน Game Over ที่นี่")]
    public GameObject[] gameOverUIs;  // ใส่ UI ได้หลายตัว

    public void CatchFish(Fish fish)
    {
        score += fish.points;
        Destroy(fish.gameObject);

        if (score < 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");

        // เปิด UI ทุกตัวที่ลากเข้ามา
        foreach (GameObject ui in gameOverUIs)
        {
            if (ui != null)
                ui.SetActive(true);
        }

        // หยุดการควบคุมแมว
        this.enabled = false;
    }
}
