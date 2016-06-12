//注意！！！！！
//移动由物理系统控制，位移大小由Input.GetAxis("Horizontal")和Input.GetAxis("Vertical")控制
//最好在Edit->Player Settings->Input中将Horizontal和Vertical的Gravity设置为10，Sensitivity设置为1000，这样能够保证最好的移动效果，避免延迟
//或者你可以使用其他方式实现

using UnityEngine;
using System.Collections;

public class Move8Direction : MonoBehaviour
{

    //enum Direction
    //{
    //    None,
    //    UpLeft,
    //    Up,
    //    UpRight,
    //    Left,
    //    Right,
    //    DownLeft,
    //    Down,
    //    DownRight
    //}
    //Direction dir;

    float xOffset;
    float yOffset;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    SpriteFrames SF;
    Rigidbody2D R2D;

    void Start()
    {
        SF = GetComponent<SpriteFrames>();
        R2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xOffset = Input.GetAxis("Horizontal");
        yOffset = Input.GetAxis("Vertical");
        //transform.position += (Vector3)checkDirection() * Time.deltaTime * 200 ;
        //debugMove();
    }

    void FixedUpdate()
    {
        fixPlayerPosition();
    }

    void fixPlayerPosition()
    {
        R2D.velocity = checkDirection() * Time.deltaTime * 150;
        Vector3 pos = R2D.position;
        if (pos.y > maxY)
        {
            pos.y = maxY;
        }
        else if (pos.y < minY)
        {
            pos.y = minY;
        }
        if (pos.x < minX)
        {
            pos.x = minX;
        }
        else if (pos.x > maxX)
        {
            pos.x = maxX;
        }
        R2D.position = pos;
    }

    Vector2 checkDirection()
    {
        if (yOffset > 0 && xOffset < 0)
        {
            //dir = Direction.UpLeft;
            SF.curClip = 6;
        }
        else if (yOffset > 0 && xOffset == 0)
        {
            //dir = Direction.Up;
            SF.curClip = 3;
        }
        else if (yOffset > 0 && xOffset > 0)
        {
            //dir = Direction.UpRight;
            SF.curClip = 7;
        }
        else if (xOffset < 0 && yOffset == 0)
        {
            //dir = Direction.Left;
            SF.curClip = 1;
        }
        else if (xOffset == 0 && yOffset == 0)
        {
            //dir = Direction.None;
            SF.isPlay = false;
            return Vector2.zero;
        }
        else if (xOffset > 0 && yOffset == 0)
        {
            //dir = Direction.Right;
            SF.curClip = 2;
        }
        else if (yOffset < 0 && xOffset < 0)
        {
            //dir = Direction.DownLeft;
            SF.curClip = 4;
        }
        else if (yOffset < 0 && xOffset == 0)
        {
            //dir = Direction.Down;
            SF.curClip = 0;
        }
        else if (yOffset < 0 && xOffset > 0)
        {
            //dir = Direction.DownRight;
            SF.curClip = 5;
        }
        SF.isPlay = true;
        Vector2 moveOffset = new Vector2(Mathf.RoundToInt(xOffset), Mathf.RoundToInt(yOffset));
        return moveOffset;
    }

    void debugMove()
    {
        Debug.Log("x:" + xOffset + ",y:" + yOffset);
    }
}
