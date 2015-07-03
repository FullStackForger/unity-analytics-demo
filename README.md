# Step 1: Simple prototype

## About

`step-1-simple-prototype` tag contains basic application code that will be used as a foundation to enable analytics.

Take a look at documentation below to see what comes next. 

To practice integration with Unity Analytics you can follow all steps detailed in below sub-section titled [Enabling tracking manualy][etc].

To get the code from step 2 run bellow command from the console and scroll down the document to section titled **[Step 2: Game  Tracker][step2]**
```
git checkout step-2-game-tracker
```

## Enable tracking manualy
[etc]: enable-tracking-manualy

### Create Game Tracker script
Add `GameTracker.cs` script in `Assets/Scripts/Game` folder.

```
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

public class GameTracker : MonoBehaviour {

    GameMonitor Monitor { get { return GameMonitor.Instance; } }

    void Awake () {
        Analytics.CustomEvent("gameStart", new Dictionary<string, object> {
            { "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
        });
    }

    void Start () {
        AssignDelegates();
    }

    void AssignDelegates() {
        Monitor.OnLevelCompleted += HandleOnLevelCompleted;
        Monitor.OnLevelFailed += HandleOnLevelFailed;
        Monitor.OnLevelStarted += HandleOnLevelStarted;
    }

    void HandleOnLevelStarted (int levelNumber) {
        Analytics.CustomEvent("levelStart", new Dictionary<string, object> {
            { "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
        });
    }

    void HandleOnLevelFailed (int levelNumber) {
        Analytics.CustomEvent("levelFailure", new Dictionary<string, object> {
            { "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
        });
    }

    void HandleOnLevelCompleted (int levelNumber) {
        Analytics.CustomEvent("levelComplete", new Dictionary<string, object> {
            { "credits",  PlayerPrefs.GetInt(GameMonitor.CREDITS) }
        });
    }
}

```

**Note:** If you understand all the code you can skip next few paragraphs and look at section titled **[Step 2: Game  Tracker][step2]**.

#### Game Start Event with account state
Lets start with tracking Game Start Event passing it to the analytics service with user current account state. Game Analytics allows to send additional properties along with event name as a Dictionary type object.

First thing we have to do is include required dependency.
```
using System.Collections.Generic;
```

We can game start tracking code into either `Start` or `Awake` method body.

In this demo Tracker is expected to send the first tracking command before any `Start` method is called. That is why tracking is being placed into `Awake` function body.

#### Hooking into Monitor events
Monitor dispatches events when level is started, completed or failed. We want to track those game events and so we need `AssignDelegates` method that hooks into internal Monitor events.

#### Include Unity Analytics dependency
```
using UnityEngine.Analytics;
```

#### Sending Custom Events
There are just few lines of code per each Custom Event we want to send. Hence tracking code can be added directly into Monitor event handler methods.

### Add `GameTracker` object
Create empty object to the scene, name it `GameTracker` and make it a child of `GameManager`.

# Step 2: Game Tracker
[step2]: #step-2-game-tracker

## About

`step-2-game-tracker` tag contains example code of basic applicatino extended with Game Tracker functionality sending Custom Events to Unity Analytics. 

To get step 2 code you can checkout its tag running git instruction from the cmomand line.
```
git checkout step-2-game-tracker
```

## Integration validation

### Test And Validate Analytics
[ap1]: https://analytics.cloud.unity3d.com

In next step you should use [Unity Analytics Admin Panel][ap1] to validate custom events are sent correctly. 

To do that open [Unity Analytics Admin Panel][ap1], go to Projects tab, create new demo project and follow basic integration steps.

During **Test & Validate** step, after **Cloud Project Id** is configured from Unity editor Player Settings panel, run the game, navigate back to admin panel and you should be able to see first data coming through. 

**Important:** If you can't see anyting coming through go back to Player Settings window settings and double check **Disable HW Statistics** option is unchecked.

### Validating Custom Events
We have already added all the code to enable tracking custom events. In [Unity Analytics Admin Panel][ap1] you can now click **Validate Custom Events (optionsl)** link can be found in **Advanced Integration** section.

As in case of basic validation, Custom Events can be validated directly by running the game directly from the Unity Editor. 

Start the game and click *Play Level 1* button and you should see data coming through. You can send more data by clicking other buttons too. 

It is good idea to add or spend some credits before completing differnt levels of the game. Remember to fail some levels too, so those events can be tracked as well.