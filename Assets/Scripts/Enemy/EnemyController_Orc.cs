using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class EnemyController_Orc : MonoBehaviour
{
    // Bulb collection counter to check game progress
    // ���� ���� ��Ȳ Ȯ���� ���� ������ ���� ī����
    public int levelCounter = 0;
    public gamamanage gamamanageScript;

    [SerializeField] private Transform agentTarget;
    [SerializeField] private GameObject cameraPlayer;
    [SerializeField] private GameOverFadeOut gameoverFade;
    [SerializeField] private AudioSource screamSound;
    // GunShooted �׽�Ʈ�� ����
    [SerializeField] private bool GunshootTest = false;
    [SerializeField] private float startChaseRange = 2.0f;
    [SerializeField] private float finishChaseRange = 5.0f;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private AudioSource annoyingSound;
    private int isWalkingHash, isStunnedHash, isLightShootedHash, isGunShootedHash, isGameWinHash, isCatchPlayerHash;
    private float distBtwPlayer;
    private bool isChasing = false;
    private bool isCatchPlayer;
    private bool isGameOverred = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        annoyingSound = GetComponent<AudioSource>();

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
        levelCounter = gamamanageScript.bulbcount;

        bool isWalking = animator.GetBool(isWalkingHash);
        bool isLightShooted = animator.GetBool(isLightShootedHash);
        bool isStunned = animator.GetBool(isStunnedHash);
        bool isGunShooted = animator.GetBool(isGunShootedHash);
        bool isGameWin = animator.GetBool(isGameWinHash);
        isCatchPlayer = animator.GetBool(isCatchPlayerHash);

        // Check whether game has ended by Player's win
        if (levelCounter == 6)
        {
            animator.SetBool("isGameWin", true);
            isGameWin = true;
            navMeshAgent.speed = 0f;
            return;
        }

        // Let Player watch enemy biting him/her
        // Player's display became darker and darker
        // When it became fully dark, move to GameOver scene
        if (isGameOverred)
        {
            isChasing = false;
            navMeshAgent.speed = 0f;
            cameraPlayer.transform.LookAt(transform);
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
        else if (levelCounter == 6 && isGunShooted == false && isChasing == true)
        {
            animator.SetBool("isGameWin", true);
        }
        else
        {
            navMeshAgent.speed = 0f;
        }

        // Test line for gun shoot
        if (GunshootTest) GunShooted();
        if (isGunShooted) isGunShooted = !isGunShooted;
    }

    private void FixedUpdate()
    {
        // Checking whether Player is in the tracking range.
        distBtwPlayer = Vector3.Distance(agentTarget.position, transform.position);

        if (levelCounter < 5)
        {
            if (distBtwPlayer < 2 && levelCounter > 1)
            {
                annoyingSound.Play();
                isChasing = true;
            }
            else if (distBtwPlayer > 5 && levelCounter > 1)
            {
                isChasing = false;
            }
        }
        else isChasing = true;

        // Chasing Player if he/she is in the range
        if (isChasing) { 
            navMeshAgent.SetDestination(agentTarget.position); 
        }
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
        if (collision.gameObject.tag == "Player" && !isGameOverred)
        {
            isCatchPlayer = animator.GetBool(isCatchPlayerHash);

            cameraPlayer.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            cameraPlayer.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;

            animator.SetBool("isWalking", false);
            animator.SetBool("isCatchPlayer", true);
            isGameOverred = true;
            isChasing = false;

            // ���ӿ��� ������ �̵�
            Debug.Log("You've caught by enemy. Game Over.");
            gameoverFade.SendMessage("StartFadeOutAnim");
            screamSound.Play();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            GunShooted();
        }
    }
}
