using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildManager : MonoBehaviour {
    public GuildhallPanel playerPanel, memberPanel, inventoryPanel, upgradesPanel, shopPanel, blacksmithPanel;

    public void ShowPlayerPanel() {
        playerPanel.Show();
        memberPanel.Hide();
        inventoryPanel.Hide();
        upgradesPanel.Hide();
        shopPanel.Hide();
        blacksmithPanel.Hide();
    }

    public void ShowMemberPanel() {
        playerPanel.Hide();
        memberPanel.Show();
        inventoryPanel.Hide();
        upgradesPanel.Hide();
        shopPanel.Hide();
        blacksmithPanel.Hide();
    }

    public void ShowInventoryPanel() {
        playerPanel.Hide();
        memberPanel.Hide();
        inventoryPanel.Show();
        upgradesPanel.Hide();
        shopPanel.Hide();
        blacksmithPanel.Hide();
    }

    public void ShowUpgradesPanel() {
        playerPanel.Hide();
        memberPanel.Hide();
        inventoryPanel.Hide();
        upgradesPanel.Show();
        shopPanel.Hide();
        blacksmithPanel.Hide();
    }

    public void ShowShopPanel() {
        playerPanel.Hide();
        memberPanel.Hide();
        inventoryPanel.Hide();
        upgradesPanel.Hide();
        shopPanel.Show();
        blacksmithPanel.Hide();
    }

    public void ShowBlacksmithPanel() {
        playerPanel.Hide();
        memberPanel.Hide();
        inventoryPanel.Hide();
        upgradesPanel.Hide();
        shopPanel.Hide();
        blacksmithPanel.Show();
    }
}
