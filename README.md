# Unity With Lua

Unity template project with Lua

## Install && Configure

```
git clone -r https://github.com/RayStudio36/UnityWithLua.git your_project_name

cd your_project_name

chmod +x ./configure.sh
./configure.sh
```

## ExampleScene

Open `Assets/Scenes/SampleScene`

## Dependency

- Unity: 2019.4.12f1

- Unity Lib

    - XLua v2.1.15 https://github.com/Tencent/xLua
    - RFramework https://github.com/raystudio9236/RFramework-UnityPackage.git

- Lua Lib

    - array.lua https://github.com/RayStudio36/array.lua.git
    - event.lua https://github.com/RayStudio36/event.lua.git
    - log.lua https://github.com/RayStudio36/log.lua.git
    - StringBuilder.lua https://github.com/RayStudio36/StringBuilder.lua.git
    - utility.lua https://github.com/yangruihan/utility.lua.git
    - 30log https://github.com/RayStudio36/30log.git
    - math.lua https://github.com/RayStudio36/math.lua.git
    - pool.lua https://github.com/RayStudio36/pool.lua.git
    - timer.lua https://github.com/RayStudio36/timer.lua.git
    - serpent https://github.com/RayStudio36/serpent.git

## Document

### Structure info

- Lua source file: `Assets/LuaScripts`

- Entry file: `Assets/LuaScripts/main.lua`

### With ECS framework

If you want to develop with ECS framework, you can use [this](https://github.com/RayStudio36/ray-ecs.lua).

1. Add submodules

    ```
    cd your_unity_project_path

    git submodule add https://github.com/RayStudio36/tiny-ecs.git Assets/LuaScripts/libs/tiny-ecs
    git submodule add https://github.com/RayStudio36/ray-ecs.lua.git Assets/LuaScripts/libs/ray-ecs
    ```

2. Add require to `init.lua`

    Add below code into `Assets/LuaScripts/init.lua` at the end.
    
    ```lua
    ----------
    ---ECS
    ----------
    _G.TinyECS = require("libs.tiny-ecs.tiny")
    local RayECS = require("libs.ray-ecs.init")
    _G.System = RayECS.System
    _G.Comp = RayECS.Comp
    _G.World = RayECS.World
    _G.Entity = RayECS.Entity
    _G.Global = RayECS.Global
    ```

## LICENSE

Copyright 2020 RayStudio9236

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.