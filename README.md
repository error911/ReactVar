# ReactVar
Reactive variables.    
Переменные с поддержкой событий.

Free license: CC BY Murnik Roman    
Tested in Unity 2019.2.X +

Входит в состав набора инструментов GGTools. Рекомендуемое расположение в проекте:    
Included in the GGTools Toolkit. Recommended location in the project:    
*Assets/GGTools/ReactVar*    
____

 ## Support types (Поддерживаемые типы)    

- [X] Generic (any type of the following)
- [X] Int
- [X] UInt
- [X] Float
- [X] Double
- [X] Bool
- [X] Vector2
- [X] Vector3
- [X] Vector4
- [X] Vector2Int
- [X] Vector3Int
- [X] Color
- [X] Quaternion

 ## Ways to declare a reactive variable (Способы объявления реактивной переменной)
```C#
    ReactVar<int> i = new ReactInt(3);
    ReactInt i2 = new ReactInt(7);
```

 ## Usage example (Пимер использования)

```C#	
using GGTools;
public class Test : MonoBehaviour
{
    // Declare an reactive variable
    // Объявляем реактивную переменную
    ReactVar<int> i = new ReactInt(3);
    
    void Start()
    {
        // Subscribe to the event of its change
        // Подписываемся на событие о ее изменении
        i.Subscribe(n=>Debug.Log("Test:" + n));
    }

    void Update()
    {
        // We try to change the variable and observe the given reaction
        // Пробуем изменить переменную и наблюдаем заданную реакцию
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i.Value++;
        }
    }
}
```
