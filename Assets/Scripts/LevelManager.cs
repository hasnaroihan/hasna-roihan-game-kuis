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
    [SerializeField] private Animator _animator;

    [Space, SerializeField] private AudioClip[] _answerSFX = new AudioClip[0];
    

    private int _indexSoal = -1;
    private LevelPackKuis _dataSoal;

    private void Start()
    {
        //if(!_progress.MuatProgres())
        //{
        //    _progress.SimpanProgres();
        //}
        UIPoinJawaban.OnClickEvent += OnClickAnswer;

        _dataSoal = _gameplayObject.levelPack;
        _indexSoal = _gameplayObject.indexLevel - 1;
        NextLevel();
    }

    private void OnApplicationQuit()
    {
        _gameplayObject.Reset();
    }

    private void OnDestroy()
    {
        UIPoinJawaban.OnClickEvent -= OnClickAnswer;
    }

    public void NextLevel()
    {
        if (_indexSoal >= _dataSoal.BanyakLevel - 1)
        {
            _indexSoal = 0;
            //_progress.progresData.koin += 20;
            _gameSceneManager.OpenScene("LevelMenu");
            
            return;
        }
        _indexSoal++;
        // ambil data pertanyaan
        LevelSoalKuis soal = _dataSoal.ambilLevel(_indexSoal);

        // set informasi pertanyaan
        _tempatPertanyaan.SetPertanyaan(soal.pertanyaan, soal.hint, _indexSoal+1);

        // ambil data jawaban
        for (int i = 0; i < soal.opsiJawaban.Length; i++)
        {
            _tempatJawaban[i].SetJawaban(soal.opsiJawaban[i].teksJawaban, soal.opsiJawaban[i].adalahBenar);
        }

        _gameplayObject.indexLevel = _progress.progresData.progresLevel[_gameplayObject.levelPack.name];

        Debug.Log($"Index soal: {_indexSoal}");
        Debug.Log($"Progress terakhir player: {_progress.progresData.progresLevel[_gameplayObject.levelPack.name]}");

    }

    public void OnClickAnswer(string answer, bool isTrue)
    {
        if (!isTrue)
        {
            AudioManager.instance.PlaySFX(_answerSFX[0]);
            _animator.SetTrigger("OnLose");
            return;
        }

        AudioManager.instance.PlaySFX(_answerSFX[1]);
        _animator.SetTrigger("OnWin");
        if (_indexSoal >= _progress.progresData.progresLevel[_gameplayObject.levelPack.name])
        {
            _progress.progresData.koin += 5;
            _progress.progresData.progresLevel[_gameplayObject.levelPack.name] = _indexSoal + 1;
        }
        
        _progress.SimpanProgres();
    }
}
