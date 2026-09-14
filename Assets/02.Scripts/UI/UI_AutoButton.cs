using UnityEngine;
using UnityEngine.UI;

public class UI_AutoButton : MonoBehaviour
{
    // 버튼을 클릭하면 토글하고 싶다.
    // - 플레이어의 자동 이동
    // - 플레이어의 자동 공격

    private Image _myImage;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private bool _autoMode = false;
    private Player _player;

    private void Start()
    {
        _myImage = GetComponent<Image>();
        _player = GameObject.FindAnyObjectByType<Player>();

        AutoToggle();
    }

    public void AutoToggle()
    {
        _autoMode = !_autoMode;

        _player.GetComponent<PlayerFire>().SetAuto(_autoMode);
        //  _player.GetComponent<PlayerMove>().enabled = !_autoMode;

        _myImage.sprite = _autoMode ? _onSprite : _offSprite;
    }

    // todo: 버튼 클릭할 때 애니메이션 및 사운드 추가해보기
    // 애니메이션: 코드로 구현 - 약간 커졌다가 작아지기
    // 사운드: 일레븐랩스에서 버튼 클릭 공용 사운드 만들어서 적용하기
}