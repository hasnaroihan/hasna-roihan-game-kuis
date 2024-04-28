using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Serializable]
    private struct DataSoal
    {
        public Sprite hint;
        public string pertanyaan;

        public string[] jawaban;
        public bool[] adalahBenar;
    }

    [SerializeField] private DataSoal[] _dataSoal = new DataSoal[0];
    [SerializeField] private UIPertanyaan _tempatPertanyaan;
    [SerializeField] private UIPoinJawaban[] _tempatJawaban = new UIPoinJawaban[0];

    private int _indexSoal = -1;

    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;
        if (_indexSoal >= _dataSoal.Length)
        {
            _indexSoal = 0;
        }


        // ambil data pertanyaan
        DataSoal soal = _dataSoal[_indexSoal];

        // set informasi pertanyaan
        _tempatPertanyaan.SetPertanyaan(soal.pertanyaan, soal.hint, _indexSoal+1);

        // ambil data jawaban
        for (int i = 0; i < soal.jawaban.Length; i++)
        {
            _tempatJawaban[i].SetJawaban(soal.jawaban[i], soal.adalahBenar[i]);
        }

    }
}
