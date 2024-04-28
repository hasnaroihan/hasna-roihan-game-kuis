using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPesanLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tempatPesan;

    private void Awake()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
    
    public string Pesan
    {
        get => _tempatPesan.text;
        set => _tempatPesan.text = value;
    }
}
