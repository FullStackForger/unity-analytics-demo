# Step 1: Simple prototype

## About

`step-1-simple-prototype` tag contains basic application code that will be used as a foundation to enable Unity Analytics. You can get code from step one by running git command: 
```
git checkout step-1-simple-prototype
```

To practice integration with Unity Analytics follow section [Enabling tracking manualy][etc].

If you prefer to get complete code run bellow git command and once done scroll down to **Step 2: Game  Tracker**
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

> **Note:** If you understand all the code you can skip next few paragraphs
> and look at section titled **[Step 2: Game  Tracker][step2]**.

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
