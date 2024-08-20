#include "extern.h"
#include <ll/api/Config.h>
#include <ll/api/command/CommandHandle.h>
#include <ll/api/command/CommandRegistrar.h>
#include <ll/api/form/CustomForm.h>
#include <mc/entity/utilities/ActorType.h>
#include <mc/server/commands/CommandOrigin.h>
#include <mc/server/commands/CommandOutput.h>
#include <mc/server/commands/CommandPermissionLevel.h>
#include <mc/server/commands/CommandSelector.h>
extern "C"{

    EXTERN void RegisterCommand(const char* cha, const char* cha1,int level,INVOKE invoke) {
    CommandPermissionLevel level_ = CommandPermissionLevel::Owner;
    switch (level) {
    case 0:
      level_ = CommandPermissionLevel::Admin;
    break;
    case 1:
    level_  = CommandPermissionLevel::Any;
    break;
    case 2:
    level_ = CommandPermissionLevel::GameDirectors;
    break;
    case 3:
    level_ = CommandPermissionLevel::Host;
    break;
    case 4:
    level_ = CommandPermissionLevel::Owner;break;
    case 5:
    level_ = CommandPermissionLevel::Internal;
    break;
    }
    auto& cmd = ll::command::CommandRegistrar::getInstance().getOrCreateCommand(cha,cha1,level_);
    cmd.overload().execute([invoke](CommandOrigin const& origin, CommandOutput& output) {
        invoke(&origin,output);
    });
 }
    EXTERN bool isPlayer(CommandOrigin* origin) {
     
            auto* entity = (*origin).getEntity();
            if (entity == nullptr || !entity->isType(ActorType::Player)) {
                
                return false;
            }
        return true;
     }
    EXTERN Player* GetPlayer(CommandOrigin* origin)
    {
        return static_cast<Player*>((*origin).getEntity());
     }
    }