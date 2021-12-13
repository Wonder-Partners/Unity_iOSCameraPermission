// Attach this script to the gameobject that will be clicked to call VerifyPermission().
// Ex. Attach to a UI.Button, and set OnClick to VerifyPermission();

using UnityEngine;
using UnityEngine.UI;

public class UsageSample : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;

    public void AskPermission()
    {
        // Display some sort of thinking message to the user.
        _text.text = "Asking camera permission...";

        // Disable the button while verifying permission.
        _button.interactable = false;

        // Use native UI to request camera permission.
        iOSCameraPermission.VerifyPermission(gameObject.name, nameof(AskCallback));
    }

    public void VerifyPermission()
    {
        iOSCameraPermission.VerifyPermission(gameObject.name, nameof(VerifyCallback));
    }

    void AskCallback(string permissionWasGranted)
    {
        Debug.Log("Callback.permissionWasGranted = " + permissionWasGranted);

        if (permissionWasGranted == "true")
        {
            // You can now use the device camera.
            _text.text = "You can now use the camera";
        }
        else
        {
            // You cannot use the device camera.  You may want to display a message to the user
            // about changing the camera permission in the Settings app.
            _text.text = "Please active camera access in Settings.";

            // You may want to re-enable the button to display the Settings message again.
            _button.interactable = true;
        }
    }

    void VerifyCallback(string authorizationStatus)
    {
        Debug.Log($"Authorization status: {authorizationStatus}");
        _text.text = authorizationStatus;
    }
}

// MIT License
//
// Copyright (c) 2021 Wonder Partner's
// www.wonder-partners.com
//
// Copyright (c) 2018 Cory Butler
// www.CoryButler.com
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
