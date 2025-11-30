using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private string sceneName; 

    public void OnLoadSceneButtonClicked()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("ไป Scene: " + sceneName);
        }
        else
        {
            Debug.LogError("ยังไม่ได้ตั้งชื่อ Scene!");
        }
    }
}
