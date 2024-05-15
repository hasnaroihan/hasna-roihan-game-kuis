using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu (
    fileName = "Soal Baru",
    menuName =  "Game Kuis/Level Soal Kuis")]
public class LevelSoalKuis : ScriptableObject
{
    [System.Serializable]
    public struct OpsiJawaban
    {
        public string teksJawaban;
        public bool adalahBenar;
    }
    public Sprite hint;
    public string pertanyaan;
    public int index;

    public OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];
}
