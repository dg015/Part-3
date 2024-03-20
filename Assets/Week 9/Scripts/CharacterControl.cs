using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI selection;
    public static CharacterControl Instance;


    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            
            SelectedVillager.Selected(false);
            
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.selection.text = villager.ToString();
    }

    private void Start()
    {
        Instance = this;
    }


    public void GetVillager()
    {
        if (SelectedVillager == null )
        {

            selection.text = "No selection";
        }

        else  if (SelectedVillager.CanOpen() == ChestType.Thief)
        {
            selection.text = "Thief";
        }

        else if (SelectedVillager.CanOpen() == ChestType.Archer)
        {
            selection.text = "Archer";
        }

        else if (SelectedVillager.CanOpen() == ChestType.Merchant)
        {
            selection.text = "Merchant";
        }

        else
        {
            selection.text = "No selection";
        }
        

    }
    
}
