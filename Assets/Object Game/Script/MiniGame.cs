using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public GameObject miniGameUI;       // Panel UI
    public RectTransform fishIndicator; // ตัวชี้ปลา
    public RectTransform catchZone;     // โซนจับปลา
    public float gravity = 300f;        // แรงโน้มถ่วง
    public float jumpForce = 150f;      // ความเร็วเมื่อคลิก
    private float velocityY = 0f;

    public float catchZoneSpeed = 50f;  // ความเร็ว CatchZone
    public float catchZoneRange = 150f; // ขอบเขตที่ CatchZone เดิน

    private Cat playerCat;
    private Fish currentFish;
    private bool isActive = false;
    private float catchZoneDirection = 1f; // 1 = ขึ้น, -1 = ลง

    public void StartMiniGame(Fish fish, Cat cat)
    {
        currentFish = fish;
        playerCat = cat;
        isActive = true;
        velocityY = 0f;

        miniGameUI.SetActive(true);
        fishIndicator.anchoredPosition = new Vector2(0, 0);

        Debug.Log("Mini-game started! Keep the fish in the moving green zone!");
    }

    private void Update()
    {
        if (!isActive) return;

        // FishIndicator คลิกเมาส์เพื่อกระโดด
        if (Input.GetMouseButtonDown(0)) velocityY = jumpForce;

        // Gravity
        velocityY -= gravity * Time.deltaTime;
        fishIndicator.anchoredPosition += new Vector2(0, velocityY * Time.deltaTime);

        // ขอบบน-ล่าง FishIndicator
        float topLimit = 200f;
        float bottomLimit = -200f;
        if (fishIndicator.anchoredPosition.y > topLimit) fishIndicator.anchoredPosition = new Vector2(0, topLimit);
        if (fishIndicator.anchoredPosition.y < bottomLimit) fishIndicator.anchoredPosition = new Vector2(0, bottomLimit);

        // ขยับ CatchZone ขึ้นลง
        catchZone.anchoredPosition += new Vector2(0, catchZoneSpeed * catchZoneDirection * Time.deltaTime);
        if (catchZone.anchoredPosition.y > catchZoneRange) catchZoneDirection = -1f;
        if (catchZone.anchoredPosition.y < -catchZoneRange) catchZoneDirection = 1f;

        // ตรวจสอบว่าปลาติดใน catchZone
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fishIndicator.anchoredPosition.y >= catchZone.anchoredPosition.y - catchZone.sizeDelta.y / 2 &&
                fishIndicator.anchoredPosition.y <= catchZone.anchoredPosition.y + catchZone.sizeDelta.y / 2)
            {
                WinMiniGame();
            }
            else
            {
                LoseMiniGame();
            }
        }
    }

    void WinMiniGame()
    {
        isActive = false;
        playerCat.CatchFish(currentFish);
        miniGameUI.SetActive(false);
        Debug.Log("สำเร็จ! คุณจับปลาได้แล้ว!");
    }

    void LoseMiniGame()
    {
        isActive = false;
        Destroy(currentFish.gameObject);
        miniGameUI.SetActive(false);
        Debug.Log("ล้มเหลว! ปลาหลุด!");
    }
}
