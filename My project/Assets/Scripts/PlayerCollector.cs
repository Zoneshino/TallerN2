using UnityEngine;
using TMPro;

public class PlayerCollector : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI starText;

    private int score = 0;
    private int stars = 0;

    private int greenCount = 0;
    private int redCount = 0;

    private float speedBoostDuration = 5f;
    private float boostedSpeed = 10f;
    private float speedBoostEndTime;

    private MovePlayer moveScript;

    void Start()
    {
        moveScript = GetComponent<MovePlayer>();
        UpdateUI();
    }

    void Update()
    {
        if (Time.time > speedBoostEndTime)
        {
            moveScript.ResetSpeed();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            switch (item.type)
            {
                case Item.ItemType.AppleGreen:
                    greenCount++;
                    score += item.GetValue();
                    break;

                case Item.ItemType.AppleRed:
                    redCount++;
                    score += item.GetValue();
                    break;

                case Item.ItemType.Banana:
                    speedBoostEndTime = Time.time + speedBoostDuration;
                    moveScript.SetSpeed(boostedSpeed);
                    break;

                case Item.ItemType.Medkit:
                    if (LifeSystem.instance != null)
                    {
                        LifeSystem.instance.AddLife();
                    }
                    break;

                case Item.ItemType.Star:
                    stars += 1;
                    break;
            }

            UpdateUI();
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (LifeSystem.instance != null)
            {
                LifeSystem.instance.TakeDamage();
            }

            Debug.Log("?? Golpe del enemigo");
        }
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (starText != null) starText.text = "Stars: " + stars;
    }

    public int GetItemCount(string type)
    {
        switch (type)
        {
            case "Green": return greenCount;
            case "Red": return redCount;
            case "Star": return stars;
            default: return 0;
        }
    }
}
