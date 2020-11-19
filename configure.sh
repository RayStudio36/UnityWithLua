reconfSubmodule()
{
    rm -rf $1
    git submodule add $2 $1
}

# Change project name
read -p "Enter project name: " projname
echo "Configure for project $projname"
mv UnityWithLua "$projname"

# Init git
rm -rf .git
git init

# Reconfigure submodules
rm .gitmodules
reconfSubmodule "$projname/Packages/RFramework" https://github.com/raystudio9236/RFramework-UnityPackage.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/array" https://github.com/RayStudio36/array.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/event" https://github.com/RayStudio36/event.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/log" https://github.com/RayStudio36/log.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/string_builder" https://github.com/RayStudio36/StringBuilder.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/utility" https://github.com/yangruihan/utility.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/class" https://github.com/RayStudio36/30log.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/math" https://github.com/RayStudio36/math.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/pool" https://github.com/RayStudio36/pool.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/timer" https://github.com/RayStudio36/timer.lua.git
reconfSubmodule "$projname/Assets/LuaScripts/libs/serpent" https://github.com/RayStudio36/serpent.git
