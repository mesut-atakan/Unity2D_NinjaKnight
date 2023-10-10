using UnityEngine;
using UnityEngine.SceneManagement;


internal class UIManager : MonoBehaviour
{
    




    public void LoadSceneManager(string sceneName)
    {
        if (sceneName != "")
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"");
        }
    }
}