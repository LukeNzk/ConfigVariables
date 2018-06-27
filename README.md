# ConfigVariables

Declaration
```C#
        static CVar<float> cvSpeed = new CVar<float>("speed", 0.0f);
        static CVar<byte> cvSthElse = new CVar<byte>("someVar", 3);
        static CVar<string> cvSomeString = new CVar<string>("name", "");
        static CVar<int> cvEnemiesCount = new CVar<int>("nEnemies", 0);
        static CVar<string> cvCharacterLocation = new CVar<string>("loc", "limbo");
```

Usage

```C#
float speed = cvSpeed.GetValue();
```