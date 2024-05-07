using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private LevelPackKuis _dataSoal;
    [SerializeField] private PlayerProgress _progress;
    [SerializeField] private UIPertanyaan _tempatPertanyaan;
    [SerializeField] private UIPoinJawaban[] _tempatJawaban = new UIPoinJawaban[0];

    private int _indexSoal = -1;

    private void Start()
    {
        if(!_progress.MuatProgres())
        {
            _progress.SimpanProgres();
        }
        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;
        if (_indexSoal >= _dataSoal.BanyakLevel)
        {
            _indexSoal = 0;
        }


        // ambil data pertanyaan
        LevelSoalKuis soal = _dataSoal.ambilLevel(_indexSoal);

        // set informasi pertanyaan
        _tempatPertanyaan.SetPertanyaan(soal.pertanyaan, soal.hint, _indexSoal+1);

        // ambil data jawaban
        for (int i = 0; i < soal.opsiJawaban.Length; i++)
        {
            _tempatJawaban[i].SetJawaban(soal.opsiJawaban[i].teksJawaban, soal.opsiJawaban[i].adalahBenar);
        }

    }
}
