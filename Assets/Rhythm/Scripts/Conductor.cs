using NUnit.Framework;
using System.Linq;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    float songBpm;
    float secPerBeat;
    float songPosition; //in seconds
    float songPositionInBeats;
    float dspSongTime; //time passed since song started
    public AudioSource musicSource;
    float firstBeatOffset;
    public GameObject note;
    float[] notes;
    int nextIndex = 0;
    void Start()
    {
        notes = new float[] { 1,2,3,4,5,6,7,8,9,11,12.5f,12.75f,13,17,18,19,20,21,22,23,25,26,27,28,29,
            30,31,33,34,35,36,37,38,39,40,41,43,45,49,50,51,52,53,54,55,57,58,59,60,61,62,63,65,66,67,68,
            69,70,71,72,73,75,77,81,83,85,90,91,92,93,93.5f,94,98,99,100,101,101.5f,102,103.5f,104,104.5f,
            105,108,108.5f,109,113,114,115,116,117,118,119,121,122,123,124,125,126,127,129,130,131,132,133,134,
            135,136,137,139,141};
        musicSource = GetComponent<AudioSource>();
        songBpm = 80;
        secPerBeat = 60f / songBpm;
        firstBeatOffset = 4.5f;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        songPositionInBeats = songPosition / secPerBeat;
        if (notes != null && nextIndex < notes.Length)
        {
            if (notes[nextIndex] < songPositionInBeats + 3)
            {
                Instantiate(note, transform);
                nextIndex++;
            }
        }
    }
}
