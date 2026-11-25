# Design Patterns

Small C# console projects that practice classic design patterns. Each project shows the code **before** (commented out) and **after** applying the pattern.

| Project | Pattern | Example |
| --- | --- | --- |
| `BuidlerDesignPattern` | Builder | Building a `Computer` with optional parts instead of a long constructor |
| `DecoratorDesignPattern` | Decorator | Stacking Email, SMS and Slack notifications instead of subclass combinations |
| `FactoryDesignPattern` | Factory | Creating Email, SMS and Push notifications without `if/else` chains |
| `SingletonDesignPattern` | Singleton | Eager, lazy and lock-based (thread-safe) implementations |

## Run

Requires the .NET SDK. Run any project on its own:

```bash
cd FactoryDesignPattern
dotnet run
```
