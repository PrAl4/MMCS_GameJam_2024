using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    public float _bpm;
    public AudioSource _audioSource;
    public Intervals[] _intervals;

    private void Update()
    {
        foreach (Intervals interval in _intervals)
        {
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLength(_bpm)));
            interval.CheckForNewInterval(sampledTime);
        }
    }
    [System.Serializable]
    public class Intervals
    {
        public float _steps;
        public UnityEvent _trigger;
        private int _lastInterval;

        public float GetIntervalLength(float bpm)
        {
            return 60f / (bpm * _steps);
        }

        public void CheckForNewInterval(float interval)
        {
            //interval = 1.6f;
            if (Mathf.FloorToInt(interval) != _lastInterval) 
            {
                _lastInterval = Mathf.FloorToInt(interval);
                //Debug.Log("trigger "+ interval);
                _trigger.Invoke();
            }
        }
    }
}
