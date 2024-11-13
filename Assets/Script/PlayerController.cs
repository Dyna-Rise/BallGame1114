using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody; //Rigidbody2Dコンポーネントを参照する変数
    public float jumpPower; //ジャンプパワー
    bool isObject; //物体との接触判定
    bool isJump; //ジャンプボタンが押された判定

    public static string gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = "Playing";
        rbody = GetComponent<Rigidbody2D>(); //変数rbodyがPlayerのRigidbody2Dを参照
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")){ 
                Jump();
        }
    }

    void FixedUpdate()
    {
        if (isJump && isObject)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpPower);
            isJump = false;
        }
    }

    void Jump()
    {
        isJump = true;
    }

    void GameClear()
    {
        GravityStop();
        gameStatus = "GameClear";
        Debug.Log("GameClear");
    }

    void GameOver()
    {
        GravityStop();
        gameStatus = "GameOver";
        Debug.Log("GameOver");
    }

    void GravityStop()
    {
        rbody.gravityScale = 0; //Rigidbody2Dの重力を0に
        rbody.velocity = Vector2.zero; //加速を止める Vetor2.zero は new Vector2(0,0)と同じ
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isObject = true;
        Debug.Log(isObject);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isObject = false;
        Debug.Log(isObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            GameClear();
        }

        else if(collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }
}
