using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    public float masterVolume = 1f;

    private void Awake()
    {
        // เช็คว่ามี Instance อยู่หรือยัง
        if (Instance == null)
        {
            Instance = this;

            // ทำให้ GameObject นี้ไม่ถูกลบเวลาเปลี่ยน Scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ถ้ามี Instance ซ้ำ → ลบตัวนี้ทิ้ง
            Destroy(gameObject);
        }
    }
}
