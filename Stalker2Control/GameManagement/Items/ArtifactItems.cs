﻿namespace Stalker2Control.GameManagement.Items
{
    /// <summary>
    /// Represents a collection of artifacts items and their descriptions.
    /// </summary>
    public class ArtifactItems
    {
        /// <summary>
        /// Gets the dictionary containing artifacts descriptions.
        /// </summary>
        public Dictionary<string, string> ArtifactsDescriptions { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtifactItems"/> class.
        /// </summary>
        public ArtifactItems()
        {
            ArtifactsDescriptions = InitializeArtifactsDescriptions();
        }

        private Dictionary<string, string> InitializeArtifactsDescriptions() =>
            new()
            {
                { "TemplateArtifact", "Non-playable item" },
                { "EArtifactFlash", "Flash" },
                { "EArtifactFlash_Fake", "Flash (shell, not an artifact)" },
                { "EArtifactSoul", "Soul" },
                { "EArtifactSoul_Fake", "Soul (shell, not an artifact)" },
                { "EArtifactSnowflake", "Snowflake" },
                { "EArtifactSnowflake_Fake", "Snowflake (shell, not an artifact)" },
                { "GArtifactNightStar", "Night Star" },
                { "GArtifactNightStar_Fake", "Night Star (shell, not an artifact)" },
                { "EArtifactDummy", "Dummy" },
                { "EArtifactDummy_Fake", "Dummy (shell, not an artifact)" },
                { "CArtifactCrystalThorn", "Crystal Thorn" },
                { "CArtifactCrystalThorn_Fake", "Crystal Thorn (shell, not an artifact)" },
                { "EArtifactBattery", "Battery" },
                { "EArtifactBattery_Fake", "Battery (shell, not an artifact)" },
                { "FArtifactCrystal", "Crystal" },
                { "FArtifactCrystal_Fake", "Crystal (shell, not an artifact)" },
                { "EArtifactMoonlight", "Moonlight" },
                { "EArtifactMoonlight_Fake", "Moonlight (shell, not an artifact)" },
                { "FArtifactMomsBeads", "Mom's Beads" },
                { "FArtifactMomsBeads_Fake", "Mom's Beads (shell, not an artifact)" },
                { "EArtifactJellyFish", "Sapphire" },
                { "EArtifactJellyFish_Fake", "Sapphire (shell, not an artifact)" },
                { "EArtifactTow", "Labor Lesson" },
                { "EArtifactTow_Fake", "Labor Lesson (shell, not an artifact)" },
                { "EArtifactThunderHedgehog", "Lantern" },
                { "EArtifactThunderHedgehog_Fake", "Lantern (shell, not an artifact)" },
                { "EArtifactWorm", "Rat King" },
                { "EArtifactWorm_Fake", "Rat King (shell, not an artifact)" },
                { "EArtifactCloud", "Harp" },
                { "EArtifactCloud_Fake", "Harp (shell, not an artifact)" },
                { "EArtifactAtom", "Glimmer" },
                { "EArtifactAtom_Fake", "Glimmer (shell, not an artifact)" },
                { "EArtifactRazor", "Starfish" },
                { "EArtifactRazor_Fake", "Starfish (shell, not an artifact)" },
                { "EArtifactSparkler", "Sparkler" },
                { "EArtifactSparkler_Fake", "Sparkler (shell, not an artifact)" },
                { "FArtifactFireBall", "Fireball" },
                { "FArtifactFireBall_Fake", "Fireball (shell, not an artifact)" },
                { "GArtifactGoldFish", "Goldfish" },
                { "GArtifactGoldFish_Fake", "Goldfish (shell, not an artifact)" },
                { "FArtifactSteak", "Steak" },
                { "FArtifactSteak_Fake", "Steak (shell, not an artifact)" },
                { "GArtifactStoneDrop", "Stone Heart" },
                { "GArtifactStoneDrop_Fake", "Stone Heart (shell, not an artifact)" },
                { "FArtifactBakedBolts", "Defect" },
                { "FArtifactBakedBolts_Fake", "Defect (shell, not an artifact)" },
                { "FArtifactGlass", "Cavity" },
                { "FArtifactGlass_Fake", "Cavity (shell, not an artifact)" },
                { "FArtifactDeadSponge", "Dead Sponge" },
                { "FArtifactDeadSponge_Fake", "Dead Sponge (shell, not an artifact)" },
                { "FArtifactHellishHedgehog", "Magma" },
                { "FArtifactHellishHedgehog_Fake", "Magma (shell, not an artifact)" },
                { "FArtifactPlasma", "Plasma" },
                { "FArtifactPlasma_Fake", "Plasma (shell, not an artifact)" },
                { "FArtifactCandle", "Petal" },
                { "FArtifactCandle_Fake", "Petal (shell, not an artifact)" },
                { "FArtifactRingOmnipotence", "Hypercube" },
                { "FArtifactRingOmnipotence_Fake", "Hypercube (shell, not an artifact)" },
                { "FArtifactFireworks", "Meat Lighter" },
                { "FArtifactFireworks_Fake", "Meat Lighter (shell, not an artifact)" },
                { "FArtifactCore", "Torch" },
                { "FArtifactCore_Fake", "Torch (shell, not an artifact)" },
                { "FArtifactBurntHunk", "Whirligig" },
                { "FArtifactBurntHunk_Fake", "Whirligig (shell, not an artifact)" },
                { "FArtifactResin", "Lyre" },
                { "FArtifactResin_Fake", "Lyre (shell, not an artifact)" },
                { "GArtifactSpring", "Spring" },
                { "GArtifactSpring_Fake", "Spring (shell, not an artifact)" },
                { "CArtifactPellicle", "Film" },
                { "CArtifactPellicle_Fake", "Film (shell, not an artifact)" },
                { "CArtifactChunkMeat", "Meat Chunk" },
                { "CArtifactChunkMeat_Fake", "Meat Chunk (shell, not an artifact)" },
                { "GArtifactGravy", "Gravy" },
                { "GArtifactGravy_Fake", "Gravy (shell, not an artifact)" },
                { "FArtifactDrops", "Drops" },
                { "FArtifactDrops_Fake", "Drops (shell, not an artifact)" },
                { "FArtifactEye", "Eye" },
                { "FArtifactEye_Fake", "Eye (shell, not an artifact)" },
                { "CArtifactBun", "Kolobok" },
                { "CArtifactBun_Fake", "Kolobok (shell, not an artifact)" },
                { "CArtifactThorn", "Thorn" },
                { "CArtifactThorn_Fake", "Thorn (shell, not an artifact)" },
                { "GArtifactWrenched", "Wrench" },
                { "GArtifactWrenched_Fake", "Wrench (shell, not an artifact)" },
                { "GArtifactBloodStone", "Blood Stone" },
                { "GArtifactBloodStone_Fake", "Blood Stone (shell, not an artifact)" },
                { "GArtifactGraphiteBlock", "Crown" },
                { "GArtifactGraphiteBlock_Fake", "Crown (shell, not an artifact)" },
                { "GArtifactSplitStone", "Broken Stone" },
                { "GArtifactSplitStone_Fake", "Broken Stone (shell, not an artifact)" },
                { "GArtifactTrunk", "Rosin" },
                { "GArtifactTrunk_Fake", "Rosin (shell, not an artifact)" },
                { "GArtifactRubiksCube", "Rubik's Cube" },
                { "GArtifactRubiksCube_Fake", "Rubik's Cube (shell, not an artifact)" },
                { "GArtifactSponge", "Whirl" },
                { "GArtifactSponge_Fake", "Whirl (shell, not an artifact)" },
                { "GArtifactHedgehog", "Flytrap" },
                { "GArtifactHedgehog_Fake", "Flytrap (shell, not an artifact)" },
                { "GArtifactBud", "Bud" },
                { "GArtifactBud_Fake", "Bud (shell, not an artifact)" },
                { "GArtifactPlane", "Unrealized artifact (as of 25.11.24)" },
                { "GArtifactPlane_Fake", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactMica", "Game crash" },
                { "CArtifactMica_Fake", "Game crash (shell, not an artifact)" },
                { "CArtifactBubble", "Bubble" },
                { "CArtifactBubble_Fake", "Bubble (shell, not an artifact)" },
                { "CArtifactSlime", "Slime" },
                { "CArtifactSlime_Fake", "Slime (shell, not an artifact)" },
                { "CArtifactSlug", "Slug" },
                { "CArtifactSlug_Fake", "Slug (shell, not an artifact)" },
                { "CArtifactEchinus", "Sea Urchin" },
                { "CArtifactEchinus_Fake", "Sea Urchin (shell, not an artifact)" },
                { "GArtifactCompass", "Compass" },
                { "GArtifactCompass_Fake", "Compass (shell, not an artifact)" },
                { "CArtifactKryptonite", "Mold" },
                { "CArtifactKryptonite_Fake", "Mold (shell, not an artifact)" },
                { "CArtifactBung", "Gingerbread Man" },
                { "CArtifactBung_Fake", "Gingerbread Man (shell, not an artifact)" },
                { "CArtifactOoze", "Ooze" },
                { "CArtifactOoze_Fake", "Ooze (shell, not an artifact)" },
                { "CArtifactIceCrystal", "Ice" },
                { "CArtifactIceCrystal_Fake", "Ice (shell, not an artifact)" },
                { "CArtifactPolyhedron", "Polyhedron" },
                { "CArtifactPolyhedron_Fake", "Polyhedron (shell, not an artifact)" },
                { "GArtifactModular", "Unrealized artifact (as of 25.11.24)" },
                { "GArtifactModular_Fake", "Unrealized artifact (as of 25.11.24)" },
                { "GArtifactPea", "Game crash" },
                { "GArtifactPea_Fake", "Game crash (shell, not an artifact)" },
                { "GArtifactCocoon", "Cocoon" },
                { "GArtifactCocoon_Fake", "Cocoon (shell, not an artifact)" },
                { "GArtifactPorcupine", "Sea Cucumber" },
                { "GArtifactPorcupine_Fake", "Sea Cucumber (shell, not an artifact)" },
                { "GArtifactCrystal", "Unrealized artifact (as of 25.11.24)" },
                { "GArtifactCrystal_Fake", "Unrealized artifact (as of 25.11.24)" },
                { "GArtifactEye", "Eye" },
                { "GArtifactEye_Fake", "Eye (shell, not an artifact)" },
                { "GArtifactGel", "Gel" },
                { "GArtifactGel_Fake", "Gel (shell, not an artifact)" },
                { "GArtifactMogul", "Unrealized artifact (as of 25.11.24)" },
                { "GArtifactMogul_Fake", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactGraphene", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactGraphene_Fake", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactLeech", "Leech" },
                { "CArtifactLeech_Fake", "Leech (shell, not an artifact)" },
                { "CArtifactCobblestone", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactCobblestone_Fake", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactLump", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactLump_Fake", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactObliterator", "Unrealized artifact (as of 25.11.24)" },
                { "CArtifactObliterator_Fake", "Unrealized artifact (as of 25.11.24)" }
            };
    }
}