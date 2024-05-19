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

    [SerializeField] private bool _locked;
    [SerializeField] private int _indexProgress = 0;
    [SerializeField] private TextMeshProUGUI _lockText;
    [SerializeField] private TextMeshProUGUI _priceText;

    public static event System.Action<LevelPackKuis, bool, int> OnClickEvent;

    //[SerializeField] private InitGameplayObject _initGameplayObject;
    // Start is called before the first frame update
    void Start()
    {
        if (_levelPackKuis)
        {
            SetLevelPack(_levelPackKuis, _indexProgress);
        }
        _button.onClick.AddListener(OnClick);
    }

    public void SetLevelPack(LevelPackKuis levelPack, int idxProgress)
    {
        _textLabel.text = levelPack.name;
        _levelPackKuis = levelPack;
        _indexProgress = idxProgress;
    }

    public void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void OnClick()
    {
        OnClickEvent?.Invoke(_levelPackKuis, _locked, _indexProgress);
    }

    public void Lock()
    {
        _locked = true;
        _priceText.transform.parent.gameObject.SetActive(true);
        _lockText.transform.parent.gameObject.SetActive(true);
        _priceText.text = $"{_levelPackKuis.Harga}";
    }

    public void Unlock()
    {
        _locked = false;
        _priceText.transform.parent.gameObject.SetActive(false);
        _lockText.transform.parent.gameObject.SetActive(false);
    }
}
