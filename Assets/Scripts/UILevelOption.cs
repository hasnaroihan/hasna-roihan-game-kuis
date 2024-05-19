using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelOption : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLabel;
    [SerializeField] private LevelSoalKuis _levelKuis;
    [SerializeField] private Button _button;
    [SerializeField] private bool _locked;
    //[SerializeField] private InitGameplayObject _initGameplayObject;

    public static event System.Action<int> OnClickEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (_levelKuis)
        {
            SetLevelKuis(_levelKuis, _levelKuis.index);
        }
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void SetLevelKuis(LevelSoalKuis levelSoal, int idx)
    {
        _textLabel.text = levelSoal.name;
        _levelKuis = levelSoal;

        _levelKuis.index = idx;
    }

    public void Lock()
    {
        _locked = true;
        _button.interactable = false;
    }

    private void OnClick()
    {
        if (_locked) return;
        OnClickEvent?.Invoke(_levelKuis.index);
    }
}
