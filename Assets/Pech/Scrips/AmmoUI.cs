using UnityEngine;
using TMPro;

/// <summary>
/// Doom (1993)-style ammo counter.
/// Attach to a UI GameObject and assign a TextMeshProUGUI to show the count.
/// Reads currrent_Bullet / max_Bullet straight from the player script.
/// </summary>
public class AmmoUI : MonoBehaviour
{
    [Header("References")]
    public player player;              // drag the player object here
    public TMP_Text ammoText;          // TextMeshPro - UI (drag the Text object here

    [Header("Low Ammo Warning")]
    public bool warnOnLowAmmo = true;
    [Tooltip("Ammo at or below this turns the text red")]
    public int lowAmmoThreshold = 20;
    public Color normalColor = Color.white;
    public Color lowAmmoColor = Color.red;

    int lastBullet = int.MinValue; // cache so we only touch the UI when the count actually changes

    void Update()
    {
        if (player == null || ammoText == null) return;

        int current = player.currrent_Bullet;

        if (current != lastBullet)
        {
            UpdateAmmoDisplay(current);
            lastBullet = current;
        }
    }

    void UpdateAmmoDisplay(int current)
    {
        ammoText.text = $"{current} / {player.max_Bullet}";

        if (warnOnLowAmmo)
        {
            ammoText.color = current <= lowAmmoThreshold ? lowAmmoColor : normalColor;
        }
    }
}
