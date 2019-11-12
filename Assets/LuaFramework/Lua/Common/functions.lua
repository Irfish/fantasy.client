--输出日志 --
function log(str)
    Util.Log(str)
end

--错误日志 --
function logError(str)
    Util.LogError(str)
end

--警告日志 --
function logWarn(str)
    Util.LogWarning(str)
end

--查找对象 --
function find(str)
    return GameObject.Find(str)
end

function destroy(obj)
    GameObject.Destroy(obj)
end

function newObject(prefab)
    return GameObject.Instantiate(prefab)
end

--创建面板 --
function createPanel(name)
    PanelManager:CreatePanel(name)
end

function child(str)
    return transform:FindChild(str)
end

function subGet(childNode, typeName)
    return child(childNode):GetComponent(typeName)
end

function findPanel(str)
    local obj = find(str)
    if obj == nil then
        error(str .. ' is null')
        return nil
    end
    return obj:GetComponent('BaseLua')
end

function Split(szFullString, szSeparator)
    local nFindStartIndex = 1
    local nSplitIndex = 1
    local nSplitArray = {}
    while true do
        local nFindLastIndex = string.find(szFullString, szSeparator, nFindStartIndex)
        if not nFindLastIndex then
            nSplitArray[nSplitIndex] = string.sub(szFullString, nFindStartIndex, string.len(szFullString))
            break
        end
        nSplitArray[nSplitIndex] = string.sub(szFullString, nFindStartIndex, nFindLastIndex - 1)
        nFindStartIndex = nFindLastIndex + string.len(szSeparator)
        nSplitIndex = nSplitIndex + 1
    end
    return nSplitArray
end
