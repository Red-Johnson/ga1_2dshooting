using UnityEngine;
using UnityEngine.UI;

// 자동 사냥(이동/공격) 토글 전담
public class UI_AutoButton : MonoBehaviour
{
    [SerializeField] private Sprite _onSprite;

    [SerializeField] private Sprite _offSprite;

    private Image _myImage;
    private Button _button;
    private Player _player;
    private bool _autoMode = false;

    private void Start()
    {
        _myImage = GetComponent<Image>();
        _button = GetComponent<Button>();
        _player = GameObject.FindAnyObjectByType<Player>();

        // 코드로 토글 이벤트 연결
        _button.onClick.AddListener(AutoToggle);

        // 초기 이미지 세팅
        UpdateUI();
    }

    public void AutoToggle()
    {
        _autoMode = !_autoMode;

        if (_player != null)
        {
            _player.GetComponent<PlayerFire>().SetAuto(_autoMode);
            // _player.GetComponent<PlayerMove>().enabled = !_autoMode;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_myImage != null)
        {
            _myImage.sprite = _autoMode ? _onSprite : _offSprite;
        }
    }
}