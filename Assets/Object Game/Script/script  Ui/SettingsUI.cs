using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider volumeSlider;
   

    private void Start()
    {
        
        volumeSlider.value = GameSettings.Instance.masterVolume;
       

        volumeSlider.onValueChanged.AddListener((v) => GameSettings.Instance.masterVolume = v);
       
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
