using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource audioSource;
    public Movement move;
    public Animator anim;
    public int damageEnemy;

    private bool isAnimationPlaying = false;

    private void Update()
    {
        if (Input.GetKey(move.shoot) && !isAnimationPlaying)
        {
            StartCoroutine(PlayAttackAnimation());
        }
    }

    private IEnumerator PlayAttackAnimation()
    {
        isAnimationPlaying = true;
        anim.Play("Attack2", -1, 0f);

        // Wait for the animation to finish.
        audioSource.Play();
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        isAnimationPlaying = false;

        // Now you can damage the enemy in a specific zone.
        
    }

    public void DamageEnemiesInZone()
    {
        // Check if the player is colliding with enemies within the specific zone.
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(2f, 1f), 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Health healthS = collider.GetComponent<Health>();
                healthS.health -= damageEnemy; // Assuming "health" is the property to modify.
            }
        }
    }
}
