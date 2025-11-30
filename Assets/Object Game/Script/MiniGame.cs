using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private RectTransform fishIndicator;
    [SerializeField] private RectTransform catchZone;

    [SerializeField] private float gravity = 1500f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float topLimit = 200f;
    [SerializeField] private float bottomLimit = -200f;

    [SerializeField] private float catchZoneSpeed = 5f;
    [SerializeField] private float catchZoneAmplitude = 300f;
    [Range(0f, 125f)]
    [SerializeField] private float catchTolerance = 100f;

    private float velocityY = 0f;
    private Cat playerCat;
    private Fish currentFish;
    private bool isActive = false;
    private bool isInsideZone = false;
    private float initialCatchZoneY;

    [Header("Animation & Effect")]
    [SerializeField] private Animator catchAnimator;
    [SerializeField] private GameObject catchEffectPrefab;
    [SerializeField] private Transform effectSpawnPoint;

    public void StartMiniGame(Fish fish, Cat cat)
    {
        currentFish = fish;
        playerCat = cat;
        isActive = true;
        velocityY = 0f;

        miniGameUI.SetActive(true);
        fishIndicator.anchoredPosition = new Vector2(0, bottomLimit);
        initialCatchZoneY = catchZone.anchoredPosition.y;
    }

    private void Update()
    {
        if (!isActive) return;

        if (Input.GetMouseButtonDown(0)) velocityY = jumpForce;
        velocityY -= gravity * Time.deltaTime;
        fishIndicator.anchoredPosition += new Vector2(0, velocityY * Time.deltaTime);

        float currentY = Mathf.Clamp(fishIndicator.anchoredPosition.y, bottomLimit, topLimit);
        fishIndicator.anchoredPosition = new Vector2(0, currentY);

        float newCatchZoneY = initialCatchZoneY + Mathf.Sin(Time.time * catchZoneSpeed) * catchZoneAmplitude;
        catchZone.anchoredPosition = new Vector2(0, newCatchZoneY);

        float indicatorY = fishIndicator.anchoredPosition.y;
        float catchZoneY = catchZone.anchoredPosition.y;
        float zoneHalfHeight = catchZone.rect.height / 2f;

        float zoneTop = catchZoneY + zoneHalfHeight + catchTolerance;
        float zoneBottom = catchZoneY - zoneHalfHeight - catchTolerance;

        isInsideZone = indicatorY >= zoneBottom && indicatorY <= zoneTop;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInsideZone) WinMiniGame();
            else LoseMiniGame();
        }
    }

    private void WinMiniGame()
    {
        isActive = false;
        miniGameUI.SetActive(false);

        if (playerCat != null && currentFish != null)
        {
            playerCat.CatchFish(currentFish);
        }

        if (catchAnimator != null) catchAnimator.SetTrigger("Play");
        if (catchEffectPrefab != null && effectSpawnPoint != null)
            Instantiate(catchEffectPrefab, effectSpawnPoint.position, Quaternion.identity);

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
