using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetMonster : MonoBehaviour
{
    [SerializeField]
    private int HP = 3;

    private TextMeshProUGUI ScoreText;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        
    }

    public void Kill()
    {
        ScoreText.text = (int.Parse(ScoreText.text) + 1).ToString();
        Destroy(gameObject);
    }

    public void ApplyDamage(int _damage)
    {
        if (HP <= 0) return;

        HP -= _damage;
        animator.SetTrigger("Hit");

        if (HP <= 0)
        {
            animator.SetTrigger("Die");
        }
    }
}
