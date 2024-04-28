using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private int _waktuJawab = 30;
    [SerializeField] private Slider _timeBar;
    [SerializeField] private UIPesanLevel _tempatPesan;

    private float _sisaWaktu = 0;
    private bool _waktuBerjalan = false;

    public bool WaktuBerjalan
    {
        get
        {
            return _waktuBerjalan;
        }
        set
        {
            _waktuBerjalan = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UlangiWaktu();
        this.WaktuBerjalan = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_waktuBerjalan)
        {
            return;
        }
        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu / _waktuJawab;

        if (_sisaWaktu <= 0f)
        {
            Debug.Log("Waktu Habis");
            _waktuBerjalan = false;
            _tempatPesan.Pesan = "Waktu Habis";
            _tempatPesan.gameObject.SetActive(true);
            return;
        }

        Debug.Log(_sisaWaktu);
    }

    public void UlangiWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }
}
