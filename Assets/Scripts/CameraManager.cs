﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform tf; //Main CameraのTransform
    Camera cam; //Main CameraのCamera
    Rigidbody hrb; //Human（親オブジェクト）のRigidbody

    void Start()
    {
        tf = this.gameObject.GetComponent<Transform>(); //Main CameraのTransformを取得する。
        cam = this.gameObject.GetComponent<Camera>(); //Main CameraのCameraを取得する。
        hrb = transform.parent.gameObject.GetComponent<Rigidbody>(); //Human（親オブジェクト）のRigidbodyを取得する。
    }

    void FixedUpdate()
    {
        if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.UpArrow)) //上キーが押されていれば
        {
            hrb.position = hrb.position + (transform.forward * Time.deltaTime * 7.0f); //人を前進させる。
        }
        else if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.DownArrow)) //下キーが押されていれば
        {
            hrb.position = hrb.position - (transform.forward * Time.deltaTime * 7.0f); //人を後ずさりさせる。
        }
        if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.LeftArrow)) //左キーが押されていれば
        {
            hrb.position = hrb.position - (transform.right * Time.deltaTime * 7.0f); //人を左へカニ歩きさせる。
        }
        else if (!(Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.RightArrow)) //右キーが押されていれば
        {
            hrb.position = hrb.position + (transform.right * Time.deltaTime * 7.0f); //人を右へカニ歩きさせる。
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow)) //左側のShiftと上キーが押されていれば
        {
            transform.Rotate(new Vector3(-2.0f, 0.0f, 0.0f)); //カメラを上へ回転。
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.DownArrow)) //左側のShiftと下キーが押されていれば
        {
            transform.Rotate(new Vector3(2.0f, 0.0f, 0.0f)); //カメラを下へ回転。
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow)) //左側のShiftと左キーが押されていれば
        {
            transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f)); //カメラを左へ回転。
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow)) //左側のShiftと右キーが押されていれば
        {
            transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f)); //カメラを右へ回転。
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.R)) //左側のShiftとRキーが押されていれば
        {
            tf.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f); //カメラの回転をリセットする。
        }
    }
}