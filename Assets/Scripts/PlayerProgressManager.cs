using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgressManager : MonoBehaviour
{
    [SerializeField] private PlayerProgress _playerProgress;
    [SerializeField] private UILevelPackList _levelPackList;
    [SerializeField] private TextMeshProUGUI _coinText;
    [Space, SerializeField] private LevelPackKuis[] _levelPackKuis;

    private void Start()
    {
        if(!_playerProgress.MuatProgres())
        {
            _playerProgress.SimpanProgres();
        }
        SetUILevelPack();

        UIConfirmMessage.OnBuyClickEvent += BuyLevel;
    }

    private void OnDestroy()
    {
        UIConfirmMessage.OnBuyClickEvent -= BuyLevel;
    }

    private void SetUILevelPack()
    {
        _levelPackList.RemoveChildren();
        _levelPackList.LoadLevelPack(_levelPackKuis, _playerProgress.progresData);
        _coinText.text = _playerProgress.progresData.koin.ToString();
    }

    public void BuyLevel(LevelPackKuis levelPack)
    {
        _playerProgress.progresData.koin -= levelPack.Harga;
        _playerProgress.progresData.progresLevel.Add(levelPack.name, 0);
        _playerProgress.SimpanProgres();
        SetUILevelPack();
    }
}
