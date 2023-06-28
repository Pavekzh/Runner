using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SignUpController:MonoBehaviour
{
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField repeatPassword;
    [SerializeField] private Button signUp;
    [SerializeField] private Button logIn;

}
