using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelPackList : MonoBehaviour
{
    [SerializeField] UILevelPackOption _levelPackOption;
    [SerializeField] RectTransform _content;
    [SerializeField] UILevelList _levelList;
    [SerializeField] private GameObject _headerLevelPack, _headerLevel;
    [SerializeField] private InitGameplayObject _initGameplayObject;
    [Space, SerializeField] private LevelPackKuis[] _levelPackKuis;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevelPack();
        
        if (_initGameplayObject.onLosing)
        {
            LevelPackButtonOnClick(_initGameplayObject.levelPack);
        }
        UILevelPackOption.OnClickEvent += LevelPackButtonOnClick;
    }

    private void OnApplicationQuit()
    {
        _initGameplayObject.Reset();
    }

    private void LoadLevelPack()
    {
        foreach(var levelPack in _levelPackKuis)
        {
            var t = Instantiate(_levelPackOption, _content);
            t.SetLevelPack(levelPack);
        }
    }

    private void OnDestroy()
    {
        UILevelPackOption.OnClickEvent -= LevelPackButtonOnClick;
    }

    private void LevelPackButtonOnClick(LevelPackKuis levelPack)
    {
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);

        gameObject.SetActive(false);
        _headerLevelPack.gameObject.SetActive(false);
        _headerLevel.gameObject.SetActive(true);

        _initGameplayObject.levelPack = levelPack;
    }
}
