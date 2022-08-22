using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour{
    private bool _isForward;
    private bool _isBackward;
    private bool _isLeft;
    private bool _isRight;

    public bool IsForward => _isForward;
    public bool IsBackward => _isForward;
    public bool IsLeft => _isLeft;
    public bool IsRight => _isRight;

    public bool isTalking;


    // Start is called before the first frame update
    void Start(){
        _isForward = false;
        _isBackward = false;
        _isLeft = false;
        _isRight = false;
        isTalking = false;
    }

    // Update is called once per frame
    void Update(){
        UpdateKeyInput();
    }

    void UpdateKeyInput(){
        if (Input.GetKey(KeyCode.W)){
            _isForward = true;
            _isBackward = false;
            DisableHorizontalInput();
        }

        if (Input.GetKey(KeyCode.S)){
            _isForward = false;
            _isBackward = true;
            DisableHorizontalInput();
        }

        if (Input.GetKey(KeyCode.A)){
            _isRight = true;
            _isLeft = false;
            DisableVerticalInput();
        }

        if (Input.GetKey(KeyCode.A)){
            _isRight = false;
            _isLeft = true;
            DisableVerticalInput();
        }
    }

    void DisableVerticalInput(){
        _isForward = false;
        _isBackward = false;
    }

    void DisableHorizontalInput(){
        _isRight = false;
        _isLeft = false;
    }
}
