using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : SingletonMonoBehaviour<SceneManagement>
{
    public string CurrentSceneName { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrentSceneName = scene.name;
        Dialogue.Instance.CreateTextBox();
        GameManager.Instance.IsClear = false;
        GameManager.Instance.OnSceneLoadedCheck();
    }

    public void LoadScene(string sceneName)
    {
        if(sceneName == "TitleScene")
            Destroy(CutSceneManager.Instance.gameObject);
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadNextScene()
    {
        CutSceneManager.Instance.UnLoadScenario();
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex == 5)
        {
            currentIndex = -1;
            Destroy(CutSceneManager.Instance.gameObject);
        }
        SceneManager.LoadScene(currentIndex + 1);
    }

    private void OnDestroy()
    {   
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
