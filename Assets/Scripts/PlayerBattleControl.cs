using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleControl : MonoBehaviour
{

    [SerializeField] int currentTile = 5;
    private float basicTimeStamp;
    private bool isCooldownStarted = false;
    private int bulletCount;

    //use the SerializeField attribute when you need your variable to be private 
    //but also want it to show up in the Editor.
    [SerializeField] float basicAttackCooldown = 5f;
    [SerializeField] GameObject[] map;
    [SerializeField] GameObject basicAttackProjectile;
    [SerializeField] Transform player;
    [SerializeField] int maxBullets = 4;

    //UI
    [SerializeField] UICoolDown basicCoolDownUI;
    [SerializeField] UIbulletCount bulletsUI;


    public float GetBasicCooldown(){
        return basicAttackCooldown;
    }

    public bool IsCooldownStarted => isCooldownStarted;

    // Start is called before the first frame update
    void Start(){
        bulletsUI.initialize();
        // set the initial position of the playre to the center tile
        player.transform.position = map[currentTile].transform.position;
        basicTimeStamp = 0f;
        bulletCount = maxBullets;
    }

    // Update is called once per frame
    void Update(){
        UpdateMovement();
        BasicAttack();
    }

    void BasicAttack(){
        if (basicTimeStamp > Time.time){
            isCooldownStarted = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            //shoot projectile
            Instantiate(basicAttackProjectile, player.transform.position, player.transform.rotation);
            //if theres more than one bullet left 
             if(bulletCount == 1){
                // if only one bullet left, auto reload
                useBullet();
                reload();
            } else if(bulletCount!=0){
                useBullet();
            } 
        }

        //manual reload
        if (Input.GetKeyDown(KeyCode.R)){
            reload();
        }
        
    }


//-------------------------------movement ------------------------
    void UpdateMovement(){
        if (Input.GetKeyDown(KeyCode.W)){
            // go upward only if there is a tile available
            if(currentTile % 4 != 0){
                currentTile -= 1;
            }
      
        }

        //move DOWN
        if (Input.GetKeyDown(KeyCode.S)){
           if((currentTile +1) % 4 != 0 ){
                currentTile += 1;
            }
        }

        //move LEFT
        if (Input.GetKeyDown(KeyCode.A)){
            if(currentTile > 3){
                currentTile -= 4;
            } 
        }

        //move RIGHT
        if (Input.GetKeyDown(KeyCode.D)){
            if(currentTile < 12){
                currentTile += 4;
            }
        }
        UpdatePosition();
    }

    void UpdatePosition(){
        Vector3 updatedPosition = map[currentTile].transform.position;
        player.transform.position =new Vector3(updatedPosition.x, 1,  updatedPosition.z) ;
    }
    


    //--------------------bullet management---------------------------
    void reload(){
        basicTimeStamp = Time.time + basicAttackCooldown;
        isCooldownStarted = true;
        // start or reset the cooldown
        basicCoolDownUI.Cooldown();
        //recharge bulletCount
        bulletCount = maxBullets;
        for(int i = 0; i < maxBullets; i++){
            bulletsUI.updateColorGreen(i);
        }
    }

    void useBullet(){
        bulletCount--;
        bulletsUI.updateColorRed(bulletCount);

    }
    
}
