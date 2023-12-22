using System;
using System.IO;
using UnityEngine;

[Serializable]
public enum KeyNameData
{
    PlayerGroup
}


[Serializable]
class GlobalSave
{  
    public SettingsDataSave SettingsDataSave;
    public int CountOpenLevel;
    public GlobalSave(SettingsDataSave settingsDataSave, int countOpenLevel)
    {      
        SettingsDataSave = settingsDataSave;
        CountOpenLevel = countOpenLevel;
    }
}

[Serializable]
class  SettingsDataSave
{
    public float MasterVolume;
    public float MusicVolume;
    public float EffectVolume;
    public float EffectUIVolume;

    public Vector2Int ScreenResolution;

    public int QualityIndex;

    public float GetValueVolumeSound(NamePropertiesSoundVolume name)
    {
        switch (name)
        {
            case NamePropertiesSoundVolume.Master: return MasterVolume;
            case NamePropertiesSoundVolume.Music: return MusicVolume;
            case NamePropertiesSoundVolume.Effect: return EffectVolume;
            case NamePropertiesSoundVolume.EffectUI: return EffectUIVolume;
        }
        return 0f;
    }
    public void SetValueVolume(NamePropertiesSoundVolume name, float value)
    {
        switch (name)
        {
            case NamePropertiesSoundVolume.Master: MasterVolume = value; break;
            case NamePropertiesSoundVolume.Music: MusicVolume = value; break;
            case NamePropertiesSoundVolume.Effect: EffectVolume = value; break;
            case NamePropertiesSoundVolume.EffectUI: EffectUIVolume = value; break;
        }
    }
}

[Serializable]
public class SavedData
{    
    public SavedData() { }
    public SavedData(string TODO)
    {
        
    }
}

public class SaveManager : SingletonBase<SaveManager>
{    
    [SerializeField] private VolumeSettings _defaultSetting;
       
    private const string GlobalSaveName = "GlobalSave";

    private GlobalSave _globalSave;
    //private static SavedData _save;
    //public static SavedData Save { get => _save; set => _save = value; }
    internal GlobalSave GlobalSave { get => _globalSave;private set => _globalSave = value; }

    protected override void Awake()
    {
        base.Awake();

        if (Directory.Exists($"{Application.dataPath}/Save") == false)
        {
            Directory.CreateDirectory($"{Application.dataPath}/Save");
        }

        Saver<GlobalSave>.TryLoad(GlobalSaveName, ref _globalSave);

        if (_globalSave == null)
        {
            Debug.LogWarning($"_globalSave == null");
            SettingsDataSave settingsData = new SettingsDataSave() {

                MasterVolume = _defaultSetting.MasterVolume,
                MusicVolume = _defaultSetting.MusicVolume,
                EffectVolume = _defaultSetting.EffectVolume,
                EffectUIVolume = _defaultSetting.EffectUIVolume,
                QualityIndex = QualitySettings.names.Length - 1,

                ScreenResolution = new Vector2Int(1920,1080)
            };
            
            _globalSave = new GlobalSave(settingsData,0);
        }
    }
    private void Update()
    {
        //TEST
        if(Input.GetKeyDown(KeyCode.F5))
        {           
            SaveGlabalData();
        }
    }
    private void OnDestroy()
    {        
        SaveGlabalData();
    }
    //private void Load()
    //{
    //    var save = new SavedData();
    //    Saver<SavedData>.TryLoad(LoadName, ref save);
    //    Save = save;
    //}

    public void SaveGlabalData()
    {
        Debug.Log("SaveGlabalData()");
        Saver<GlobalSave>.Save(GlobalSaveName, _globalSave);
    }

}



