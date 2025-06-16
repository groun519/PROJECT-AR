using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFAnimtion : MonoBehaviour
{
    [SerializeField]
    private GameObject Card;
    [SerializeField]
    private GameObject Card_Skill;

    [SerializeField]
    private GameObject CharacterMesh;

    [SerializeField]
    private GameObject RightHand;
    [SerializeField]
    private GameObject LeftHand;

    [SerializeField]
    private GameObject Enemy;

    private Animator anim;

    public int ComboStack = 0;

    private float timer = 0.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 3.0f)
        {
            SpawnEnemy();
            timer = 0.0f;
        }
    }

    void ShootCard(int _bIsRightHand)
    {
        if (_bIsRightHand == 0)
        {
            Instantiate(Card, RightHand.transform.position, CharacterMesh.transform.rotation, null);
        }
        else
        {
            Instantiate(Card, LeftHand.transform.position, CharacterMesh.transform.rotation, null);
        }
    }

    void ShootSkill(int _bIsRightHand)
    {
        Instantiate(Card_Skill, RightHand.transform.position, CharacterMesh.transform.rotation, null);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void Skill()
    {
        anim.SetTrigger("Skill");
    }

    void SpawnEnemy()
    {
        float angleDegrees = Random.Range(0f, 360f);  // 0µµ ~ 360µµ ·£´ý
        float angleRad = angleDegrees * Mathf.Deg2Rad;

        float radius = Random.Range(0.5f, 1.5f);
        float x = Mathf.Cos(angleRad) * radius;
        float z = Mathf.Sin(angleRad) * radius;

        Vector3 center = this.gameObject.transform.position;
        Vector3 randomVec = new Vector3(center.x + x, center.y, center.z + z);

        Instantiate(Enemy, randomVec, GetAngleFromAtoB(randomVec, center));
    }

    public Quaternion GetAngleFromAtoB(Vector3 from, Vector3 to)
    {
        Vector3 direction = to - from;

        direction.y = 0f;

        if (direction == Vector3.zero)
            return Quaternion.identity;

        return Quaternion.LookRotation(direction.normalized);
    }
}
