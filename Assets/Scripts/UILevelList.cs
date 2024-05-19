using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelList : MonoBehaviour
{
    [SerializeField] private UILevelOption _levelOption;
    [SerializeField] private RectTransform _content;
    [SerializeField] private TextMeshProUGUI _headerLevelList;
    [SerializeField] private GameSceneManager _gameSceneManager;
    [SerializeField] private string _gameplayScene = string.Empty;
    [SerializeField] private InitGameplayObject _initGameplayObject;

    private void Start()
    {
        UILevelOption.OnClickEvent += LevelOnClickButton;
        if(_initGameplayObject.onLosing)
        {
            RemoveChildren();
            UnloadLevelPack(_initGameplayObject.levelPack, _initGameplayObject.indexLevel);
        }
    }

    private void OnDestroy()
    {
        UILevelOption.OnClickEvent -= LevelOnClickButton;
        RemoveChildren();
    }
    public void UnloadLevelPack(LevelPackKuis pack, int idxProgress)
    {
        _headerLevelList.text = pack.name;
        Debug.Log($"Progress {pack.name} terakhir: {idxProgress}");
        for (int i = 0; i < pack.BanyakLevel; i++)
        {
            
            Debug.Log($"Unload {pack.name} level ke-{i}...");
            var temp = Instantiate(_levelOption, _content);
            temp.SetLevelKuis(pack.ambilLevel(i), i);

            if (i > idxProgress)
            {
                temp.Lock();
            }
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
