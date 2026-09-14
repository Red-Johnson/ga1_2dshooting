using UnityEngine;
using UnityEngine.UI;

// 재활용 가능한 버튼 클릭 이펙트 (애니메이션 + 사운드 전담)
public class UI_ButtonClick : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    [SerializeField] private AnimationCurve _bumpCurve;

    private const float BumpDuration = 0.3f;
    private const float BumpScale = 1.1f;

    private bool _isBumping = false;
    private float _elapsedTime = 0;

    private void Start()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();

        // 에디터에서 일일이 드래그할 필요 없이, 코드로 클릭 이벤트 자동 연결
        _button.onClick.AddListener(PlayAnimation);
        _button.onClick.AddListener(PlaySound);
    }

    private void Update()
    {
        if (!_isBumping) return;

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > BumpDuration)
        {
            transform.localScale = Vector3.one;
            _isBumping = false;
            return;
        }

        float time = _elapsedTime / BumpDuration;
        float curveValue = _bumpCurve.Evaluate(time);
        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * BumpScale, curveValue);
    }

    private void PlaySound()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }

    private void PlayAnimation()
    {
        _isBumping = true;
        _elapsedTime = 0;
    }
}