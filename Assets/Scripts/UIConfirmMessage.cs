using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIConfirmMessage : MonoBehaviour
{
    [SerializeField] private PlayerProgress _playerProgress;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private GameObject _sufficientCoinMessage;
    [SerializeField] private GameObject _insufficientCoinMessage;
    [SerializeField] private Button _buyButton;

    public static event System.Action<LevelPackKuis> OnBuyClickEvent;
    private LevelPackKuis _selectedLevelPack;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        UILevelPackOption.OnClickEvent += OnClick;
        _buyButton.onClick.AddListener(OnBuyLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        UILevelPackOption.OnClickEvent -= OnClick;
        _buyButton.onClick.RemoveAllListeners();
    }

    private void OnClick(LevelPackKuis levelPack, bool locked, int idxProgress = 0)
    {
        if (!locked) return;

        gameObject.SetActive(true);
        _selectedLevelPack = levelPack;

        if(_playerProgress.progresData.koin < levelPack.Harga)
        {
            _messageText.text = "Koin yang Anda miliki tidak cukup";
            _sufficientCoinMessage.SetActive(false);
            _insufficientCoinMessage.SetActive(true);
        } else
        {
            _messageText.text = $"Apakah Anda yakin mau membeli {levelPack.name}?";
            _sufficientCoinMessage.SetActive(true);
            _insufficientCoinMessage.SetActive(false);
        }
    }

    private void OnBuyLevel()
    {
        if (_selectedLevelPack != null)
        {
            OnBuyClickEvent?.Invoke(_selectedLevelPack);
        };
        
    }
}
