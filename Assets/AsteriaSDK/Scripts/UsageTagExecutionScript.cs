using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExecutionScript
{
    void Execute(UnitStats caster, UnitStats target);
}

[System.Serializable]
public class ExecutionScriptWrapper
{
    public UsageTagExecutionScript script;
}

[System.Serializable]
public class UsageTagExecutionScript : MonoBehaviour, IExecutionScript
{
    void IExecutionScript.Execute(UnitStats caster, UnitStats target)
    {

    }
}