using UnityEngine;

public class MiniGame : MonoBehaviour
{
    
    public GameObject miniGameUI;
    public RectTransform fishIndicator;
    public RectTransform catchZone;

    
    public float gravity =1500f;
    public float jumpForce =400f;
    public float topLimit = 200f;
    public float bottomLimit = -200f;

  
    public float catchZoneSpeed = 5f;    
    public float catchZoneAmplitude = 300f; 

    [Range(0f, 125f)]
    public float catchTolerance = 100f; 

    private float velocityY = 0f;
    private Cat playerCat;
    private Fish currentFish;
    private bool isActive = false;
    private bool isInsideZone = false;

    private float initialCatchZoneY; 

    

    public void StartMiniGame(Fish fish, Cat cat)
    {
        currentFish = fish;
        playerCat = cat;

        isActive = true;
        velocityY = 0f;

        miniGameUI.SetActive(true);

        // กำหนดให้ตัวชี้ปลาเริ่มที่ขีดจำกัดล่างสุด
        fishIndicator.anchoredPosition = new Vector2(0, bottomLimit);

        
        initialCatchZoneY = catchZone.anchoredPosition.y;
    }

    private void Update()
    {
        if (!isActive) return;

        
        if (Input.GetMouseButtonDown(0))
        {
            velocityY = jumpForce;
        }

        velocityY -= gravity * Time.deltaTime;
        fishIndicator.anchoredPosition += new Vector2(0, velocityY * Time.deltaTime);

       
        float currentY = fishIndicator.anchoredPosition.y;
        currentY = Mathf.Clamp(currentY, bottomLimit, topLimit);
        fishIndicator.anchoredPosition = new Vector2(0, currentY);

        
        float newCatchZoneY = initialCatchZoneY + Mathf.Sin(Time.time * catchZoneSpeed) * catchZoneAmplitude;
        catchZone.anchoredPosition = new Vector2(0, newCatchZoneY);


        
        float indicatorY = fishIndicator.anchoredPosition.y;

        
        float catchZoneY = catchZone.anchoredPosition.y;

        
        float zoneHalfHeight = catchZone.rect.height / 2f;

        
        float zoneTop = catchZoneY + zoneHalfHeight + catchTolerance;
        float zoneBottom = catchZoneY - zoneHalfHeight - catchTolerance;

        
        if (indicatorY >= zoneBottom && indicatorY <= zoneTop)
        {
            isInsideZone = true;
        }
        else
        {
            isInsideZone = false;
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInsideZone)
                WinMiniGame();
            else
                LoseMiniGame();
        }
    }

    
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

    
    public void LoseMiniGame() 
    {
        isActive = false;
        miniGameUI.SetActive(false);

        currentFish = null;

        Debug.Log("Failed! The fish escaped!");
    }
}