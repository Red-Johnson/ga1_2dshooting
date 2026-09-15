using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // 관리: 특정 데이터에 대한 무결성과 생성, 조회, 수정, 삭제 등과 관련된 게임 로직
    // 업그레이드 관리자: 업그레이드에 대한 무결성과 생성, 조회, 수정, 삭제 등과 관련된 게임 로직

    private static UpgradeManager _instance = null;
    public static UpgradeManager Instance => _instance;

    [SerializeField] private Upgrade[] _upgrades;
    public Upgrade[] Upgrades => _upgrades;

    [SerializeField] private UI_Upgrade[] _uiUpgrades;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        Load();

        RefreshUI();
    }

    public void LevelUp(int index)
    {
        // Todo: 묻지 말고 시켜라!
        // 골드(점수) 매니저에게 돈이 있는지 물어보고 돈이 있다면 차감 후 업그레이드 호출

        Upgrade upgrade = _upgrades[index];

        if (ScoreManager.Instance.Score < upgrade.Cost)
        {
            return;
        }

        ScoreManager.Instance.Spend(upgrade.Cost);

        if (index < 0 || index >= _upgrades.Length) return;
        _upgrades[index].LevelUp();

        Save();

        if (_uiUpgrades != null && index < _uiUpgrades.Length && _uiUpgrades[index] != null)
        {
            _uiUpgrades[index].Refresh();
        }
    }

    public void RefreshUI()
    {
        if (_uiUpgrades == null) return;

        for (int i = 0; i < _uiUpgrades.Length; i++)
        {
            if (_uiUpgrades[i] != null)
            {
                _uiUpgrades[i].Refresh();
            }
        }
    }

    private void Save()
    {
        // 데이터 저장은 유의미한 정보만 저장한다.
        // 그래서 레벨만 저장한다.
        for (int i = 0; i < _upgrades.Length; i++)
        {
            PlayerPrefs.SetInt($"Upgrade.{i}.Level", _upgrades[i].Level);
        }

        PlayerPrefs.Save();
    }

    private void Load()
    {
        for (int i = 0; i < _upgrades.Length; i++)
        {
            int level = PlayerPrefs.GetInt($"Upgrade.{i}.Level", 1);
            _upgrades[i].SetLevel(level);
        }
    }
}