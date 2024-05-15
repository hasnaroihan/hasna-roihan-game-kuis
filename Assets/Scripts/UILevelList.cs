using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelList : MonoBehaviour
{
    [SerializeField] private UILevelOption _levelOption;
    [SerializeField] private RectTransform _content;
    [SerializeField] private GameSceneManager _gameSceneManager;
    [SerializeField] private string _gameplayScene = string.Empty;
    [SerializeField] private InitGameplayObject _initGameplayObject;

    private void Start()
    {
        UILevelOption.OnClickEvent += LevelOnClickButton;
        Debug.Log(_initGameplayObject.levelPack.name);
    }

    private void OnDestroy()
    {
        UILevelOption.OnClickEvent -= LevelOnClickButton;
    }
    public void UnloadLevelPack(LevelPackKuis pack)
    {
        for(int i = 0; i < pack.BanyakLevel; i++)
        {
            var temp = Instantiate(_levelOption, _content);
            temp.SetLevelKuis(pack.ambilLevel(i), i);
        }
    }

    public void RemoveChildren()
    {
        int count = _content.childCount;
        
        for(int i = 0; i < count; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }

    private void LevelOnClickButton(int index)
    {
        _gameSceneManager.OpenScene(_gameplayScene);
        _initGameplayObject.indexLevel = index;
    }
}
