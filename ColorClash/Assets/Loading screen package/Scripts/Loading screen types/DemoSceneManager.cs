using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoSceneManager : MonoBehaviour
{
    private bool _canCheckForInput = false;
    private LoadingScreenManager _loadingManager;

    private void Start()
    {
        _loadingManager = transform.GetComponentInChildren<LoadingScreenManager>();
    }

    private void Update()
    {
        //if (_canCheckForInput)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        _canCheckForInput = false;
        //        _loadingManager.RevealLoadingScreen();
        //    }
        //}
        _loadingManager.RevealLoadingScreen();
    }

    public void OnLoadingScreenRevealed()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelUnlocked",1));
    }

    public void OnLoadingScreenHided()
    {
        _canCheckForInput = true;
    }
}
