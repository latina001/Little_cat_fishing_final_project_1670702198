using UnityEngine;

public class MiniGame : MonoBehaviour
{
    // ตัวแปรที่ต้องลากใส่ใน Inspector
    public GameObject miniGameUI;
    public RectTransform fishIndicator;
    public RectTransform catchZone;

    // ตัวแปรการเคลื่อนที่และการจำกัดขอบเขต
    public float gravity = 300f;
    public float jumpForce = 150f;
    public float topLimit = 200f;
    public float bottomLimit = -200f;

    // ตัวแปรใหม่สำหรับการเคลื่อนที่ของ CatchZone
    public float catchZoneSpeed = 1f;    // ความเร็วในการขยับ
    public float catchZoneAmplitude = 100f; // ระยะขยับสูงสุด

    [Range(0f, 50f)]
    public float catchTolerance = 15f;  // ค่าเผื่อในการจับปลา

    private float velocityY = 0f;
    private Cat playerCat;
    private Fish currentFish;
    private bool isActive = false;
    private bool isInsideZone = false;

    private float initialCatchZoneY; // ตำแหน่ง Y เริ่มต้นของ CatchZone

    // -------------------------------------------------------------------

    public void StartMiniGame(Fish fish, Cat cat)
    {
        currentFish = fish;
        playerCat = cat;

        isActive = true;
        velocityY = 0f;

        miniGameUI.SetActive(true);

        // กำหนดให้ตัวชี้ปลาเริ่มที่ขีดจำกัดล่างสุด
        fishIndicator.anchoredPosition = new Vector2(0, bottomLimit);

        // บันทึกตำแหน่ง Y เริ่มต้นของ CatchZone
        initialCatchZoneY = catchZone.anchoredPosition.y;
    }

    private void Update()
    {
        if (!isActive) return;

        // 1. การควบคุมและการเคลื่อนที่ของ FishIndicator
        if (Input.GetMouseButtonDown(0))
        {
            velocityY = jumpForce;
        }

        velocityY -= gravity * Time.deltaTime;
        fishIndicator.anchoredPosition += new Vector2(0, velocityY * Time.deltaTime);

        // 2. จำกัดขอบแถบของ FishIndicator
        float currentY = fishIndicator.anchoredPosition.y;
        currentY = Mathf.Clamp(currentY, bottomLimit, topLimit);
        fishIndicator.anchoredPosition = new Vector2(0, currentY);

        // 2.5 Logic การเคลื่อนที่ของ CatchZone (ใช้ Sine Wave)
        float newCatchZoneY = initialCatchZoneY + Mathf.Sin(Time.time * catchZoneSpeed) * catchZoneAmplitude;
        catchZone.anchoredPosition = new Vector2(0, newCatchZoneY);


        // 3. การตรวจสอบการทับซ้อน (ใช้ตำแหน่งใหม่ที่เคลื่อนที่แล้ว)
        float indicatorY = fishIndicator.anchoredPosition.y;

        // ดึงตำแหน่งแกน Y ที่เคลื่อนที่แล้วของ CatchZone
        float catchZoneY = catchZone.anchoredPosition.y;

        // คำนวณความสูงครึ่งหนึ่ง
        float zoneHalfHeight = catchZone.rect.height / 2f;

        // คำนวณขอบเขตโซนจับปลาที่รวมค่าเผื่อ
        float zoneTop = catchZoneY + zoneHalfHeight + catchTolerance;
        float zoneBottom = catchZoneY - zoneHalfHeight - catchTolerance;

        // ตรวจสอบเงื่อนไข
        if (indicatorY >= zoneBottom && indicatorY <= zoneTop)
        {
            isInsideZone = true;
        }
        else
        {
            isInsideZone = false;
        }

        // 4. เช็คว่ากด Space เพื่อตัดสินใจจับ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInsideZone)
                WinMiniGame();
            else
                LoseMiniGame();
        }
    }

    // -------------------------------------------------------------------

    void WinMiniGame()
    {
        isActive = false;
        miniGameUI.SetActive(false);

        if (playerCat != null && currentFish != null)
        {
            playerCat.CatchFish(currentFish);
        }

        Debug.Log("Success! You caught the fish!");
    }

    void LoseMiniGame()
    {
        isActive = false;
        miniGameUI.SetActive(false);

        if (currentFish != null)
        {
            Destroy(currentFish.gameObject);
        }

        Debug.Log("Failed! The fish escaped!");
    }
}