# S07PAV — Semana 7

**Programación Aplicada a Videojuegos** · 2.º ciclo · C26S
Sesión 7: *Polimorfismo aplicado a gameplay*

Solución del laboratorio **Hechizos de bolsillo: cinco habilidades, un solo botón**
(hitos base). El jugador elige una habilidad con las teclas 1–5 y la lanza con click
izquierdo contra un muñeco. El Player solo conoce `BaseAbility` y llama a
`current.Execute()`: no hay ningún `if` ni `switch` sobre qué habilidad es.

```
Input (Abilities)  --->  Player  --->  BaseAbility.Execute()  --->  Projectile  --->  Dummy.ApplyStatus(...)
teclas 1-5 y click       current       Fire / Ice / Poison /        velocidad y        Debug.Log del estado
                                       Lightning / Slow             estado             (sobrecarga)
```

| Hito | Dónde está |
|---|---|
| 1️⃣ Action Map `Abilities` | `InputSystem_Actions.inputactions` (Ability1–Ability5, Cast) y `Player.cs` |
| 2️⃣ `abstract` y `override` | `BaseAbility.Execute()` y las cinco hijas |
| 3️⃣ `virtual` y `base` con Feel | `BaseAbility.PlayFeedback()`, sobrescrito en `IceAbility` y `LightningAbility` |
| 4️⃣ `enum` y sobrecarga | `StatusEffect.cs` y las dos `Dummy.ApplyStatus(...)` |

## Antes de abrir: Feel o MMFeedbacks

El proyecto usa `MMFeedbacks` y **no compila sin él**. No viene en el repositorio porque
su licencia no permite redistribuirlo. Importa uno de los dos:

- **Feel** (de pago), desde el Package Manager → *My Assets*.
- **MMFeedbacksPublic** (gratis): <https://github.com/reunono/MMFeedbacksPublic>. En
  Unity 6 borra `MMFeedbacksForThirdParty/` y `MMFeedbacks/Shakers/MMCameraZoom.cs`.

Un campo `MMFeedbacks` acepta tanto un `MMFeedbacks` como un `MMF_Player` de Feel.

## Montaje

Unity 6 (`6000.3.9f1`), escena 2D vacía. No hay escena en el repo a propósito.

1. **Proyectil (prefab):** un Sprite (círculo) con `Rigidbody2D` (Gravity Scale 0),
   `CircleCollider2D` con **Is Trigger** y `Projectile`. Crea cinco, uno por habilidad,
   con distinto color o tamaño, y guárdalos como prefab.
2. **Dummy:** un Sprite en (5, 0, 0) con `BoxCollider2D` y `Dummy`.
3. **Player:** un Sprite en (0, 0, 0) con `Player` y las cinco habilidades
   (`FireAbility`, `IceAbility`, `PoisonAbility`, `LightningAbility`, `SlowAbility`).
   En cada habilidad arrastra su prefab a *Projectile Prefab*, el propio Player a
   *Fire Point* y un feedback a *Cast Feedback*.
4. **Feedbacks:** GameObjects con `MMF_Player` (o `MMFeedbacks`). Para el lanzamiento, por
   ejemplo *Scale* o *Camera Shake*. Para las partículas de `IceAbility` y
   `LightningAbility`, un `ParticleSystem` y un feedback *Particles Play* en su
   *Particles Feedback*.
5. En `Player > Abilities` arrastra las cinco habilidades en orden: 1 fuego, 2 hielo,
   3 veneno, 4 rayo, 5 lentitud.

Con la consola abierta: la tecla escribe `Habilidad: IceAbility` y el impacto,
`Dummy recibe Freeze durante 2 s`. El rayo usa la otra sobrecarga: `Dummy recibe Shock`.

## Verificado

Unity 6000.3.9f1, 0 errores y 0 avisos. Las cinco habilidades se probaron en Play con
un teclado y un ratón virtuales: cada tecla elige la suya y cada impacto imprime su
estado.
