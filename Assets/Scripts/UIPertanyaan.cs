using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPertanyaan : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pertanyaanKuis;
    [SerializeField] private TextMeshProUGUI _labelLevel;
    [SerializeField] private Image _hint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPertanyaan(string teksPertanyaan, Sprite hint, int level)
    {
        _pertanyaanKuis.text = teksPertanyaan;
        _hint.sprite = hint;
        _labelLevel.text = $"Level {level}";
    }
}
