using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPoinJawaban : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teksJawaban;
    [SerializeField] private bool _adalahBenar = false;
    [SerializeField] private UIPesanLevel _tempatPesan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PilihJawaban()
    {
        //Debug.Log($"Jawaban yang dipilih: {_teksJawaban.text} ({_adalahBenar})");
        _tempatPesan.Pesan = $"Jawaban yang dipilih: {_teksJawaban.text} ({_adalahBenar})";
    }

    public void SetJawaban(string teksJawaban, bool adalahBenar)
    {
        _teksJawaban.text = teksJawaban;
        _adalahBenar = adalahBenar;
    }
}
