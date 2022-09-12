using TOG.App.Definitions;

namespace TOG.App;

public static partial class Program
{
    public static NamespaceDefinition[] _definitions = new NamespaceDefinition[]
    {
        // [Class] EFT.GameWorld
        new NamespaceDefinition("game_world", new()
        {
            new OffsetDefinition("loot_list").WithFieldName("LootList"),
            new OffsetDefinition("registered_players").WithFieldName("RegisteredPlayers"),
            new OffsetDefinition("exfil_controller").WithUnknownType().WithFieldFilter(c => c.First()),
            new OffsetDefinition("grenades").WithFieldName("Grenades")
        }).WithNamespace("EFT").WithClass("GameWorld"),

        // [Class] -.GClass0B5E
        new NamespaceDefinition("exfil_controller", new()
        {
            new OffsetDefinition("points").WithType("EFT.Interactive.ExfiltrationPoint[]"),
            new OffsetDefinition("scav_points").WithType("EFT.Interactive.ScavExfiltrationPoint[]"),
        }, new()
        {
            new NamespaceDefinition("_point", new()
            {
                new OffsetDefinition("Requirements").WithFieldName("Requirements"),
                new OffsetDefinition("_status").WithFieldName("_status"),
                new OffsetDefinition("ExfiltrationStartTime").WithFieldName("ExfiltrationStartTime"),
                new OffsetDefinition("Reusable").WithFieldName("Reusable")
            }, new()
            {
                new NamespaceDefinition("_requirement", new()
                {
                    new OffsetDefinition("Id").WithFieldName("Id"),
                    new OffsetDefinition("RequirementTip").WithFieldName("RequirementTip"),
                    new OffsetDefinition("Requirement").WithFieldName("Requirement"),
                    new OffsetDefinition("Count").WithFieldName("Count"),
                    new OffsetDefinition("RequiredSlot").WithFieldName("RequiredSlot"),
                }).WithNamespace("EFT.Interactive").WithClass("ExfiltrationRequirement")
            }).WithNamespace("EFT.Interactive").WithClass("ExfiltrationPoint")
        }).FromPreviousFoundField("game_world::exfil_controller"),

        // [Class] EFT.Player
        new NamespaceDefinition("player", new()
        {
            new OffsetDefinition("action").WithType("System.Action<Single, Single, Int32>").WithFieldFilter(c => c.First()),
            new OffsetDefinition("movement_context").WithUnknownFieldName().WithUnknownType().WithFieldFilter(c => c.First()),
            new OffsetDefinition("profile").WithType("EFT.Profile"),
            new OffsetDefinition("pwa").WithType("EFT.Animations.ProceduralWeaponAnimation"),
            new OffsetDefinition("body").WithType("EFT.PlayerBody"),
            new OffsetDefinition("health_controller").WithFieldName("_healthController"),
            new OffsetDefinition("physical").WithFieldName("Physical"),
            new OffsetDefinition("is_local_player").WithType("Boolean").WithFieldFilter(c => c.Last()),
            new OffsetDefinition("hands_controller").WithFieldName("_handsController"),
            // [Class] -.PlayerBones : MonoBehaviour
            new OffsetDefinition("PlayerBones").WithFieldName("PlayerBones")
        }, new List<NamespaceDefinition>()
        {
            new NamespaceDefinition("_player_bones", new() {
                //[140] Fireport : EFT.BifacialTransform
                new OffsetDefinition("fireport").WithFieldName("Fireport")
            }).FromPreviousFoundField("player::PlayerBones"),

            new NamespaceDefinition("_physical", new()
            {
                new OffsetDefinition("stamina").WithFieldName("Stamina")
            }, new ()
            {
                new NamespaceDefinition("_stamina", new()
                {
                    new OffsetDefinition("current").WithFieldName("Current")
                }).FromPreviousFoundField("_physical::stamina")
            }).FromPreviousFoundField("player::physical"),

            new NamespaceDefinition("_health_controller", new()
            {
                new OffsetDefinition("bodyPartStateDictionary").WithType("System.Collections.Generic.Dictionary<Int32, BodyPartState<Var>>")
            }, new()
            {
                new NamespaceDefinition("_bodyPartStateDictionary", new()
                {
                    new OffsetDefinition("Health").WithFieldName("Health"),
                    new OffsetDefinition("IsDestroyed").WithFieldName("IsDestroyed"),
                }, new()
                {
                    new NamespaceDefinition("_health", new ()
                    {
                        new OffsetDefinition("Value").WithFieldName("Value")
                    }).WithNamespace("EFT.HealthSystem").WithClass("HealthValue")
                }).WithClass("BodyPartState")
            }).FromPreviousFoundField("player::health_controller"),

            new NamespaceDefinition("_movement_context", new()
            {
                new OffsetDefinition("position").WithType("UnityEngine.RaycastHit").WithFieldFilter(c => c.First()),
                new OffsetDefinition("view_angle").WithType("UnityEngine.Vector2").WithFieldFilter(c => c.Skip(2).First())
            }).FromPreviousFoundField("player::movement_context"),

            new NamespaceDefinition("_player_body", new()
            {
                new OffsetDefinition("SlotViews").WithFieldName("SlotViews"),
                new OffsetDefinition("SkeletonRootJoint").WithFieldName("SkeletonRootJoint"),
                new OffsetDefinition("BodySkins").WithFieldName("BodySkins")
            }, new()
            {
                new NamespaceDefinition("Skeleton", new()
                {
                    new OffsetDefinition("_values").WithFieldName("_values")
                }).WithNamespace("Diz.Skinning").WithClass("Skeleton")
            }).FromPreviousFoundField("player::body"),

            // [Class] -.AIFirearmController : FirearmController
            new NamespaceDefinition("_hands_controller", new()
            {
                new OffsetDefinition("fireport").WithFieldName("Fireport"),
            }, new ()
            {
                new NamespaceDefinition("_fireport", new()
                {
                    new OffsetDefinition("Original").WithFieldName("Original")
                }).WithNamespace("EFT").WithClass("BifacialTransform")
            }).WithClass("AIFirearmController")
        }).WithNamespace("EFT").WithClass("Player"),

        // [Class] EFT.Profile
        new NamespaceDefinition("profile", new()
        {
            new OffsetDefinition("info").WithFieldName("Info").WithUnknownType(),
            new OffsetDefinition("skills").WithFieldName("Skills").WithUnknownType()
        }, new List<NamespaceDefinition>()
        {
            new NamespaceDefinition("_info", new()
            {
                new OffsetDefinition("Nickname").WithFieldName("Nickname"),
                new OffsetDefinition("GroupId").WithFieldName("GroupId"),
                new OffsetDefinition("Settings").WithFieldName("Settings"),
                new OffsetDefinition("Side").WithFieldName("Side"),
                new OffsetDefinition("RegistrationDate").WithFieldName("RegistrationDate"),
            }, new()
            {
                new NamespaceDefinition("_Settings", new() {
                    new OffsetDefinition("Role").WithFieldName("Role"),
                    new OffsetDefinition("Experience").WithFieldName("Experience")
                }).FromPreviousFoundField("_info::Settings")
            }).FromPreviousFoundField("profile::info"),

            new NamespaceDefinition("_skills", new()
            {
                new OffsetDefinition("SearchBuffSpeed").WithFieldName("SearchBuffSpeed"),
                new OffsetDefinition("SearchDouble").WithFieldName("SearchDouble")
            }).FromPreviousFoundField("profile::skills")
        }).WithNamespace("EFT").WithClass("Profile"),

        // [Class] EFT.Interactive.LootItem
        new NamespaceDefinition("loot_item", new()
        {
            new OffsetDefinition("Name").WithFieldName("Name").WithType("String"),
            new OffsetDefinition("InventoryLogicItem").WithType("EFT.InventoryLogic.Item"),
            new OffsetDefinition("_renderers").WithFieldName("_renderers")
        }, new()
        {
            // [Class] EFT.InventoryLogic.Item
            new NamespaceDefinition("_InventoryLogicItem", new()
            {
                new OffsetDefinition("StackObjectsCount").WithFieldName("StackObjectsCount")
            }).WithNamespace("EFT.InventoryLogic").WithClass("Item")
        }).WithNamespace("EFT.Interactive").WithClass("LootItem"),

        // [Class] EFT.Animations.ProceduralWeaponAnimation
        new NamespaceDefinition("pwa", new()
        {
            new OffsetDefinition("mask").WithFieldName("Mask"),
            new OffsetDefinition("breath_effector").WithFieldName("Breath").WithType("EFT.Animations.BreathEffector"),
            new OffsetDefinition("shot_effector").WithFieldName("Shootingg").WithType("-.ShotEffector"),
            new OffsetDefinition("Walk").WithFieldName("Walk"),
            new OffsetDefinition("MotionReact").WithFieldName("MotionReact"),
            new OffsetDefinition("ForceReact").WithFieldName("ForceReact"),
            new OffsetDefinition("_fovCompensatoryDistance").WithFieldName("_fovCompensatoryDistance"),
            new OffsetDefinition("CameraSmoothTime").WithFieldName("CameraSmoothTime")
        }, new()
        {
            // [Class] EFT.Animations.BreathEffector
            new NamespaceDefinition("breath", new()
            {
                new OffsetDefinition("intensity").WithFieldName("Intensity"),
            }).WithNamespace("EFT.Animations").WithClass("BreathEffector"),

            // [Class] -.ShotEffector
            new NamespaceDefinition("recoil", new()
            {
                new OffsetDefinition("itensity").WithFieldName("Intensity")
            }).WithNamespace("-").WithClass("ShotEffector"),

            // [Class] -.WalkEffector : Object, IEffector
            new NamespaceDefinition("_walk", new()
            {
                new OffsetDefinition("itensity").WithFieldName("Intensity")
            }).FromPreviousFoundField("pwa::Walk"),

            // [Class] -.MotionEffector : Object, IEffector
            new NamespaceDefinition("_motion", new()
            {
                new OffsetDefinition("itensity").WithFieldName("Intensity")
            }).FromPreviousFoundField("pwa::MotionReact"),

            // [Class] -.ForceEffector : Object, IEffector
            new NamespaceDefinition("_force", new()
            {
                new OffsetDefinition("itensity").WithFieldName("Intensity")
            }).FromPreviousFoundField("pwa::ForceReact"),

        }).WithNamespace("EFT.Animations").WithClass("ProceduralWeaponAnimation"),

        new NamespaceDefinition("hard_settings", new()
        {
            new OffsetDefinition("LOOT_RAYCAST_DISTANCE").WithFieldName("LOOT_RAYCAST_DISTANCE"),
            new OffsetDefinition("DOOR_RAYCAST_DISTANCE").WithFieldName("DOOR_RAYCAST_DISTANCE"),

        }).WithNamespace("-").WithClass("EFTHardSettings"),

        // [Class] BSG.CameraEffects.NightVision : MonoBehaviour, GInterface325A
        new NamespaceDefinition("night_vision", new()
        {
            new OffsetDefinition("on").WithFieldName("_on")
        }).WithNamespace("BSG.CameraEffects").WithClass("NightVision"),

        // [Class] -.VisorEffect : MonoBehaviour
        new NamespaceDefinition("visor_effect", new()
        {
            new OffsetDefinition("Intensity").WithFieldName("Intensity")
        }).WithNamespace("-").WithClass("VisorEffect"),

        // [Class] -.ThermalVision : MonoBehaviour, GInterface325A
        new NamespaceDefinition("thermal_vision", new()
        {
            new OffsetDefinition("On").WithFieldName("On")
        }).WithNamespace("-").WithClass("ThermalVision")
    };

}
