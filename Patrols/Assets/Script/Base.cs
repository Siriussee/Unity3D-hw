using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneController
{
    void LoadResource();
}

public interface IUserAction
{
    int GetScore();
    bool GetGameOver();
    void Restart();
}

public interface ISSActionCallback
{
    void SSActionEvent(SSAction source, int intParamameter = 0, GameObject objectParameter = null);

}
