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

    private Cat playerCat;
    private Fish currentFish;
    private bool isActive = false;

    public void StartMiniGame(Fish fish, Cat cat)
    {
        currentFish = fish;
        playerCat = cat;
        isActive = true;
        velocityY = 0f;

        miniGameUI.SetActive(true);
        fishIndicator.anchoredPosition = new Vector2(0, 0);

        Debug.Log("Mini-game started! Click to keep the fish in the green zone!");
    }

    private void Update()
    {
        if (!isActive) return;

        // ตรวจสอบคลิกเมาส์
        if (Input.GetMouseButtonDown(0)) // 0 = left click
        {
            velocityY = jumpForce;
        }

        // Update ความเร็วด้วย gravity
        velocityY -= gravity * Time.deltaTime;

        // เคลื่อน FishIndicator
        fishIndicator.anchoredPosition += new Vector2(0, velocityY * Time.deltaTime);

        // จำกัด FishIndicator ไม่ให้เกินขอบแถบ
        float topLimit = 200f;    // ปรับตามแถบ
        float bottomLimit = -200f;
        if (fishIndicator.anchoredPosition.y > topLimit) fishIndicator.anchoredPosition = new Vector2(0, topLimit);
        if (fishIndicator.anchoredPosition.y < bottomLimit) fishIndicator.anchoredPosition = new Vector2(0, bottomLimit);

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
        Debug.Log("Success! You caught the fish!");
    }

    void LoseMiniGame()
    {
        isActive = false;
        Destroy(currentFish.gameObject);
        miniGameUI.SetActive(false);
        Debug.Log("Failed! The fish escaped!");
    }
}
