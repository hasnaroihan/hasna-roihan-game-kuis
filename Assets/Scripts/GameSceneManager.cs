using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private PlayerProgress _p;

    private void Start()
    {
        //if (_p)
        //{
        //    Debug.Log(_p.progresData.koin);
        //}
    }
    public void OpenScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
