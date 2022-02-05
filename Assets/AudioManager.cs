using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; Sound currentMusic;
    private void Awake() {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name, float delay=0){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return; 
        }
        s.source.PlayDelayed(delay);
        currentMusic = s;

        Invoke("OnSoundEnd", currentMusic.source.clip.length + delay);
    }
    public void ChangeMusicTo(string name, float delay = 0){
        currentMusic.source.Stop();
        PlaySound(name, delay);
    }

    void OnSoundEnd(){
        if (currentMusic.loop == false){
            ChangeMusicTo(currentMusic.nextMusic);
        }
    }
}
