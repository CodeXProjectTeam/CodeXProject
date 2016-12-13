using UnityEngine;
using System.Collections;
using LuaInterface;
using System;

public class LuaManager  
{
    static LuaState state = new LuaState();

    public static void Init()
    {
        try 
        {
            state.Start();
            //LuaBinder.Bind(state);

            state.DoString("print('hello world')","test.lua");
        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }

        ApplicationManager.s_OnApplicationUpdate += Update;   
    }

    static void Update()
    {

    }

    public static void DoLuaFile(string fileName)
    {
        string content = ResourceManager.ReadTextFile(fileName);
        state.DoString(content, fileName);
    }
}
