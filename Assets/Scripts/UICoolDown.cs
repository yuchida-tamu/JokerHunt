using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICoolDown : MonoBehaviour
{
    [SerializeField] float baseCooldown;
    [SerializeField] TMP_Text cooldownText;
    [SerializeField] Image overlay;
    float cooldown;
    float maxBullets = 4;

    private bool isCoolingDown = false;

    private void Start()
    {
        cooldown = baseCooldown;
        cooldownText.text = baseCooldown.ToString();
        overlay.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCooldown();
        UpdateOverlay();

        cooldownText.text = Mathf.Round(cooldown).ToString();
    }

    void UpdateOverlay()
    {
        if(baseCooldown == cooldown)
        {
            overlay.fillAmount = 0;
        }else
        {
        overlay.fillAmount = cooldown / baseCooldown;

        }

    }

    void UpdateCooldown()
    {
        if (!isCoolingDown) return;

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = baseCooldown;
            isCoolingDown = false;
        }
    }

    public void Cooldown()
    {
        cooldown = baseCooldown;
        isCoolingDown = true;
    }
}
