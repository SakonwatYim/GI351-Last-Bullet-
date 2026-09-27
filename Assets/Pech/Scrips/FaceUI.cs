using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Doom (1993)-style face indicator.
/// Attach to a UI GameObject that has an Image component (the face).
/// Assign the 6 face sprites in the inspector, ordered from
/// healthiest (100) to dead (0): 100, 80, 60, 40, 20, 0.
/// </summary>
public class FaceUI : MonoBehaviour
{
    [Header("References")]
    public player player;          // drag the player object here
    public Image faceImage;        // the UI Image that shows the face

    [Header("Face Sprites (100 -> 0)")]
    public Sprite face100;
    public Sprite face80;
    public Sprite face60;
    public Sprite face40;
    public Sprite face20;
    public Sprite face0;

    [Header("Settings")]
    public int maxHealth = 100;    // used to scale thresholds if maxHealth != 100

    int lastHealth = int.MinValue; // cache so we only update the sprite when health actually changes

    void Reset()
    {
        // convenience: auto-grab the Image if this script sits on the same object
        if (faceImage == null)
            faceImage = GetComponent<Image>();
    }

    void Update()
    {
        if (player == null || faceImage == null) return;

        int health = player.health;

        if (health != lastHealth)
        {
            UpdateFace(health);
            lastHealth = health;
        }
    }

    void UpdateFace(int health)
    {
        // normalize to a 0-100 scale in case maxHealth isn't 100
        float pct = maxHealth > 0 ? (health / (float)maxHealth) * 100f : health;

        Sprite chosen;

        if (pct <= 0)
            chosen = face0;
        else if (pct <= 20)
            chosen = face20;
        else if (pct <= 40)
            chosen = face40;
        else if (pct <= 60)
            chosen = face60;
        else if (pct <= 80)
            chosen = face80;
        else
            chosen = face100;

        if (chosen != null)
            faceImage.sprite = chosen;
    }
}
