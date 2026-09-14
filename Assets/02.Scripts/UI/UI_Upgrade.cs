using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Upgrade : MonoBehaviour
{
    [SerializeField] private int _index;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _scoreCostText;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnClick);
        }
    }

    public void OnClick()
    {
        // 버튼이 클릭되면 매니저에게 레벨업을 요청
        UpgradeManager.Instance.LevelUp(_index);
    }

    public void Refresh()
    {
        if (UpgradeManager.Instance == null || UpgradeManager.Instance.Upgrades == null) return;
        if (_index < 0 || _index >= UpgradeManager.Instance.Upgrades.Length) return;

        Upgrade upgrade = UpgradeManager.Instance.Upgrades[_index];
        if (upgrade == null) return;

        // 텍스트 출력
        _titleText.text = $"{upgrade.Name} Lv.{upgrade.Level}";
        _valueText.text = $"{upgrade.CurrentValue}->{upgrade.NextValue}";
        _scoreCostText.text = $"{upgrade.Cost:N0} Score";
    }
}