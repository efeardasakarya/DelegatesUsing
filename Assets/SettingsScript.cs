using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    
    public Button settingsButton;
    public GameObject settingsPanel;
    public TMP_Dropdown spaceDropdown;
    public TMP_Dropdown shiftDropdown;
    public Player player;
    private bool isActive = false;
    private List<Player.ActionDelegate> delegates = new List<Player.ActionDelegate>();
    

    void Start()
    {
        
        settingsPanel.SetActive(false); // Ayarlar� ba�lang��ta kapatan fonksiyon

        
        settingsButton.onClick.AddListener(ToggleSettingsPanel); //Listenerlar� ekleyen fonksiyon

        // Delegelere fonksiyonlar� ekle
        delegates.Add(player.Fire);
        delegates.Add(player.Dash);
        delegates.Add(player.Teleport);

        // Dropdownlar� ba�lat
        PopulateDropdown(spaceDropdown);
        PopulateDropdown(shiftDropdown);

        // Dropdown de�i�imlerini kontrol et
        spaceDropdown.onValueChanged.AddListener(SpacevalueChanged);
        shiftDropdown.onValueChanged.AddListener(ShiftValueChanged);
    }

    void ToggleSettingsPanel()   // Paneli g�r�n�r/g�r�nmez k�lan fonksiyon
    {
        isActive = !isActive;
        settingsPanel.SetActive(isActive);
    }

    void PopulateDropdown(TMP_Dropdown dropdown) //Dropdownlar� kontrol eden fonksiyon
    {
        dropdown.ClearOptions();
        List<string> options = new List<string> { "L�tfen bir tu� atay�n" };
        foreach (var del in delegates)
        {
            options.Add(del.Method.Name); // Hangi i�lemi yapaca��n�z yaz
        }
        dropdown.AddOptions(options);
    }

    void SpacevalueChanged(int spaceFonk)
    {
        if (spaceFonk == 0)
        {
            player.spaceDelegate = null; // ��lem se�ili de�ilse hi�bir �ey yapma
        }
        else
        {
            player.spaceDelegate = delegates[spaceFonk - 1]; 
        }
    }

    void ShiftValueChanged(int shiftFonk)
    {
        if (shiftFonk == 0)
        {
            player.shiftDelegate = null; // ��lem se�ili de�ilse hi�bir �ey yapma
        }
        else
        {
            player.shiftDelegate = delegates[shiftFonk - 1]; 
        }
    }
}
