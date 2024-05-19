using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerProgress _p;

    private void Start()
    {
        
    }
    public void OpenScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        if (sceneName == "Gameplay")
        {
            AudioManager.instance.PlayBGM(1);
        } else
        {
            AudioManager.instance.PlayBGM(0);
        }
    }
}
