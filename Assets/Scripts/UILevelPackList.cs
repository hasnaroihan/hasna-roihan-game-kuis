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
    [SerializeField] private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        //LoadLevelPack();
        if (_initGameplayObject.onLosing)
        {
            LevelPackButtonOnClick(_initGameplayObject.levelPack, false, _initGameplayObject.indexLevel);
        }
        UILevelPackOption.OnClickEvent += LevelPackButtonOnClick;
    }

    private void OnApplicationQuit()
    {
        _initGameplayObject.Reset();
    }

    public void LoadLevelPack(LevelPackKuis[] levelPackKuis, PlayerProgress.MainData playerData)
    {
        Debug.Log("Loading level pack...");
        foreach(var levelPack in levelPackKuis)
        {
            var t = Instantiate(_levelPackOption, _content);
            

            if(!playerData.progresLevel.ContainsKey(levelPack.name))
            {
                t.SetLevelPack(levelPack, 0);
                t.Lock();
            } else
            {
                t.SetLevelPack(levelPack, playerData.progresLevel[levelPack.name]);
            }
        }
    }

    private void OnDestroy()
    {
        UILevelPackOption.OnClickEvent -= LevelPackButtonOnClick;
    }

    private void LevelPackButtonOnClick(LevelPackKuis levelPack, bool locked, int idxProgress)
    {
        if (locked) return;

        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack, idxProgress);

        gameObject.SetActive(false);
        _headerLevelPack.gameObject.SetActive(false);
        _headerLevel.gameObject.SetActive(true);

        _initGameplayObject.levelPack = levelPack;
        _animator.SetTrigger("ToLevelList");
    }

    public void RemoveChildren()
    {
        int count = _content.childCount;

        for (int i = 0; i < count; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
