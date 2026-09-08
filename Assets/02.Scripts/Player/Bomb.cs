using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _bombObject;
    [SerializeField] private Animator _bombAnimator;

    private float _durationTimer = 0f;

    public bool IsActive { get; private set; }

    private void Update()
    {
        if (IsActive)
        {
            _durationTimer -= Time.deltaTime;

            if (_durationTimer <= 0)
            {
                IsActive = false;
                _bombObject.SetActive(false);
            }
        }
    }

    public void ActivateBomb()
    {
        IsActive = true;
        _durationTimer = 3f;

        if (_bombAnimator != null)
        {
            _bombAnimator.SetTrigger("Activate");
            _bombObject.SetActive(true);
        }
    }
}