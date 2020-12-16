using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class UserInfo 
{
    public string access_token;
    public info user;

}
[System.Serializable]
public class info
{
    public int Id;
    public string Login;
    public string Password;
    public string Name;
    public string Surname;
    public string Role;
}