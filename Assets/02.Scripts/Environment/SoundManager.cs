using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    // 효과음을 재생할 공용 스피커
    private AudioSource _sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // 스크립트 실행 시 AudioSource 자동 부착
            _sfxSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // 누군가 효과음을 넘겨주면 겹쳐서(PlayOneShot) 재생해주는 함수
    public void PlaySfx(AudioClip clip)
    {
        if (clip != null)
        {
            _sfxSource.PlayOneShot(clip);
        }
    }
    
}
