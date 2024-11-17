using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    private bool isCoroutine = false;
    private bool jump = false;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) & !jump )
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
    public void PlaySoundtrack()
    {

    }
}
