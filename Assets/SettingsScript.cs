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
        
        settingsPanel.SetActive(false); // Ayarlarý baþlangýçta kapatan fonksiyon

        
        settingsButton.onClick.AddListener(ToggleSettingsPanel); //Listenerlarý ekleyen fonksiyon

        // Delegelere fonksiyonlarý ekle
        delegates.Add(player.Fire);
        delegates.Add(player.Dash);
        delegates.Add(player.Teleport);

        // Dropdownlarý baþlat
        PopulateDropdown(spaceDropdown);
        PopulateDropdown(shiftDropdown);

        // Dropdown deðiþimlerini kontrol et
        spaceDropdown.onValueChanged.AddListener(SpacevalueChanged);
        shiftDropdown.onValueChanged.AddListener(ShiftValueChanged);
    }

    void ToggleSettingsPanel()   // Paneli görünür/görünmez kýlan fonksiyon
    {
        isActive = !isActive;
        settingsPanel.SetActive(isActive);
    }

    void PopulateDropdown(TMP_Dropdown dropdown) //Dropdownlarý kontrol eden fonksiyon
    {
        dropdown.ClearOptions();
        List<string> options = new List<string> { "Lütfen bir tuþ atayýn" };
        foreach (var del in delegates)
        {
            options.Add(del.Method.Name); // Hangi iþlemi yapacaðýnýz yaz
        }
        dropdown.AddOptions(options);
    }

    void SpacevalueChanged(int spaceFonk)
    {
        if (spaceFonk == 0)
        {
            player.spaceDelegate = null; // Ýþlem seçili deðilse hiçbir þey yapma
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
            player.shiftDelegate = null; // Ýþlem seçili deðilse hiçbir þey yapma
        }
        else
        {
            player.shiftDelegate = delegates[shiftFonk - 1]; 
        }
    }
}
