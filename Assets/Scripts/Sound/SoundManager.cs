using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    private bool isCoroutine = false;
    private bool jump = false;
    int currentMelody;
    int nextMelody;
    bool changeSoundtrack = false;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) & !jump)
        {
            FootstepsCoroutine();
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
    private void StopAllSoundtrack()
    {
        Stop("Mel1");
        Stop("Mel2");
        Stop("Mel3");
        Stop("Mel4");
    }
    public void PlayButtonSound()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "ButtonClick");
        if (s == null)
            return;
        s.source.Play();
    }
    public void PlayWalk()
    {
        string name = "Walk";
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.pitch = UnityEngine.Random.Range(0.7f, 1.3f);
        s.source.Play();
    }
    private void FootstepsCoroutine()
    {
        if (!isCoroutine)
            StartCoroutine(FootstepSound());
    }
    IEnumerator FootstepSound()
    {   
        isCoroutine = true;
        PlayWalk();
        yield return  new WaitForSeconds(0.7f);
        isCoroutine = false;
    }

    public void Jumping()
    {
        jump = true;
        Play("Jump");
    }
    public void StoppedJumping()
    {
        jump = false;
    }
    public void PlaySoundtrack(int weaponKey)
    {
        changeSoundtrack = true;
        nextMelody = weaponKey;
        StartCoroutine(VolumeFade());
    }
    public void ChangeMelody()
    {
        if (changeSoundtrack)
        {
            AudioSource source = null;
            StopAllSoundtrack();
            if (nextMelody == 1)
                source = GetSource("Mel4");
            if (nextMelody == 2)
                source = GetSource("Mel3");
            if (nextMelody == 3)
                source = GetSource("Mel1");
            if (nextMelody == 4)
                source = GetSource("Mel2");


            source.Play();
            StartCoroutine(VolumeIncrease(source)); 
            changeSoundtrack = false;
            currentMelody = nextMelody;
        }
    }
    private AudioSource GetSource(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return null;
        return s.source;
    }
    IEnumerator VolumeFade()
    {
        float timeToFade = 0.5f;
        float timeElapsed = 0;
        AudioSource currentSource = null;
        while (timeElapsed < timeToFade)
        {
            if (currentMelody == 1)
                currentSource = GetSource("Mel4");
            if (currentMelody == 2)
                currentSource = GetSource("Mel3");
            if (currentMelody == 3)
                currentSource = GetSource("Mel2");
            if (currentMelody == 4)
                currentSource = GetSource("Mel1");

            currentSource.volume = Mathf.Lerp(0, 1, timeElapsed/ timeToFade);
            timeElapsed += Time.deltaTime;  
            yield return null;
        }
    }
    IEnumerator VolumeIncrease(AudioSource source)
    {
        float timeToFade = 0.25f;
        float timeElapsed = 0;
        while (timeElapsed < timeToFade)
        {
            source.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
