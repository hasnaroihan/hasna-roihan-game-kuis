using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPesanLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tempatPesan;
    [SerializeField] private GameObject _winButtons;
    [SerializeField] private GameObject _loseButtons;

    private void Awake()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }

        UITimer.TimesUpEvent += OnTimesUp;
        UIPoinJawaban.OnClickEvent += OnClickAnswer;
    }

    private void OnDestroy()
    {
        UITimer.TimesUpEvent -= OnTimesUp;
        UIPoinJawaban.OnClickEvent -= OnClickAnswer;
    }

    public string Pesan
    {
        get => _tempatPesan.text;
        set => _tempatPesan.text = value;
    }

    private void OnTimesUp()
    {
        Pesan = "Waktu habis";
        gameObject.SetActive(true);

        _winButtons.SetActive(false);
        _loseButtons.SetActive(true);
    }

    private void OnClickAnswer(string text, bool flag)
    {
        Pesan = $"Jawaban yang dipilih: {text} ({flag})";
        gameObject.SetActive(true);

        if (flag)
        {
            _winButtons.SetActive(true);
            _loseButtons.SetActive(false);
        } else
        {
            _winButtons.SetActive(false);
            _loseButtons.SetActive(true);
        }
    }
}
