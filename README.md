# Unity_iOSCameraPermission
Request native iOS camera permissions and get a callback method in Unity.

## Installation

Download the latest `ios_camera_permission.unitypackage` file from the *Release* page, drag and drop it in your project folder and click *import*.

## Prerequisites

- You must set a Camera Usage Description in the Player Settings.


## Usage/Examples
If you want to ask camera permission and display the native iOS popup, call `AskPermission()`.

The method signature is `AskPermission(string gameObjectName, string callbackName)` where `gameObjectName ` is the name of the game object that will receive the callback via the Unity's build-in `SendMessage()` method. `callbackName` is the name of the method to call on the gameObject.

> Note: It is recommended to use `nameof(MyMethod)` in the `callbackName ` parameter to avoid errors when renaming or changing the callbacks.

```csharp
public void AskPermission()
{
    iOSCameraPermission.AskPermission(gameObject.name, nameof(AskCallback));
}

void AskCallback(string permissionWasGranted)
{
    // permissionWasGranted will either be "true" or "false".
}
```

If you just want to verify the current permission for your app (useful to avoid asking when the permission is already granted), you can call `VerifyPermision()`. The method signature and callbacks are the same as `AskPermission()`.

```csharp
public void VerifyPermission()
{
    iOSCameraPermission.VerifyPermission(gameObject.name, nameof(VerifyCallback));
}

void VerifyCallback(string authorizationStatus)
{
    // authorizationStatus will be one of the following:
    // - Authorized
    // - Denied
    // - NotDetermined
    // - Restricted
}
```

## Plugin directory structure

All .h and .m files must be in the follow location:

`[ProjectName]/Assets/Plugins/iOS`

## Usage Sample
See `Assets/iOSCameraPermission/Samples/SampleScene.unity`

Each one of the two buttons in the scene has a `UsageSample` component and its `OnClick()` callback set to one of the two available methods.

Camera Usage Description is set to "Sample Camera Usage Description"
