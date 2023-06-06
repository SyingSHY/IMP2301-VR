using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController_Zombie : MonoBehaviour
{
    // Bulb collection counter to check game progress
    // 게임 진행 상황 확인을 위한 수집된 전구 카운터
    public int levelCounter = 0;

    [SerializeField]
    Transform agentTarget;
    // GunShooted 테스트용 변수
    [SerializeField]
    private bool GunshootTest = false;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private int isWalkingHash, isRunningHash, isStunnedHash, isLightShootedHash, isGunShootedHash, isGameWinHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isLightShootedHash = Animator.StringToHash("isLightShooted");
        isStunnedHash = Animator.StringToHash("isStunned");
        isGunShootedHash = Animator.StringToHash("isGunShooted");
        isGameWinHash = Animator.StringToHash("isGameWin");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(agentTarget.position);

        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isLightShooted = animator.GetBool(isLightShootedHash);
        bool isStunned = animator.GetBool(isStunnedHash);
        bool isGunShooted = animator.GetBool(isGunShootedHash);
        bool isGameWin = animator.GetBool(isGameWinHash);

        // Enemy running animation & agent speed setting
        if (levelCounter < 2 && isGunShooted == false)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            navMeshAgent.speed = 0f;
        }
        else if (levelCounter < 5 && isGunShooted == false)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            navMeshAgent.speed = 0.6f;
        }
        else if (levelCounter < 6 && isGunShooted == false)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
            navMeshAgent.speed = 1.5f;
        }
        else
        {
            navMeshAgent.speed = 0f;
        }

        if (GunshootTest) GunShooted();
    }

    // Called by SendMessage() : Enemy got shooted by Player
    public void GunShooted()
    {
        animator.SetBool("isStunned", true);
        animator.SetBool("isGunShooted", true);
        navMeshAgent.speed = 0f;

        Invoke("DisableStun", 7);
        Invoke("GetRecover", 10);
    }

    // Called by SendMessage() : Enemy got shooted by Player's flashlight
    public void LightShooted()
    {
        animator.SetBool("isGunShooted", true);
        navMeshAgent.speed = 0f;

        Invoke("DisableStun", 7);
        Invoke("GetRecover", 10);
    }

    // Called by GunShooted() : Get recover from knock-down which caused by Player's shoot
    private void DisableStun()
    {
        animator.SetBool("isStunned", false);
    }

    // Called by GunShooted() : Get recover from knock-down which caused by Player's shoot
    private void GetRecover()
    {
        animator.SetBool("isGunShooted", false);
    }
}
