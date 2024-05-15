using UnityEngine;

[CreateAssetMenu(
    fileName = "Gameplay Initial Data",
    menuName ="Game Kuis/Init Data")]
public class InitGameplayObject : ScriptableObject
{
    [SerializeField] public LevelPackKuis levelPack = null;
    [SerializeField] public int indexLevel = 0;
    [SerializeField] private bool _onLosing;

    public bool onLosing
    {
        get => _onLosing;
        set => _onLosing = value;
    }

    public void Reset()
    {
        levelPack = null;
        indexLevel = 0;
        onLosing = false;
    }
}
