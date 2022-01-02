using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeStick : MonoBehaviour
{
    public int max_z;
    public int max_x;
    int x, z, r;

    Object wall;
    GameObject wallgo;

    // Start is called before the first frame update
    void Start()
    {
        int[,] field = new int[max_z, max_x];   // フィールド(0が通路、1が壁)
        wall = Resources.Load("Wall");

        for(z = 0; z < max_z; z++)
        {
            for(x = 0; x < max_x; x++)
            {
                field[z, x] = 0;
            }
        }

        // 上下の壁の作成
        for(x = 0; x < max_x; x++)
        {
            field[0, x] = 1;
            field[max_z - 1, x] = 1;
        }
        // 左右の壁の作成
        for(z = 0; z < max_z; z++)
        {
            field[z, 0] = 1;
            field[z, max_z - 1] = 1;
        }

        // 棒倒し法
        z = 2;
        for(x = 2; x < max_x - 1; x += 2)
        {
            r = Random.Range(1, 13);
            field[z, x] = 1;
            if(r <= 3)
            {
                if(field[z-1,x] == 0)
                {
                    field[z - 1, x] = 1;
                }
                else if(field[z - 1, x] == 1)
                {
                    x -= 2;
                }
            }
            if(r >= 4 && r <= 6)
            {
                if(field[z+1, x] == 0)
                {
                    field[z + 1, x] = 1;
                }
                else if(field[z + 1, x] == 1)
                {
                    x -= 2;
                }
            }

            if (r >= 7 && r <= 9) //rが7から9のとき
            {
                if (field[z, x - 1] == 0) //左に棒（壁）がなければ
                {
                    field[z, x - 1] = 1; //左に棒を倒す。
                }
                else if (field[z, x - 1] == 1) //左に棒（壁）があれば
                {
                    x = x - 2; //棒を倒さずに、乱数生成をやり直す。
                }
            }
            if(r >= 10)
            {
                if (field[z, x + 1] == 0) //右に棒（壁）がなければ
                {
                    field[z, x + 1] = 1; //右に棒を倒す。
                }
                else if (field[z, x + 1] == 1) //右に棒（壁）があれば
                {
                    x = x - 2; //棒を倒さずに、乱数生成をやり直す。
                }
            }
        }

        for (z = 4; z < max_z - 1; z = z + 2) //zの要素番号4から要素番号max_z-1まで、1マス飛ばしで棒倒し。
        {
            for (x = 2; x < max_x - 1; x = x + 2) //xの要素番号2から要素番号max_x-1まで、1マス飛ばしで棒倒し。
            {
                r = Random.Range(1, 13); //乱数生成（r = 1から12のランダムな値）
                field[z, x] = 1; //中心から……
                if (r <= 4) //rが4以下のとき
                {
                    if (field[z + 1, x] == 0) //下に棒（壁）がなければ
                    {
                        field[z + 1, x] = 1; //下に棒を倒す。
                    }
                    else if (field[z + 1, x] == 1) //下に棒（壁）があれば
                    {
                        x = x - 2; //棒を倒さずに、乱数生成をやり直す。
                    }
                }
                if (r >= 5 && r <= 8) //rが5から8のとき
                {
                    if (field[z, x - 1] == 0) //左に棒（壁）がなければ
                    {
                        field[z, x - 1] = 1; //左に棒を倒す。
                    }
                    else if (field[z, x - 1] == 1) //左に棒（壁）があれば
                    {
                        x = x - 2; //棒を倒さずに、乱数生成をやり直す。
                    }
                }
                if (r >= 9) //rが9以上のとき
                {
                    if (field[z, x + 1] == 0) //右に棒（壁）がなければ
                    {
                        field[z, x + 1] = 1; //右に棒を倒す。
                    }
                    else if (field[z, x + 1] == 1) //右に棒（壁）があれば
                    {
                        x = x - 2; //棒を倒さずに、乱数生成をやり直す。
                    }
                }
            }
        }

        field[0, 1] = 0; //スタート地点の壁を撤去する。
        field[max_z - 1, max_x - 2] = 0; //ゴール地点の壁を撤去する。

        //壁の配置
        for (z = 0; z < max_z; z = z + 1) //フィールドの縦幅の分だけループする。
        {
            for (x = 0; x < max_x; x = x + 1) //フィールドの横幅の分だけループする。
            {
                if (field[z, x] == 0) //通路なら
                {
                    //何も配置しない。
                }
                else if (field[z, x] == 1) //壁なら
                {
                    wallgo = (GameObject)Instantiate(wall, new Vector3(5.0f * x, 5.0f, 5.0f * z), Quaternion.identity); //壁を配置する。
                }
            }
        }
    }
}