using UnityEngine;

public class PlayerBattleControl : MonoBehaviour
{

    private int currentTile = 4;
    private float basicTimeStamp;
    private bool isCooldownStarted = false;

    [SerializeField] float basicAttackCooldown = 5f;
    [SerializeField] GameObject[] map;
    [SerializeField] GameObject basicAttackProjectile;
    [SerializeField] Transform player;

    //UI
    [SerializeField] UICoolDown basicCoolDownUI;

    public float GetBasicCooldown()
    {
        return basicAttackCooldown;
    }

    public bool IsCooldownStarted => isCooldownStarted;

    // Start is called before the first frame update
    void Start()
    {
        // set the initial position of the playre to the center tile
        player.transform.position = map[currentTile].transform.position;
        basicTimeStamp = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        BasicAttack();
    }

    void BasicAttack()
    {
        if (basicTimeStamp > Time.time)
        {
            isCooldownStarted = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           Instantiate(basicAttackProjectile, player.transform.position, player.transform.rotation);
            basicTimeStamp = Time.time + basicAttackCooldown;
            isCooldownStarted = true;
            // start or reset the cooldown
            basicCoolDownUI.Cooldown();
        }
    }

    void UpdateMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            // go upward only if there is a tile available
            if(currentTile < 6)
            {
                currentTile += 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(currentTile > 2)
            {
                currentTile -= 3;
            } 
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(currentTile % 3 != 0)
            {
                currentTile -= 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
           if((currentTile + 1) % 3 != 0)
            {
                currentTile += 1;
            }
        }
        UpdatePosition();
    }

    void UpdatePosition()
    {
        Vector3 updatedPosition = map[currentTile].transform.position;
        player.transform.position =new Vector3(updatedPosition.x, updatedPosition.y,  -5) ;
    }

    
}
