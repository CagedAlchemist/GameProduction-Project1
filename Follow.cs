using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player;
    static Animator animate;
    public float enemyReach = 2f, detectDistance = 2f; //How far player is from enemy before they start walking
    public float detectionAngle = 30;
    private void Start()
    {
        animate = GetComponent<Animator>();
    }
    void Update()
    {
        if (pause_menu.GameIsPaused == false)
        {
            Vector3 direction = player.position - this.transform.position;

            if (Vector3.Distance(player.position, this.transform.position) < detectDistance)
            {
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                animate.SetBool("isIdle", false);

                if (direction.magnitude > enemyReach)
                {
                     animate.SetBool("isWalking", true);
                     this.transform.Translate(0, 0, 0.05f);

                }
                else
                {
                    animate.SetBool("isWalking", false);
                    animate.SetBool("isIdle", true);
                    //Code here to intiate patrolling?
                }
            }
        }
    }
}
