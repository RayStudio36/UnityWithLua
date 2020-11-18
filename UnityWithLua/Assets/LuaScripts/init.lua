----------
---Libs
----------
---@class Class
_G.Class = require("libs.class.30log")

local log = require("libs.log.log")
log.usecolor = false
log.setLogHandler(log.modes.TRACE, CS.RFramework.Common.Log.RLog.Log)
log.setLogHandler(log.modes.INFO, CS.RFramework.Common.Log.RLog.Log)
log.setLogHandler(log.modes.DEBUG, CS.RFramework.Common.Log.RLog.Log)
log.setLogHandler(log.modes.WARN, CS.RFramework.Common.Log.RLog.LogWarning)
log.setLogHandler(log.modes.ERROR, CS.RFramework.Common.Log.RLog.LogError)
log.setLogHandler(log.modes.FATAL, CS.RFramework.Common.Log.RLog.LogError)
_G.Log = log

_G.Array = require("libs.array.array")
_G.Event = require("libs.event.event")
_G.StringBuilder = require("libs.string_builder.stringbuilder")
_G.Utility = require("libs.utility.utility")
_G.Pool = require("libs.pool.pool")
_G.Timer = require("libs.timer.timer")
_G.MathEx = require("libs.math.mathex")
_G.Vector2 = require("libs.math.vector2")