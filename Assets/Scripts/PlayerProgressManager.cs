using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgressManager : MonoBehaviour
{
    [SerializeField] private PlayerProgress _playerProgress;
    [SerializeField] private TextMeshProUGUI _coinText;

    private void Start()
    {
        if (_playerProgress)
        {
            SetUIPlayerProgress();
        }
    }

    private void SetUIPlayerProgress()
    {
        _coinText.text = _playerProgress.progresData.koin.ToString();
    }
}
