using UnityEngine;

public class InstructionWindow : MonoBehaviour
{
    public GameObject instructionWindow; // The instruction window

    void Start()
    {
        ShowInstructionWindow();
    }

    public void ShowInstructionWindow()
    {
        // Show the instruction window
        instructionWindow.SetActive(true);
    }

    public void HideInstructionWindow()
    {
        // Hide the instruction window
        instructionWindow.SetActive(false);
    }
}