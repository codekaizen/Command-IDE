using Microsoft.VisualBasic.FileIO;
using AutocompleteMenuNS;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Command___IDE
{
    public static class MCP_Init
    {
        public static List<string> mineitems = new List<string>();
        public static List<AutocompleteItem> mineAuto = new List<AutocompleteItem>();

        public static void Init()
        {
            TextFieldParser t = new TextFieldParser(Application.ExecutablePath + "/../items.tsv");
            t.TextFieldType = FieldType.Delimited;
            t.Delimiters = new[] { "\t" };
            while (!t.EndOfData)
            {
                string[] s = t.ReadFields();
                if (s.Length == 4 && !mineitems.Contains(s[3]))
                {
                    mineitems.Add(s[3]);
                    if (mineitems.Count <= 250)
                    {
                        mineAuto.Add(new AutocompleteItem(s[3], 3));
                    }
                    else
                    {
                        mineAuto.Add(new AutocompleteItem(s[3], 2));
                    }
                }
            }


            List<Command> commandQue = new List<Command>();
            commandQue.Add(new Command
            {
                name = "advancement",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "grant", "revoke", "test" } },
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "advancement", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(1, "test") } },
                    new Parameter { name = "criterion", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(1, "test") } },
                    new Parameter { name = "grant", ParamType = ParamType.Fixed, possibleValues = new[] { "only", "until", "from", "through", "everything" }, dependancy = new[] {new KeyValuePair<int, string>(1, "grant") } },
                    new Parameter { name = "grant", ParamType = ParamType.Fixed, possibleValues = new[] { "only", "until", "from", "through", "everything" }, dependancy = new[] {new KeyValuePair<int, string>(1, "revoke") } },
                    new Parameter { name = "advancement", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "only") } },
                    new Parameter { name = "criterion", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "only") } },
                    new Parameter { name = "advancement", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "until") } },
                    new Parameter { name = "criterion", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "until") } },
                    new Parameter { name = "advancement", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "from") } },
                    new Parameter { name = "criterion", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "from") } },
                    new Parameter { name = "advancement", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "through") } },
                    new Parameter { name = "criterion", ParamType = ParamType.Alphanumeric, dependancy = new[] {new KeyValuePair<int, string>(3, "through") } },
                }
            });
            commandQue.Add(new Command
            {
                name = "blockdata",
                parameters = new[] {
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "clear",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "item", ParamType = ParamType.Item },
                    new Parameter { name = "data", ParamType = ParamType.Numeric },
                    new Parameter { name = "maxCount", ParamType = ParamType.Numeric },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "clone",
                parameters = new[] {
                    new Parameter { name = "x1", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y1", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z1", ParamType = ParamType.Coordinate },
                    new Parameter { name = "x2", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y2", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z2", ParamType = ParamType.Coordinate },
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "maskMode", ParamType = ParamType.Fixed, possibleValues = new[] { "filtered","masked","replace" } },
                    new Parameter { name = "cloneMode", ParamType = ParamType.Fixed, possibleValues = new[] { "force","move","normal" } },
                    new Parameter { name = "block", ParamType = ParamType.Block },
                    new Parameter { name = "state", ParamType = ParamType.Numeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "defaultgamemode",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "difficulty",
                parameters = new[] {
                    new Parameter { name = "difficulty", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "effect",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "effect/clear", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "seconds", ParamType = ParamType.Numeric },
                    new Parameter { name = "amplifier", ParamType = ParamType.Numeric },
                    new Parameter { name = "hideParticles", ParamType = ParamType.Boolean }
                }
            });
            commandQue.Add(new Command
            {
                name = "enchant",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "enchantmentID", ParamType = ParamType.Numeric },
                    new Parameter { name = "level", ParamType = ParamType.Numeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "entitydata",
                parameters = new[] {
                    new Parameter { name = "entity", ParamType = ParamType.Player },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "execute",
                parameters = new[] {
                    new Parameter { name = "entity", ParamType = ParamType.Player },
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "command", ParamType = ParamType.Command, possibleValues = new[] { "detect" } },
                    new Parameter { name = "x1", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate, dependancy = new[] {new KeyValuePair<int, string>(5, "detect") } },
                    new Parameter { name = "y1", ParamType = ParamType.Coordinate, dependancy = new[] {new KeyValuePair<int, string>(5, "detect") } },
                    new Parameter { name = "z1", ParamType = ParamType.Coordinate, dependancy = new[] {new KeyValuePair<int, string>(5, "detect") } },
                    new Parameter { name = "block", ParamType = ParamType.Block, dependancy = new[] {new KeyValuePair<int, string>(5, "detect") } },
                    new Parameter { name = "state", ParamType = ParamType.Numeric, dependancy = new[] {new KeyValuePair<int, string>(5, "detect") } },
                    new Parameter { name = "command", ParamType = ParamType.Command, dependancy = new[] {new KeyValuePair<int, string>(5, "detect") } },
                }
            });
            commandQue.Add(new Command
            {
                name = "fill",
                parameters = new[] {
                    new Parameter { name = "x1", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y1", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z1", ParamType = ParamType.Coordinate },
                    new Parameter { name = "x2", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y2", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z2", ParamType = ParamType.Coordinate },
                    new Parameter { name = "block", ParamType = ParamType.Block },
                    new Parameter { name = "state", ParamType = ParamType.Numeric },
                    new Parameter { name = "oldBlockHandling", ParamType = ParamType.Fixed, possibleValues = new[] { "destroy", "hollow", "keep","outline", "replace" } },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "function",
                parameters = new[] {
                    new Parameter { name = "function", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "ifwhat", ParamType = ParamType.Fixed, possibleValues = new[] { "if", "unless" } },
                    new Parameter { name = "selector", ParamType = ParamType.Player }
                }
            });
            commandQue.Add(new Command
            {
                name = "gamemode",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "player", ParamType = ParamType.Player }
                }
            });
            commandQue.Add(new Command
            {
                name = "gamerule",
                parameters = new[] {
                    new Parameter { name = "rule", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "value", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "give",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "item", ParamType = ParamType.Item },
                    new Parameter { name = "amount", ParamType = ParamType.Numeric },
                    new Parameter { name = "data", ParamType = ParamType.Numeric },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "help",
                parameters = new[] {
                    new Parameter { name = "page/command", ParamType = ParamType.Command }
                }
            });
            commandQue.Add(new Command
            {
                name = "kill",
                parameters = new[] {
                    new Parameter { name = "entity", ParamType = ParamType.Player }
                }
            });
            commandQue.Add(new Command
            {
                name = "list",
                parameters = new[] {
                    new Parameter { name = "uuids", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "locate",
                parameters = new[] {
                    new Parameter { name = "structureType", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "me",
                parameters = new[] {
                    new Parameter { name = "message", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "msg",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "message", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "particle",
                parameters = new[] {
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "xd", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "yd", ParamType = ParamType.Coordinate },
                    new Parameter { name = "zd", ParamType = ParamType.Coordinate },
                    new Parameter { name = "speed", ParamType = ParamType.Numeric },
                    new Parameter { name = "count", ParamType = ParamType.Numeric },
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "normal", "force" } },
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "parameter", ParamType = ParamType.Numeric },
                    new Parameter { name = "parameter2", ParamType = ParamType.Numeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "playsound",
                parameters = new[] {
                    new Parameter { name = "sound", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "source", ParamType = ParamType.Fixed, possibleValues = new[] { "master", "music", "record", "weather", "block", "hostile", "neutral", "player", "ambient", "voice" } },
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "x", ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "volume", ParamType = ParamType.Numeric },
                    new Parameter { name = "pitch", ParamType = ParamType.Numeric },
                    new Parameter { name = "minimumVolume", ParamType = ParamType.Numeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "publish"
            });
            commandQue.Add(new Command
            {
                name = "recipe",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "give", "take" } },
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "reload"
            });
            commandQue.Add(new Command
            {
                name = "replaceitem",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "block", "entity" } },
                    new Parameter { name = "x", ParamType = ParamType.Coordinate, possibleValues = new[] { "fillCords" }, dependancy = new[] { new KeyValuePair<int,string>(1, "block") } },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate, dependancy = new[] { new KeyValuePair<int,string>(1, "block") } },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate, dependancy = new[] { new KeyValuePair<int,string>(1, "block") } },
                    new Parameter { name = "selector", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int,string>(1, "entity") } },
                    new Parameter { name = "slot", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "item", ParamType = ParamType.Item },
                    new Parameter { name = "data", ParamType = ParamType.Numeric },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "say",
                parameters = new[] {
                    new Parameter { name = "message", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "scoreboard",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "objectives", "players", "teams" } },
                    new Parameter { name = "dowhat_objective", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "objectives") }, possibleValues = new[] { "list", "add", "remove", "setdisplay" } },
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "objectives"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "criteria", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "objectives"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "objectives"), new KeyValuePair<int, string>(2, "remove") } },
                    new Parameter { name = "slot", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "objectives"), new KeyValuePair<int, string>(2, "setdisplay") } },
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "objectives"), new KeyValuePair<int, string>(2, "setdisplay") } },
                    //
                    //PLAYS
                    //
                    new Parameter { name = "dowhat_players", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "players") }, possibleValues = new[] { "list", "set", "add", "remove", "reset", "enable", "test", "operation", "tag" } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "list") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "set") } },
                    new Parameter { name = "objective", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "set") } },
                    new Parameter { name = "score", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "set") } },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "set") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "objective", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "score", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "remove") } },
                    new Parameter { name = "objective", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "remove") } },
                    new Parameter { name = "score", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "remove") } },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "remove") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "reset") } },
                    new Parameter { name = "objective", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "reset") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "enable") } },
                    new Parameter { name = "trigger", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "enable") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "test") } },
                    new Parameter { name = "objective", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "test") } },
                    new Parameter { name = "min", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "test") } },
                    new Parameter { name = "max", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "test") } },
                    new Parameter { name = "targetName", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "operation") } },
                    new Parameter { name = "targetObjective", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "operation") } },
                    new Parameter { name = "operation", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "operation") } },
                    new Parameter { name = "selector", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "operation") } },
                    new Parameter { name = "objective", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "operation") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "tag") } },
                    new Parameter { name = "dowhat_tag", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "tag") }, possibleValues = new[] { "list", "add", "remove" } },
                    new Parameter { name = "tagName", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "tag"), new KeyValuePair<int, string>(4, "add") } },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "tag"), new KeyValuePair<int, string>(4, "add") } },
                    new Parameter { name = "tagName", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "tag"), new KeyValuePair<int, string>(4, "remove") } },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int, string>(1, "players"), new KeyValuePair<int, string>(2, "tag"), new KeyValuePair<int, string>(4, "remove") } },
                    //
                    //TEAMS
                    //
                    new Parameter { name = "dowhat_teams", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "teams") }, possibleValues = new[] { "list", "add", "remove", "empty", "join", "leave", "option" } },
                    new Parameter { name = "teamname", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "list") } },
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "displayName", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "add") } },
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "remove") } },
                    new Parameter { name = "name", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "empty") } },
                    new Parameter { name = "team", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "join") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "join") } },
                    new Parameter { name = "player", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "leave") } },
                    new Parameter { name = "team", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option") } },
                    new Parameter { name = "dowhat_teams", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option") }, possibleValues = new[] { "color", "friendlyFire", "seeFriendlyInvisibles", "nametagVisibility", "deathMessageVisibility", "collisionRule" } },
                    new Parameter { name = "color", ParamType = ParamType.Alphanumeric, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option"), new KeyValuePair<int, string>(4, "color") } },
                    new Parameter { name = "friendlyFire", ParamType = ParamType.Boolean, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option"), new KeyValuePair<int, string>(4, "friendlyFire") } },
                    new Parameter { name = "seeFriendlyInvisibles", ParamType = ParamType.Boolean, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option"), new KeyValuePair<int, string>(4, "seeFriendlyInvisibles") } },
                    new Parameter { name = "nametagVisibility", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option"), new KeyValuePair<int, string>(4, "nametagVisibility") }, possibleValues = new[] { "never", "hideForOtherTeams", "hideForOwnTeam", "always" } },
                    new Parameter { name = "deathMessageVisibility", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option"), new KeyValuePair<int, string>(4, "deathMessageVisibility") }, possibleValues = new[] { "never", "hideForOtherTeams", "hideForOwnTeam", "always" } },
                    new Parameter { name = "collisionRule", ParamType = ParamType.Fixed, dependancy = new[] { new KeyValuePair<int, string>(1, "teams"), new KeyValuePair<int, string>(2, "option"), new KeyValuePair<int, string>(4, "collisionRule") }, possibleValues = new[] { "never", "pushOtherTeams", "pushOwnTeam", "always" } }
                }
            });
            commandQue.Add(new Command
            {
                name = "seed"
            });
            commandQue.Add(new Command
            {
                name = "setblock",
                parameters = new[] {
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "block", ParamType = ParamType.Block },
                    new Parameter { name = "state", ParamType = ParamType.Numeric },
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "destroy", "keep", "replace" } },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "setworldspawn",
                parameters = new[] {
                        new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                        new Parameter { name = "y", ParamType = ParamType.Coordinate },
                        new Parameter { name = "z", ParamType = ParamType.Coordinate }
                }
            });
            commandQue.Add(new Command
            {
                name = "spawnpoint",
                parameters = new[] {
                        new Parameter { name = "player", ParamType = ParamType.Player },
                        new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                        new Parameter { name = "y", ParamType = ParamType.Coordinate },
                        new Parameter { name = "z", ParamType = ParamType.Coordinate }
                }
            });
            commandQue.Add(new Command
            {
                name = "spreadplayers",
                parameters = new[] {
                        new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                        new Parameter { name = "z", ParamType = ParamType.Coordinate },
                        new Parameter { name = "spreadDistance", ParamType = ParamType.Numeric },
                        new Parameter { name = "maxRange", ParamType = ParamType.Numeric },
                        new Parameter { name = "respectTeams", ParamType = ParamType.Boolean },
                        new Parameter { name = "players", ParamType = ParamType.Player }
                }
            });
            commandQue.Add(new Command
            {
                name = "stats",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "block", "entity" } },
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate, dependancy = new[] { new KeyValuePair<int,string>(1, "block") } },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate, dependancy = new[] { new KeyValuePair<int,string>(1, "block") } },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate, dependancy = new[] { new KeyValuePair<int,string>(1, "block") } },
                    new Parameter { name = "selector", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int,string>(1, "entity") } },
                    new Parameter { name = "dowhat", ParamType = ParamType.Fixed, possibleValues = new[] { "set", "clear" } },
                    new Parameter { name = "stat", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "selector2", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int,string>(1, "entity"), new KeyValuePair<int, string>(3, "set") } },
                    new Parameter { name = "selector2", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int,string>(1, "block"), new KeyValuePair<int, string>(5, "set") } },
                    new Parameter { name = "objective", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int,string>(1, "entity"), new KeyValuePair<int, string>(3, "set") } },
                    new Parameter { name = "objective", ParamType = ParamType.Player, dependancy = new[] { new KeyValuePair<int,string>(1, "block"), new KeyValuePair<int, string>(5, "set") } },
                }
            });
            commandQue.Add(new Command
            {
                name = "stopsound",
                parameters = new[] {
                        new Parameter { name = "player", ParamType = ParamType.Player },
                        new Parameter { name = "source", ParamType = ParamType.Fixed, possibleValues = new[] { "master", "music", "record", "weather", "block", "hostile", "neutral", "player", "ambient", "voice" } },
                        new Parameter { name = "sound", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "summon",
                parameters = new[] {
                        new Parameter { name = "entity", ParamType = ParamType.Alphanumeric },
                        new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                        new Parameter { name = "y", ParamType = ParamType.Coordinate },
                        new Parameter { name = "z", ParamType = ParamType.Coordinate },
                        new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "teleport",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "target/x", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "yaw", ParamType = ParamType.Coordinate },
                    new Parameter { name = "pitch", ParamType = ParamType.Coordinate }
                }
            });
            commandQue.Add(new Command
            {
                name = "tell",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "message", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "tellraw",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "message", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "testfor",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT }
                }
            });
            commandQue.Add(new Command
            {
                name = "testforblock",
                parameters = new[] {
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "block", ParamType = ParamType.Block },
                    new Parameter { name = "state", ParamType = ParamType.Numeric },
                    new Parameter { name = "dataTag", ParamType = ParamType.NBT },
                }
            });
            commandQue.Add(new Command
            {
                name = "testforblocks",
                parameters = new[] {
                    new Parameter { name = "x1", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y1", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z1", ParamType = ParamType.Coordinate },
                    new Parameter { name = "x2", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y2", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z2", ParamType = ParamType.Coordinate },
                    new Parameter { name = "x", possibleValues = new[] { "fillCords" }, ParamType = ParamType.Coordinate },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "all", "masked" } }
                }
            });
            commandQue.Add(new Command
            {
                name = "time",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "add", "query", "set" } },
                    new Parameter { name = "value", ParamType = ParamType.Numeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "title",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "clear", "reset", "title", "subtitle", "actionbar", "times" } },
                    new Parameter { name = "fadeIn", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(2, "times") } },
                    new Parameter { name = "stay", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(2, "times") } },
                    new Parameter { name = "fadeOut", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(2, "times") } },
                    new Parameter { name = "json", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int,string>(2, "title") } },
                    new Parameter { name = "json", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int,string>(2, "subtitle") } },
                    new Parameter { name = "json", ParamType = ParamType.NBT, dependancy = new[] { new KeyValuePair<int,string>(2, "actionbar") } }
                }
            });
            commandQue.Add(new Command
            {
                name = "toggledownfall"
            });
            commandQue.Add(new Command
            {
                name = "tp",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "target/x", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "y", ParamType = ParamType.Coordinate },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate },
                    new Parameter { name = "yaw", ParamType = ParamType.Coordinate },
                    new Parameter { name = "pitch", ParamType = ParamType.Coordinate }
                }
            });
            commandQue.Add(new Command
            {
                name = "trigger",
                parameters = new[] {
                    new Parameter { name = "objective", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "add", "set" } },
                    new Parameter { name = "value", ParamType = ParamType.Numeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "w",
                parameters = new[] {
                    new Parameter { name = "player", ParamType = ParamType.Player },
                    new Parameter { name = "message", ParamType = ParamType.Alphanumeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "weather",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "clear", "rain", "thunder" } },
                    new Parameter { name = "duration", ParamType = ParamType.Numeric }
                }
            });
            commandQue.Add(new Command
            {
                name = "worldborder",
                parameters = new[] {
                    new Parameter { name = "mode", ParamType = ParamType.Fixed, possibleValues = new[] { "add", "center", "damage", "get", "set", "warning" } },
                    new Parameter { name = "mode_damage", ParamType = ParamType.Fixed, possibleValues = new[] { "amount", "buffer" }, dependancy = new[] { new KeyValuePair<int,string>(1, "damage") } },
                    new Parameter { name = "mode_warning", ParamType = ParamType.Fixed, possibleValues = new[] { "distance", "time" }, dependancy = new[] { new KeyValuePair<int,string>(1, "warning") } },
                    new Parameter { name = "distance", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(1, "add") } },
                    new Parameter { name = "time", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(1, "add") } },
                    new Parameter { name = "x", ParamType = ParamType.Coordinate, dependancy = new[] { new KeyValuePair<int,string>(1, "center") } },
                    new Parameter { name = "z", ParamType = ParamType.Coordinate, dependancy = new[] { new KeyValuePair<int,string>(1, "center") } },
                    new Parameter { name = "damagePerBlock", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(1, "damage"), new KeyValuePair<int, string>(2, "amount") } },
                    new Parameter { name = "distance", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(1, "damage"), new KeyValuePair<int, string>(2, "buffer") } },
                    new Parameter { name = "distance", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(1, "set") } },
                    new Parameter { name = "time", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(1, "set") } },
                    new Parameter { name = "distance", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int,string>(1, "warning"), new KeyValuePair<int, string>(2, "distance") } },
                    new Parameter { name = "time", ParamType = ParamType.Numeric, dependancy = new[] { new KeyValuePair<int, string>(1, "warning"), new KeyValuePair<int, string>(2, "time") } },
                }
            });
            commandQue.Add(new Command
            {
                name = "xp",
                parameters = new[] {
                    new Parameter { name = "amount", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "player", ParamType = ParamType.Player }
                }
            });
            commandQue.Add(new Command
            {
                name = "~ ~ ~",
                parameters = new[] {
                    new Parameter { name = "amount", ParamType = ParamType.Alphanumeric },
                    new Parameter { name = "player", ParamType = ParamType.Player }
                }
            });
            mainWindow.commandQue = commandQue;
        }
    }
}
