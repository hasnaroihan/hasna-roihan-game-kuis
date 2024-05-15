using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UILevelPackOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLabel;
    [SerializeField] private LevelPackKuis _levelPackKuis;
    [SerializeField] private Button _button;
    //[SerializeField] private InitGameplayObject _initGameplayObject;
    // Start is called before the first frame update
    void Start()
    {
        if (_levelPackKuis)
        {
            SetLevelPack(_levelPackKuis);
        }
        _button.onClick.AddListener(OnClick);
    }

    public void SetLevelPack(LevelPackKuis levelPack)
    {
        _textLabel.text = levelPack.name;
        _levelPackKuis = levelPack;
    }

    public void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    public static event System.Action<LevelPackKuis> OnClickEvent;

    public void OnClick()
    {
        OnClickEvent?.Invoke(_levelPackKuis);
    }
}
