using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Character observedCharacter;
    public TextMeshProUGUI textHp;


    // Start is called before the first frame update
    void Start()
    {
        observedCharacter.OnHpChange.AddListener(UpdateTextHp);
        observedCharacter.OnCharacterDeath.AddListener(InformDeath);
    }

    private void InformDeath()
    {
        textHp.color = Color.red;
        textHp.text = "Sei morto";
    }

    private void UpdateTextHp(float hp, float hpMax)
    {
        textHp.text = hp.ToString("0") + "/" + hpMax.ToString("0");

        Color colorToGive = Color.yellow;
        float hpRatio = hp / hpMax;
        if (hpRatio > 0.7f) { colorToGive = Color.green; }
        if (hpRatio < 0.3f) { colorToGive = Color.red; }
        textHp.color = colorToGive;
    }
}
