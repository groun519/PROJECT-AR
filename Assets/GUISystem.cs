using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUISystem : MonoBehaviour
{
    [SerializeField] private Button BTN_Attack;
    [SerializeField] private Slider SLD_Attack;
    [SerializeField] private float AttackCooldown = 2.0f;

    [SerializeField] private Button BTN_Skill;
    [SerializeField] private Slider SLD_Skill;
    [SerializeField] private float SkillCooldown = 5.0f;

    private GameObject Twisted_Fate;
    private TFAnimtion TFAnim;

    private void Start()
    {
        BTN_Attack.interactable = false;
        BTN_Skill.interactable = false;

        SLD_Attack.value = 0;
        SLD_Skill.value = 0;
    }

    private void Update()
    {
        if (Twisted_Fate == null)
        {
            Twisted_Fate = GameObject.FindWithTag("TF");
            TFAnim = Twisted_Fate.GetComponent<TFAnimtion>();

            BTN_Attack.interactable = true;
            BTN_Skill.interactable = true;
        }
    }

    public void OnAttack()
    {
        TFAnim.Attack();
        BTN_Attack.interactable = false;
        StartCoroutine(HandleCooldown(SLD_Attack, BTN_Attack, AttackCooldown));
    }

    public void OnSkill()
    {
        TFAnim.Skill();
        BTN_Skill.interactable = false;
        StartCoroutine(HandleCooldown(SLD_Skill, BTN_Skill, SkillCooldown));
    }

    private IEnumerator HandleCooldown(Slider slider, Button button, float cooldown)
    {
        float timer = 0f;
        slider.value = 1f;

        while (timer < cooldown)
        {
            timer += Time.deltaTime;
            slider.value = 1f - (timer / cooldown);
            yield return null;
        }

        slider.value = 0f;
        button.interactable = true;
    }
}
