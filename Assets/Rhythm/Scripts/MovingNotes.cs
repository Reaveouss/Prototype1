using UnityEngine;

public class MovingNotes : MonoBehaviour
{
    float BeatsShownInAdvance = 2.5f;
    GameObject Note;
    Vector3 SpawnPos;
    Vector3 RemovePos;
    [SerializeField] AudioSource musicSource;
    float dspSongTime;
    float firstBeatOffset = 4;
    float songPosition;
    float beat;
    void Start()
    {
        musicSource = GetComponentInParent<AudioSource>();
        SpawnPos.x = 8;
        transform.position = SpawnPos;
        RemovePos.x = -7.25f;
        dspSongTime = (float)AudioSettings.dspTime;
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        transform.position = Vector2.Lerp(SpawnPos, RemovePos, (songPosition / BeatsShownInAdvance));
    }
    public void Kill()
    {
        Debug.Log("kill");
        Destroy(this.gameObject);
    }
}
