using TMPro;
using UnityEngine;

public class SOUIIntUpdate : MonoBehaviour
{

    public ItemManager itemManager;

    public SOInt SOInt;

    public TextMeshProUGUI coinIntText;

    private void Awake()
    {
        itemManager.coinCountChange += UpdateUI;
    }

    private void UpdateUI()
    {
        coinIntText.text = "X " + itemManager.coinCount.value.ToString();
    }
}
