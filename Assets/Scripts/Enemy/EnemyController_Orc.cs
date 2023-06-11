using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController_Orc : MonoBehaviour
{
    // Bulb collection counter to check game progress
    // 게임 진행 상황 확인을 위한 수집된 전구 카운터
    public int levelCounter = 0;

    [SerializeField] Transform agentTarget;
    // GunShooted 테스트용 변수
    [SerializeField] private bool GunshootTest = false;
    [SerializeField] private float startChaseRange = 2.0f;
    [SerializeField] private float finishChaseRange = 5.0f;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private int isWalkingHash, isStunnedHash, isLightShootedHash, isGunShootedHash, isGameWinHash, isCatchPlayerHash;
    private float distBtwPlayer;
    private bool isChasing = false;
    private bool isCatchPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isLightShootedHash = Animator.StringToHash("isLightShooted");
        isStunnedHash = Animator.StringToHash("isStunned");
        isGunShootedHash = Animator.StringToHash("isGunShooted");
        isGameWinHash = Animator.StringToHash("isGameWin");
        isCatchPlayerHash = Animator.StringToHash("isCatchPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isLightShooted = animator.GetBool(isLightShootedHash);
        bool isStunned = animator.GetBool(isStunnedHash);
        bool isGunShooted = animator.GetBool(isGunShootedHash);
        bool isGameWin = animator.GetBool(isGameWinHash);
        isCatchPlayer = animator.GetBool(isCatchPlayerHash);

        // Check whether game has ended by Player's win
        if (levelCounter == 6)
        {
            isGameWin = true;
            navMeshAgent.speed = 0f;
            return;
        }

        // Enemy running animation & agent speed setting
        if (levelCounter < 2 && isGunShooted == false && isChasing == false)
        {
            animator.SetBool("isWalking", false);
            navMeshAgent.speed = 0f;
        }
        else if (levelCounter < 5 && isGunShooted == false && isChasing == true)
        {
            animator.SetBool("isWalking", true);
            navMeshAgent.speed = 0.6f;
        }
        else if (levelCounter < 6 && isGunShooted == false && isChasing == true)
        {
            animator.SetBool("isWalking", true);
            navMeshAgent.speed = 1.2f;
        }
        else
        {
            navMeshAgent.speed = 0f;
        }

        // Only play animation once for caught by enemy
        if (isCatchPlayer) isCatchPlayer = !isCatchPlayer;

        // Test line for gun shoot
        if (GunshootTest) GunShooted();
        if (isGunShooted) isGunShooted = !isGunShooted;
    }

    private void FixedUpdate()
    {
        // Checking whether Player is in the tracking range.
        distBtwPlayer = Vector3.Distance(agentTarget.position, transform.position);

        if (levelCounter < 4)
        {
            if (distBtwPlayer < 2)
            {
                isChasing = true;
            }
            else if (distBtwPlayer > 5)
            {
                isChasing = false;
            }
        }
        else isChasing = true;

        // Chasing Player if he/she is in the range
        if (isChasing) { navMeshAgent.SetDestination(agentTarget.position); }
    }

    // Called by SendMessage() : Enemy got shooted by Player
    public void GunShooted()
    {
        animator.SetBool("isStunned", true);
        animator.SetBool("isGunShooted", true);
        navMeshAgent.speed = 0f;

        Invoke("GetRecover", 1.5f);
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
    private void GetRecover()
    {
        navMeshAgent.speed = 0.6f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCatchPlayer = true;

            // Shut down control of Player
            collision.transform.parent = transform;
            // 병합 후에 작성 예정

            // 게임오버 씬으로 이동
            Debug.Log("You've caught by enemy. Game Over.");
            // 추후 작성 예정
        }
    }
}
