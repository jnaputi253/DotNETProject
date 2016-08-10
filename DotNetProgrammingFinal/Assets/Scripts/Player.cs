using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MovingObject
{
    public float restartLevelDelay = 1f;
    public int wallDamage = 1;
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip gameOverSound;

    private Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    private void OnDisable()
    {
        
    }

    private void Update()
    {
        int horizontal = 0;
        int vertical = 0;
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));
        if (horizontal != 0)
        {
            vertical = 0;
        }
        #endif
        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove<Wall>(horizontal, vertical);
        }
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        base.AttemptMove<T>(xDir, yDir);
        RaycastHit2D hit;
        if (Move(xDir, yDir, out hit))
        {
            //	SoundManager.instance.RandomizeSfx (moveSound1, moveSound2);
        }
        CheckIfGameOver();
    }

    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;
        hitWall.DamageWall(wallDamage);
        animator.SetTrigger("playerChop");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            //TODO Pull up Random Question here and check answer and stuff...


            //IF ANSWER CORRECT DO BELOW
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    private void CheckIfGameOver()
    {
        //Check if food point total is less than or equal to zero.
        //if (food <= 0)
        //{
            //Call the PlaySingle function of SoundManager and pass it the gameOverSound as the audio clip to play.
            //		SoundManager.instance.PlaySingle (gameOverSound);

            //Stop the background music.
            //	SoundManager.instance.musicSource.Stop();

            //Call the GameOver function of GameManager.
        //    GameManager.instance.GameOver();
        //}
    }
}
