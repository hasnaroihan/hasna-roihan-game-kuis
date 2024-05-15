using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private InitGameplayObject _gameplayObject;
    [SerializeField] private PlayerProgress _progress;
    [SerializeField] private UIPertanyaan _tempatPertanyaan;
    [SerializeField] private UIPoinJawaban[] _tempatJawaban = new UIPoinJawaban[0];

    [SerializeField] private GameSceneManager _gameSceneManager;

    private int _indexSoal = -1;
    private LevelPackKuis _dataSoal;

    private void Start()
    {
        //if(!_progress.MuatProgres())
        //{
        //    _progress.SimpanProgres();
        //}
        _dataSoal = _gameplayObject.levelPack;
        _indexSoal = _gameplayObject.indexLevel - 1;
        NextLevel();
    }

    private void OnApplicationQuit()
    {
        _gameplayObject.Reset();
    }

    public void NextLevel()
    {
        _indexSoal++;
        if (_indexSoal >= _dataSoal.BanyakLevel)
        {
            _indexSoal = 0;
            _progress.progresData.koin += 20;
            _gameSceneManager.OpenScene("LevelMenu");
            
            return;
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
