using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Music[] musics;
    public static MusicManager instance;

    public float s;
    public Slider Sens_Slider;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Music m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
        }
    }

    public void Play(string name)
    {
        Music m = Array.Find(musics, music => music.name == name);
        if (m == null) { Debug.LogWarning("Music: " + name + " not found"); return; }
        m.source.Play();
    }

    public void Changed(Slider volume_music)
    {
        foreach (Music m in musics)
        {
            m.source.volume = volume_music.value;
        }

    }

    public void Stop(string name)
    {
        Music m = Array.Find(musics, music => music.name == name);
        if (m == null) { Debug.LogWarning("Sound: " + name + " not found"); return; }
        m.source.Stop();
    }

    public void SenseChenged()
    {
        s = Sens_Slider.value;
    }
}
