using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPoinJawaban : MonoBehaviour
{
    public static event System.Action<string, bool> OnClickEvent;

    [SerializeField] private TextMeshProUGUI _teksJawaban;
    [SerializeField] private bool _adalahBenar = false;

    public void PilihJawaban()
    {
        OnClickEvent?.Invoke(_teksJawaban.text, _adalahBenar);
    }

    private void OnDestroy()
    {
      
    }

    public void SetJawaban(string teksJawaban, bool adalahBenar)
    {
        _teksJawaban.text = teksJawaban;
        _adalahBenar = adalahBenar;
    }
}
