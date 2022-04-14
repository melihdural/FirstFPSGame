using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;

    public float speed = 1f;

    //Camera Control
    private float xRotation; //Kamera kontrol�nde a��a�� yukar� hareketi yapmak i�in kameray� hareket ettirdi�imiz i�in ayr� bir de�i�ken tan�mlar�z.
    public float mouseSensitivity = 100f;

    //Jump & Gravity
    private Vector3 velocity;
    private float gravity = -9.81f; // Yer �ekimi standart�
    
    private bool isGround;
    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;

    public float jumpHeight = 0.01f;
    public float gravityDivide = 100f;
    public float jumpSpeed = 100f;
    private float aTimer;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        
        //Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        //Check Player is Grounded
        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer); //LayerMask olmazsa kendisine de �arpt���nda true de�er verir.
                                                                                                    //Bu sebeple obstacle tagi olan nesnelerle k�s�tlad�k.
        

        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        controller.Move(moveVelocity); //Character controllera ba�l� objeyi hareket ettirir.

        //Camera Control
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0); //Karakterin y ekseni Unity uzay�nda mouseun x d�zlemdeki hareketiyle
                                                                                              //kontrol edildi�i i�in Y eksenini Mouse X e e�itliyoruz.
        
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity; // -= yapmam�z�n sebebi mouse hareketi ile ters uzay hareketi yapmas�ndan kaynakl�.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// a��a�� ve yukar� 90 derece hareket s�n�r� koymak i�in.
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // localtransform olmas�na dikkat et.



        //Jump & Gravity
        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide; //D���� sabit bir h�zda de�il ivmelenerek oldu�u i�in += yapar�z.
            aTimer += Time.deltaTime / 3;
            speed = Mathf.Lerp(10, jumpSpeed, aTimer);
        }

        else
        {
            velocity.y = -0.05f; // d���nce yere bas�m� yapmas� i�in
            speed = 20f;
            aTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivide * Time.deltaTime); //ilk de�er ne kadar z�plmas�n�n istiyorum
                      //Mathf.Sqrt Kare k�k�n� almak demektir. Form�l�n orjinali = K�k i�inde y�kseklik * -2 * yer �ekimidir.
        }
        
             
        controller.Move(velocity); //Z�plama hareketini yapabilmesi i�in a��a�� yukar� y�nl� konumu bildiren de�er velocitydir.
       



    }
}