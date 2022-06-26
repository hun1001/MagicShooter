using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SpellManager : MonoSingleton<SpellManager>
{
    private bool[] _spellUseState;

    [SerializeField]
    private GameObject Spells;

    private Image[] _spellImages;

    private SpellType _usingSpell;

    void Start()
    {
        _spellUseState = new bool[3];
        for (int i = 0; i < 3; ++i)
        {
            _spellUseState[i] = false;
        }

        _usingSpell = SpellType.NONE;

        _spellImages = Spells.GetComponentsInChildren<Image>();

        EventManager.StartListening("UpdatePlayerInfoUI", SpellImagesUpdate);
        EventManager.StartListening("UseMPSpell", UseMpSpell);
        EventManager.StartListening("UseFireBall", UseFireBall);
        EventManager.StartListening("UseIceBall", UseIceBall);

        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }

    void UseMpSpell()
    {
        if (!_spellUseState[(int)SpellType.MPBALL])
        {
            return;
        }

        if (_spellUseState[(int)SpellType.MPBALL])
        {
            _spellImages[(int)SpellType.MPBALL].DOFade(1, 0.5f);
        }

        if (_spellUseState[(int)SpellType.FIREBALL])
        {
            _spellImages[(int)SpellType.FIREBALL].DOFade(0.5f, 0);
        }

        if (_spellUseState[(int)SpellType.ICEBALL])
        {
            _spellImages[(int)SpellType.ICEBALL].DOFade(0.5f, 0);
        }

        CharacterManager.Instance.CharacterAttack._bulletPrefab = Resources.Load<GameObject>("Prefabs/Spell/MPSpell");
        _usingSpell = SpellType.MPBALL;
    }

    void UseFireBall()
    {
        if (!_spellUseState[(int)SpellType.FIREBALL])
        {
            return;
        }

        if (_spellUseState[(int)SpellType.MPBALL])
        {
            _spellImages[(int)SpellType.MPBALL].DOFade(0.5f, 0);
        }

        if (_spellUseState[(int)SpellType.FIREBALL])
        {
            _spellImages[(int)SpellType.FIREBALL].DOFade(1, 0.5f);
        }

        if (_spellUseState[(int)SpellType.ICEBALL])
        {
            _spellImages[(int)SpellType.ICEBALL].DOFade(0.5f, 0);
        }

        CharacterManager.Instance.CharacterAttack._bulletPrefab = Resources.Load<GameObject>("Prefabs/Spell/FireBall");
        _usingSpell = SpellType.FIREBALL;
    }

    void UseIceBall()
    {
        if (!_spellUseState[(int)SpellType.ICEBALL])
        {
            return;
        }

        if (_spellUseState[(int)SpellType.MPBALL])
        {
            _spellImages[(int)SpellType.MPBALL].DOFade(0.5f, 0);
        }

        if (_spellUseState[(int)SpellType.FIREBALL])
        {
            _spellImages[(int)SpellType.FIREBALL].DOFade(0.5f, 0);
        }

        if (_spellUseState[(int)SpellType.ICEBALL])
        {
            _spellImages[(int)SpellType.ICEBALL].DOFade(1f, 0.5f);
        }

        CharacterManager.Instance.CharacterAttack._bulletPrefab = Resources.Load<GameObject>("Prefabs/Spell/IceBall");
        _usingSpell = SpellType.ICEBALL;
    }

    public void SetSpell(SpellType type, bool state)
    {
        _spellUseState[(int)type] = state;
        EventManager.TriggerEvent("UpdatePlayerInfoUI");
    }

    void SpellImagesUpdate()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (_spellUseState[i])
            {
                if ((int)_usingSpell != i)
                {
                    _spellImages[i].color = new Color(_spellImages[i].color.r, _spellImages[i].color.g, _spellImages[i].color.b, 0.5f);
                }
            }
            else
            {
                _spellImages[i].color = new Color(_spellImages[i].color.r, _spellImages[i].color.g, _spellImages[i].color.b, 0);
            }
        }
    }
}
