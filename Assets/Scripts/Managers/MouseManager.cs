using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseManager
{
    public static void Show(bool isHide)
    {
        Cursor.visible = isHide;
    }

    public static void Lock(bool isLock)
    {
        Cursor.lockState = isLock ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
