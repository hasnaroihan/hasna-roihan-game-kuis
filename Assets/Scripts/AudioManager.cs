using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource _bgmPrefab;
    [SerializeField] private AudioClip[] _bgmClips = new AudioClip[0];


    [SerializeField] private AudioSource _sfxPrefab;

    private AudioSource _bgm;
    private AudioSource _sfx;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);

        _bgm = Instantiate(_bgmPrefab);
        DontDestroyOnLoad(_bgm);

        _sfx = Instantiate(_sfxPrefab);
        DontDestroyOnLoad(_sfx);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (this.Equals(instance))
        {
            instance = null;

            if (_bgm != null)
            {
                Destroy(_bgm.gameObject);
            }
        }
    }

    public void PlayBGM(int idx)
    {
        if (_bgm.clip == _bgmClips[idx])
        {
            return;
        }
        _bgm.clip = _bgmClips[idx];
        _bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfx.PlayOneShot(clip);
    }
}
